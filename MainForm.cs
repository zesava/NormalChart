using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ZedGraph;

namespace NormalChart
{

    public partial class MainForm : Form
    {
        ChartData _chart = new ChartData();
        private ProgressForm Progress;

        private string OnPointValueRequested(object sender, GraphPane pane, CurveItem curve, int pointIndex)
        {
            PointPair point = curve[pointIndex];
            string tooltip = "X:" + DateTime.FromOADate(point.X) + Environment.NewLine + "Y:" + point.Y;
            return tooltip;
        }


        public MainForm()
        {
            InitializeComponent();

            _chart.ChangedAviableCurves += ReloadLeftListBox;
            _chart.sqlError += SQL_Error;
            _chart.NewDBData += DrawNewData;

            ApplyStyle();
            zedGraph.PointValueEvent += OnPointValueRequested;

            #region Add DateTime Picker to toolbar
            dtp1.Size = new Size(140, 20);
            dtp1.ValueChanged += new EventHandler(dtp1OnChange);
            var datePicker = new ToolStripControlHost(dtp1);
            datePicker.Margin = new Padding(5, 0, 5, 0);
            toolStrip1.Items.Insert(5, datePicker);
            string customDTFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern + " HH:mm:ss";
            dtp1.Format = DateTimePickerFormat.Custom;
            dtp1.CustomFormat = customDTFormat;
            datePicker.Enabled = false;
            #endregion

            if (_chart.Connect(Properties.Settings.Default.SERVER))
            {
                EnableCtrls();
            }
            else
            {
                tabControl.SelectedIndex = 3;
            }

            lbAviableCurves.DisplayMember = "Descr";
            lbAviableCurves.ValueMember = "LogId";

            lbSelectedCurves.DisplayMember = "Descr";
            lbSelectedCurves.ValueMember = "LogId";
            lbSelectedCurves.DataSource = _chart.SelectedCurves;

            #region CMD Args
            string[] commandLineArgs = Environment.GetCommandLineArgs();
            for (int i = 0; i < commandLineArgs.Length; i++)
            {
                string a = commandLineArgs[i];
                if (a == "-l")
                {
                    string srt = commandLineArgs[i + 1];
                    IList<string> names = srt.Split(',').ToList();

                    foreach (var LogId in names)
                    {
                        DataRow amountRow = _chart.AviableCurves.Select("LogId = " + LogId).FirstOrDefault();
                        if (amountRow != null)
                            _chart.MoveDataRowRight(amountRow);
                    }
                    DisableEditMode();
                    TopMost = true;
                }
                if (a == "-b")
                {
                    FormBorderStyle = FormBorderStyle.None;
                    ShowInTaskbar = false;
                }
                if (a == "-r")
                {
                    string srt1 = commandLineArgs[i + 1];
                    int.TryParse(srt1, out int res);
                    res = Utils.LimitINT(res, 0, 4);
                    tbtnResolution.SelectedIndex = res;
                }
            }
            #endregion
        }


        private void ReloadLeftListBox(object s, EventArgs e)
        {
            lbAviableCurves.DataSource = _chart.AviableCurves;
        }

        private void SQL_Error(object s, ChartDataErrEventArgs e)
        {
            MessageBox.Show(e.ErrMsg,
                            "ERROR",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            tabControl.SelectedIndex = 3;
        }

        private void DrawNewData(object s, ChartDataEventArgs e)
        {
            DrawCharts(e.Data);
        }

        private void DisableEditMode()
        {
            tbtnSettings.Visible = false;
            btnAdd.Visible = false;
            btnRename.Visible = false;
            btnDelete.Visible = false;
            btnImportTags.Visible = false;
            button1.Visible = false;
            button3.Visible = false;
            tbtnAbout.Visible = false;
        }

        private void ApplyStyle(short id = 0)
        {
            GraphPane pane = zedGraph.GraphPane;

            #region X AXIS
            pane.XAxis.Type = AxisType.Date;
            pane.XAxis.Title.IsVisible = false;
            pane.XAxis.Scale.Format = "HH:mm:ss";
            pane.XAxis.Color = Style.Styles[id].MainColor;
            pane.XAxis.Scale.MaxAuto = true;
            pane.XAxis.Scale.MinAuto = true;

            pane.XAxis.Scale.FontSpec.Size = Style.Styles[id].FontSize;
            pane.XAxis.Scale.FontSpec.FontColor = Style.Styles[id].MainColor;
            pane.XAxis.Scale.FontSpec.Angle = Style.Styles[id].XAxisFontAngle;

            // pane.XAxis.Scale.FontSpec.Family = "imes New Roman";
            //pane.XAxis.Scale.MajorUnit = DateUnit.Millisecond;
            //pane.XAxis.Scale.MajorStep = 500;
            //pane.XAxis.Scale.MinorUnit = DateUnit.Millisecond;
            //pane.XAxis.Scale.MinorStep = 250;

            pane.XAxis.MajorGrid.IsVisible = true;
            pane.XAxis.MajorGrid.Color = Style.Styles[id].MainColor;

            pane.XAxis.MajorTic.Color = Style.Styles[id].MainColor;
            pane.XAxis.MajorTic.IsOpposite = false;
            pane.XAxis.MajorTic.IsInside = false;


            pane.XAxis.MinorTic.Color = Style.Styles[id].MainColor;
            pane.XAxis.MinorTic.IsOpposite = false;
            pane.XAxis.MinorTic.IsInside = false;

            #endregion

            #region Y AXIS
            pane.YAxis.Color = Style.Styles[id].MainColor;
            pane.YAxis.MajorGrid.Color = Style.Styles[id].MainColor;

            pane.YAxis.Scale.FontSpec.FontColor = Style.Styles[id].MainColor;
            pane.YAxis.Scale.FontSpec.Size = Style.Styles[id].FontSize;

            pane.YAxis.MajorTic.Color = Style.Styles[id].MainColor;
            pane.YAxis.MajorTic.IsOpposite = false;
            pane.YAxis.MajorTic.IsInside = false;

            pane.YAxis.MinorTic.Color = Style.Styles[id].MainColor;
            pane.YAxis.MinorTic.IsInside = false;
            pane.YAxis.MinorTic.IsOpposite = false;
            #endregion

            #region Common

            //pane.YAxis.Title.FontSpec.FontColor = color;
            pane.IsFontsScaled = false;
            pane.Title.IsVisible = false;
            pane.Legend.IsVisible = false;
            pane.Chart.Fill.Brush = new SolidBrush(Style.Styles[id].BackgroundColor);
            pane.Fill.Color = Style.Styles[id].BackgroundColor;
            pane.Chart.Border.IsVisible = false;
            pane.Border.IsVisible = false;
            #endregion

            #region Table
            dataGridView.BackgroundColor = Style.Styles[id].BackgroundColor;
            dataGridView.DefaultCellStyle.ForeColor = Style.Styles[id].MainColor;
            dataGridView.DefaultCellStyle.BackColor = Style.Styles[id].BackgroundColor;
            //dataGridView.RowsDefaultCellStyle.BackColor = Style.Styles[id].BackgroundColor;
            #endregion

        }

        private void DrawCharts(DataTable data)
        {
            GraphPane pane = zedGraph.GraphPane;
            pane.CurveList.Clear();
            pane.YAxisList.Clear();
            pane.GraphObjList.Clear();
            dataGridView.DataSource = null;

            if (data.Rows.Count > 1)
            {
                ushort colorIdx = 0; // this will auto increment with each new curve in list

                #region Populate dataGridView
                dataGridView.DataSource = data;
                dataGridView.Columns[0].DefaultCellStyle.Format = "HH:mm:ss";
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                #endregion

                foreach (DataColumn col in data.Columns)
                {
                    if (col.ColumnName != "Datetime")
                    {
                        Color axisColor = ColorTranslator.FromHtml(Utils.colors[colorIdx]);

                        DataSourcePointList dsp = new DataSourcePointList();
                        dsp.DataSource = data;
                        dsp.XDataMember = data.Columns[0].ToString();//  "dt";
                        dsp.YDataMember = col.ToString();// "val";

                        YAxis yaxis = new YAxis(col.ColumnName);
                        yaxis.Type = AxisType.Linear;
                        yaxis.Color = axisColor;
                        yaxis.Scale.FontSpec.Size = 11f;
                        yaxis.Scale.FontSpec.FontColor = axisColor;
                        // yaxis.IsVisible = true;
                        yaxis.Scale.MaxAuto = true;
                        yaxis.Scale.MinAuto = true;

                        yaxis.MajorGrid.IsZeroLine = false;
                        yaxis.MajorGrid.Color = axisColor;
                        yaxis.MajorGrid.IsVisible = true;

                        yaxis.MajorTic.IsInside = false;
                        yaxis.MajorTic.IsOpposite = false;
                        yaxis.MajorTic.Color = axisColor;

                        yaxis.MinorTic.IsInside = false;
                        yaxis.MinorTic.IsOpposite = false;
                        yaxis.MinorTic.Color = axisColor;

                        yaxis.Scale.Align = AlignP.Inside;
                        yaxis.Title.FontSpec.Size = 12f;
                        yaxis.Title.FontSpec.FontColor = axisColor;

                        pane.YAxisList.Add(yaxis);
                        int curveIdx = zedGraph.GraphPane.YAxisList.IndexOf(yaxis);
                        LineItem curve = pane.AddCurve(col.ColumnName, dsp, axisColor, SymbolType.None);
                        curve.Line.IsSmooth = true;
                        curve.Line.Width = 1f;
                        curve.YAxisIndex = curveIdx;

                        dataGridView.Columns[colorIdx + 1].DefaultCellStyle.ForeColor = axisColor;

                        colorIdx++;
                    }

                }
                zedGraph.AxisChange();
            }
            //If zedGraph IsEnabled and there is no data for selected range, it will crash while zooming!
            if (pane.CurveList.Count == 0)
            {
                zedGraph.Enabled = false;
                pane.Title.Text = "There is NO DATA available for selected period";
                pane.Title.IsVisible = true;
                pane.Title.FontSpec.FontColor = Color.White;
            }
            else
            {
                pane.Title.IsVisible = false;
                zedGraph.Enabled = true;
            }

            zedGraph.IsShowPointValues = true;
            zedGraph.Invalidate();
            GC.Collect();
        }

        private void EnableCtrls()
        {
            foreach (ToolStripItem tsb in toolStrip1.Items)
            {
                if (tsb is ToolStripSeparator)
                {
                    //do nothing
                }
                else
                {
                    tsb.Enabled = true;
                }
            }
            btnSetupDB.Enabled = true;
            btnBackupDB.Enabled = true;
            btnRestoreDB.Enabled = true;
        }

        #region Toolbar buttons

        private void tbtnShowTable_Click(object sender, System.EventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }

        private void tbtnShowChart_Click(object sender, System.EventArgs e)
        {
            if (tabControl.SelectedIndex != 0)
            {
                tabControl.SelectedIndex = 0;
            }
        }

        private void tbtnCurves_Click(object sender, System.EventArgs e)
        {
            tabControl.SelectedIndex = 2;
        }

        private void tbtnCSV_Click(object sender, System.EventArgs e)
        {
            if (dataGridView.ColumnCount > 0)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Title = "Save charts as a table values";
                dlg.Filter = "CSV Files | *.csv";
                dlg.FileName = "Log_" + dtp1.Value.ToString("yyyy-MM-dd_HHmm");

                DialogResult result = dlg.ShowDialog(); // Show the dialog.
                if (result == DialogResult.OK) // Test result.
                {
                    string file = dlg.FileName;
                    try
                    {
                        Utils.DataTableToCSV((DataTable)dataGridView.DataSource, file);
                    }
                    catch (IOException)
                    {
                    }
                }
            }
        }

        private void tbtnResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tbtnResolution.SelectedIndex)
            {
                case 0:
                    _chart.SqlP.Resolution = -15;
                    break;
                case 1:
                    _chart.SqlP.Resolution = -30;
                    break;
                case 2:
                    _chart.SqlP.Resolution = -60;
                    break;
                case 3:
                    _chart.SqlP.Resolution = -720;
                    break;
                case 4:
                    _chart.SqlP.Resolution = -1440;
                    break;
            }
        }

        private void tbtnBack_Click(object sender, EventArgs e)
        {
            dtp1.Value = dtp1.Value.Subtract(new TimeSpan(0, 0, Math.Abs(_chart.SqlP.Resolution), 0, 0));
        }

        private void tbtnForward_Click(object sender, EventArgs e)
        {
            dtp1.Value = dtp1.Value.Add(new TimeSpan(0, 0, Math.Abs(_chart.SqlP.Resolution), 0, 0));
        }

        private void tbtnSettings_Click(object sender, EventArgs e)
        {
            cmbServerName.Text = Properties.Settings.Default.SERVER;
            tabControl.SelectedIndex = 3;
        }

        DateTimePicker dtp1 = new DateTimePicker();
        private void dtp1OnChange(object sender, EventArgs e)
        {
            _chart.SqlP.StartDateTime = dtp1.Value.ToString();
        }

        private void tbtnRefresh_Click(object sender, EventArgs e)
        {
            dtp1.Value = DateTime.Now;
        }

        private void tbtnAbout_Click(object sender, EventArgs e)
        {
            AboutBox a = new AboutBox();
            a.ShowDialog();
        }

        private void tbtnZoom100_Click(object sender, EventArgs e)
        {
            zedGraph.ZoomOutAll(zedGraph.GraphPane);
        }
        #endregion

        #region Page Curves

        private void button1_Click(object sender, EventArgs e)
        {
            if (lbAviableCurves.SelectedIndex >= 0)
            {
 //                while (lbAviableCurves.SelectedItems.Count > 0)
 //               {
                    _chart.MoveDataRowRight(((DataRowView)lbAviableCurves.SelectedItem).Row);
 //               }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lbSelectedCurves.SelectedIndex >= 0)
            {
                _chart.MoveDataRowLeft(((DataRowView)lbSelectedCurves.SelectedItem).Row);
            }
        }

        private void btnRemAllCurves_Click(object sender, EventArgs e)
        {
            while (_chart.SelectedCurves.Rows.Count > 0)
            {
                _chart.MoveDataRowLeft(_chart.SelectedCurves.Rows[0]);
            }
        }

        private void tbAviableCurvers_TextChanged(object sender, EventArgs e)
        {
            if (tbAviableCurvers.Text != tbAviableCurvers.PlaceHolderText)
                _chart.AviableCurves.DefaultView.RowFilter = "Descr LIKE '%" + tbAviableCurvers.Text + "%'";
        }

        private void tbSelectedCurves_TextChanged(object sender, EventArgs e)
        {
            if (tbSelectedCurves.Text != tbSelectedCurves.PlaceHolderText)
                _chart.SelectedCurves.DefaultView.RowFilter = "Descr LIKE '%" + tbSelectedCurves.Text + "%'";
        }

        private void btnImportTags_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Excel Files | *.xlsx";
            DialogResult result = dlg.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = dlg.FileName;
                try
                {

                    dgvTags.DataSource = Utils.ReadExcelFile(file);
                    dgvTags.ReadOnly = false;
                    foreach (DataGridViewColumn col in dgvTags.Columns)
                    {
                        col.ReadOnly = true;
                    }
                    dgvTags.Columns[0].ReadOnly = false;

                    //TODO: There is strange bug with select all checkboxes when column is sortable
                    //dgvTags.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic; //

                    if (HeaderCheckBox == null)
                    {
                        HeaderCheckBox = new CheckBox();
                        HeaderCheckBox.Size = new Size(15, 15);
                        dgvTags.Controls.Add(HeaderCheckBox);
                        HeaderCheckBox.CheckedChanged += cb_CheckedChanged;
                    }
                    HeaderCheckBox.Checked = false;
                    tabControl.SelectedIndex = 4;
                }
                catch (Exception)
                {
                    MessageBox.Show("Incorrect excel file. Only TIA portal export excel files are supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnRename_Click(object sender, EventArgs e)
        {
            InputDialog dialog = new InputDialog("Rename datalog", "Name", lbAviableCurves.GetItemText(lbAviableCurves.SelectedItem));
            dialog.TopMost = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string result_text = dialog.ResultText;
                _chart.RenameDataLog((int)lbAviableCurves.SelectedValue, result_text);
                _chart.SelectedCurves.Rows.Clear();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("CAUTION. All data for selected datalog will be DELETED. Continue?", "Confirmation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                _chart.DeleteDataLog((int)lbAviableCurves.SelectedValue);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            InputDialog dialog = new InputDialog("Add datalog", "Name", "");
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string result_text = dialog.ResultText;
                _chart.AddLogTag(result_text);
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Clipboard.SetText(Utils.ScriptText(_chart.AviableCurves));
            MessageBox.Show("Script text copied to clipboard.",
                            "INFO",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Utils.ScriptText(_chart.SelectedCurves));
            MessageBox.Show("Script text copied to clipboard.",
                            "INFO",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void pgCurvesList_Leave(object sender, EventArgs e)
        {
           _chart.SqlP.ForceDataReload = true;
        }

        #endregion

        #region Page Import tags

        CheckBox HeaderCheckBox = null;
        protected void cb_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgvTags.Rows)
                r.Cells[0].Value = ((CheckBox)sender).Checked;
            dgvTags.RefreshEdit();
        }

        private void ResetHeaderCheckBoxLocation(int ColumnIndex, int RowIndex)
        {
            //Get the column header cell bounds
            Rectangle oRectangle = this.dgvTags.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);
            Point oPoint = new Point
            {
                X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox.Width) / 2,
                Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox.Height) / 2 + 1
            };
            //Change the location of the CheckBox to make it stay on the header
            HeaderCheckBox.Location = oPoint;
        }

        private void dgvTags_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
                ResetHeaderCheckBoxLocation(e.ColumnIndex, e.RowIndex);
        }

        private void tbNameFilter_TextChanged(object sender, EventArgs e)
        {
            if (tbNameFilter.Text != tbNameFilter.PlaceHolderText)
                (dgvTags.DataSource as DataTable).DefaultView.RowFilter = "Name LIKE '%" + tbNameFilter.Text + "%'";
        }

        private void btnCreateDataLog_Click(object sender, EventArgs e)
        {
            string str50; // in table LogNames we have column Descr nvarchar(50)
            List<string> l = new List<string>();
            foreach (DataGridViewRow row in dgvTags.Rows)
            {
                if ((bool)row.Cells[0].Value)
                {
                    str50 = Utils.Truncate(row.Cells[1].Value.ToString(), 50);
                    l.Add(str50);
                }
            }
            tabControl.SelectedIndex = 2;
            int nrows = _chart.AddLogTag(l);
            MessageBox.Show(nrows.ToString() + " Datalogs was added", "INFORMATION",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }



        #endregion

        #region Page Settings
        private void ODBCSourceAdd_Click(object sender, EventArgs e)
        {
            Utils.ODBCSourceAdd(Properties.Settings.Default.SERVER);
            MessageBox.Show("Added ODBC Datasource with name winccf",
                "INFO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnApplyConn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SERVER = cmbServerName.Text;
            Properties.Settings.Default.Save();
            if (_chart.Connect(Properties.Settings.Default.SERVER))
            {
                EnableCtrls();
            }
        }

        private void btnFindServers_Click(object sender, EventArgs e)
        {
            string myServer = Environment.MachineName;
            cmbServerName.Enabled = false;
            cmbServerName.DroppedDown = false;
            btnFindServers.Enabled = false;
            cmbServerName.Text = "Searching for local servers...";

            BackgroundWorker bgvGetLocServ = new BackgroundWorker();
            bgvGetLocServ.WorkerSupportsCancellation = true;
            bgvGetLocServ.DoWork += startSearchingForLocalServers;
            bgvGetLocServ.RunWorkerCompleted += ListOfAviableServers;
            bgvGetLocServ.RunWorkerAsync();
        }

        private void startSearchingForLocalServers(object sender, DoWorkEventArgs e)
        {
            List<string> AviableServers = new List<string>();
            string myServer = Environment.MachineName;
            foreach (DataRow r in _chart.GetLocalServers().Rows)
            {
                if (myServer == r["ServerName"].ToString()) ///// used to get the servers in the local machine////
                {
                    if ((r["InstanceName"] as string) != null)
                        AviableServers.Add(r["ServerName"] + "\\" + r["InstanceName"]);
                    else
                        AviableServers.Add(r["ServerName"].ToString());
                }
            }
            e.Result = AviableServers;
        }

        private void ListOfAviableServers(object sender, RunWorkerCompletedEventArgs e)
        {
            List<string> result = (List<string>)e.Result;
            cmbServerName.DataSource = result;
            cmbServerName.Enabled = true;
            cmbServerName.DroppedDown = true;
            btnFindServers.Enabled = true;
        }

        private void btnSetupDB_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("CAUTION. This will DELETE all data and rebuild database. Continue?", "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                _chart.SetupDB(cmbServerName.Text);
            }

        }

        private void btnBackupDB_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "SQL SERVER database backup files|*.bak";
            DialogResult result = dlg.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                try
                {
                    _chart.BackUpDB(dlg.FileName);
                    MessageBox.Show("Database successfully backuped\r\n" + dlg.FileName, "INFORMATION",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        #region Restore DB

        private void btnRestoreDB_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "SQL SERVER database backup files|*.bak";
            DialogResult result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                BackgroundWorker bgvRestoreDB = new BackgroundWorker();
                Progress = new ProgressForm();
                Progress.Message = "DB restore in progress, please wait...";
                Progress.Canceled += new EventHandler<EventArgs>(buttonCancel_Click);

                bgvRestoreDB.WorkerSupportsCancellation = true;
                bgvRestoreDB.DoWork += startbgvRestoreDB;
                bgvRestoreDB.RunWorkerCompleted += RestoreDB_Completed;
                bgvRestoreDB.RunWorkerAsync(dlg.FileName);
                Progress.ShowDialog();
            }
        }

        private void startbgvRestoreDB(object sender, DoWorkEventArgs e)
        {
            _chart.RestoreDB((string)e.Argument);
        }

        private void RestoreDB_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            // check error, check cancel, then use result
            if (e.Error != null)
            {
                Progress.Message = "ERROR:" + e.Error.ToString();
            }
            else if (e.Cancelled)
            {
                Progress.Message = "Database restore cancelled";
            }
            else
            {
                Progress.Message = "Database successfully restored.\nPlease RESTART program.";
                Progress.Done = true;
            }
            // general cleanup code, runs when there was an error or not.
        }

        // This event handler cancels the backgroundworker, fired from Cancel button in AlertForm.
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //TODO: Put thread inside a thread to be able cancel DB operation.

            //if (bgvRestoreDB.WorkerSupportsCancellation == true & bgvRestoreDB.IsBusy == true)
            //{
            //    bgvRestoreDB.CancelAsync();
            //}
        }
        #endregion

        #endregion

        #region MainForm Events
        private void MainForm_Load(object sender, EventArgs e)
        {
            Location = Properties.Settings.Default.MFRM_LOC;
            Size = Properties.Settings.Default.MFRM_SIZE;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                // save location and size if the state is normal
                Properties.Settings.Default.MFRM_LOC = Location;
                Properties.Settings.Default.MFRM_SIZE = Size;
                Properties.Settings.Default.Save();
            }
        }
        #endregion


    }
}





