using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace NormalChart
{
    class ChartData
    {

        private readonly SqlConnection SQLConn = new SqlConnection();
        private string _maintenanceConStr;

        public event EventHandler ChangedAviableCurves;
        private void OnChangedAviableCurves()
        {
            ChangedAviableCurves?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler<ChartDataErrEventArgs> sqlError;
        private void OnErr(string msg)
        {
            var par = new ChartDataErrEventArgs();
            par.ErrMsg = msg;
            sqlError?.Invoke(this, par);
        }

        public event EventHandler<ChartDataEventArgs> NewDBData;
        private void OnNewDBData(DataTable data)
        {
            var par = new ChartDataEventArgs();
            par.Data = data;
            NewDBData?.Invoke(this, par);
        }


        public ChartData()
        {
            SelectedCurves = new DataTable();
            SelectedCurves.Columns.Add("LogId", typeof(int));
            SelectedCurves.Columns.Add("Descr", typeof(string));
            _sqlP.ParametersChanged += LoadData;
        }

        public bool Connect(string srvAddr)
        {
            SQLConn.ConnectionString = "server=" + srvAddr + ";database=Stats; Trusted_Connection=True;connection timeout=4";
            _maintenanceConStr = "server=" + srvAddr + ";database=master; Trusted_Connection=True;connection timeout=4";
            try
            {
                SQLConn.Open();
                AviableCurves = GetCurves();
            }
            catch (Exception e)
            {
                OnErr(e.Message);
            }
            return SQLConn.State == ConnectionState.Open;
        }


        private SQLParams _sqlP = new SQLParams();
        public SQLParams SqlP
        { 
            get { return _sqlP; }
            set
            {
                if (value != _sqlP)
                {
                    _sqlP = value;
                }
            }
        }

        private DataTable _aviableCurves;
        public DataTable AviableCurves
        {
            get { return _aviableCurves; }
            set
            {
                if (value != _aviableCurves)
                {
                    _aviableCurves = value;
                    OnChangedAviableCurves();
                }
            }
        }


        public DataTable SelectedCurves { get; }

        private DataTable GetCurves()
        {
            DataTable t = new DataTable();
            try
            {
                using (SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM LogNames ORDER BY LogId ASC", SQLConn))
                {
                    a.Fill(t);
                    t.DefaultView.Sort = "LogId ASC";
                }
            }
            catch (Exception e)
            {
                t.Columns.Add("LogId", typeof(int));
                t.Columns.Add("Descr", typeof(string));
                OnErr(e.Message);
            }
            return t;
        }



        private void LoadData(object s, EventArgs e)
        {
            _sqlP.LogID.Clear();
            foreach (DataRow r in SelectedCurves.Rows)
            {
                _sqlP.LogID.Add((int)r[0]);
            }

            BackgroundWorker bgvGetData = new BackgroundWorker();
            bgvGetData.WorkerSupportsCancellation = true;
            bgvGetData.DoWork += LoadDataFromDB;
            bgvGetData.RunWorkerCompleted += DataLoaded;
            bgvGetData.RunWorkerAsync();
        }

        private void LoadDataFromDB(object sender, DoWorkEventArgs e)
        {
            e.Result = GetData(_sqlP);
        }

        private void DataLoaded(object sender, RunWorkerCompletedEventArgs e)
        {
            OnNewDBData((DataTable)e.Result);
        }

        ///<summary>Returns SQL table acording to params
        ///<para>SQLParams</para>
        ///</summary>
        public DataTable GetData(SQLParams p)
        {
            DataTable t = new DataTable();
            try
            {
                using (var command = new SqlCommand("GetCharts", SQLConn) { CommandType = CommandType.StoredProcedure })
                {
                    var xmlSerializer = new XmlSerializer(typeof(SQLParams));
                    var stringBuilder = new StringBuilder();
                    using (var xmlWriter = XmlWriter.Create(stringBuilder, new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true }))
                    {
                        xmlSerializer.Serialize(xmlWriter, p);
                    }
                    command.Parameters.Add(new SqlParameter("@params", stringBuilder.ToString()));
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(t);
                }
            }
            catch (Exception e)
            {
                OnErr(e.Message);
            }
            return t;
        }

        #region LogNames
        public void AddLogTag(DataTable dt)
        {
            using (var bulk = new SqlBulkCopy(SQLConn))
            {
                bulk.DestinationTableName = "LogNames";
                bulk.WriteToServer(dt);
            }
        }
        public void AddLogTag(string Logname)
        {
            string cmd = "INSERT INTO LogNames SELECT '" + Logname + "' WHERE NOT EXISTS(SELECT Descr FROM LogNames WHERE Descr = '" + Logname + "')";
            using (var command = new SqlCommand(cmd, SQLConn))
            {
                command.ExecuteNonQuery();
            }
            AviableCurves = GetCurves();
        }
        public int AddLogTag(List<string> Logname)
        {
            int i = 0;
            using (var command = new SqlCommand())
            {
                command.Connection = SQLConn;
                foreach (string s in Logname)
                {
                    command.CommandText = "INSERT INTO LogNames SELECT '" + s + "' WHERE NOT EXISTS(SELECT Descr FROM LogNames WHERE Descr = '" + s + "')";
                    i = i + command.ExecuteNonQuery();
                }
            }
            AviableCurves = GetCurves();
            return i;
        }
        public void RenameDataLog(int logId, string newname)
        {
            string cmd = "UPDATE LogNames SET Descr = '" + newname + "' WHERE LogId = " + logId.ToString();
            using (var command = new SqlCommand(cmd, SQLConn))
            {
                command.ExecuteNonQuery();
            }
            AviableCurves = GetCurves();
        }
        public void DeleteDataLog(int logId)
        {
            string cmd = "DELETE FROM LogNames WHERE LogId = " + logId.ToString();
            using (var command = new SqlCommand(cmd, SQLConn))
            {
                command.ExecuteNonQuery();
            }
            AviableCurves = GetCurves();
        }
        #endregion

        #region Database maintenance
        public void BackUpDB(string fname)
        {
            using (SqlConnection cn = new SqlConnection(_maintenanceConStr))
            {
                cn.Open();
                string cmd = "BACKUP DATABASE [Stats] TO DISK='" + fname + "'";
                using (var command = new SqlCommand(cmd, cn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        public void RestoreDB(string fname)
        {
            using (SqlConnection cn = new SqlConnection(_maintenanceConStr))
            {
                cn.Open();
                #region step 1 SET SINGLE_USER WITH ROLLBACK
                string sql = "IF DB_ID('Stats') IS NOT NULL ALTER DATABASE [Stats] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                using (var command = new SqlCommand(sql, cn))
                {
                    command.ExecuteNonQuery();
                }
                #endregion
                #region step 2 InstanceDefaultDataPath

                sql = "SELECT ServerProperty(N'InstanceDefaultDataPath') AS default_file";
                string default_file = "NONE";
                using (var command = new SqlCommand(sql, cn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            default_file = reader.GetString(reader.GetOrdinal("default_file"));
                        }
                    }
                }
                sql = "SELECT ServerProperty(N'InstanceDefaultLogPath') AS default_log";
                string default_log = "NONE";
                using (var command = new SqlCommand(sql, cn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Check the reader has data:
                        if (reader.Read())
                        {
                            default_log = reader.GetString(reader.GetOrdinal("default_log"));
                        }
                    }
                }
                #endregion
                #region step 3 Restore
                sql = "USE MASTER RESTORE DATABASE [Stats] FROM DISK='" + fname + "' WITH  FILE = 1, MOVE N'Stats' TO '" + default_file + "Stats.mdf', MOVE N'Stats_Log' TO '" + default_log + "Stats_Log.ldf', NOUNLOAD,  REPLACE,  STATS = 1;";
                using (var command = new SqlCommand(sql, cn))
                {
                    command.ExecuteNonQuery();
                }
                #endregion
                #region step 4 SET MULTI_USER
                sql = "ALTER DATABASE [Stats] SET MULTI_USER";
                using (var command = new SqlCommand(sql, cn))
                {
                    command.ExecuteNonQuery();
                }
                #endregion
            }
        }
        public void SetupDB(string Server)
        {
            string script = File.ReadAllText("DBSetup.sql");
            IList<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            using (SqlConnection cn = new SqlConnection(_maintenanceConStr))
            {
                cn.Open();
                foreach (string commandString in commandStrings)
                {
                    if (commandString.Trim() != "")
                    {
                        using (var command = new SqlCommand(commandString, cn))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            AviableCurves = GetCurves();
        }
        #endregion

        #region LEFT <-> RIGHT
        public void MoveDataRowRight(DataRow r)
        {
            SelectedCurves.ImportRow(r);
            AviableCurves.Rows.Remove(r);
        }
        public void MoveDataRowLeft(DataRow r)
        {
            AviableCurves.ImportRow(r);
            SelectedCurves.Rows.Remove(r);
        }
        #endregion

        public DataTable GetLocalServers()
        {
            DataTable servers = SqlDataSourceEnumerator.Instance.GetDataSources();
            return servers;
        }
    }

    public class ChartDataErrEventArgs : EventArgs
    {
        public string ErrMsg { get; set; }
    }

    public class ChartDataEventArgs : EventArgs
    {
        public DataTable Data { get; set; }
    }

}

