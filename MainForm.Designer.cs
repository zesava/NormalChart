namespace NormalChart
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose ();
			}
			base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbtnShowChart = new System.Windows.Forms.ToolStripButton();
            this.tbtnShowTable = new System.Windows.Forms.ToolStripButton();
            this.tbtnCurves = new System.Windows.Forms.ToolStripButton();
            this.tbtnCSV = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnBack = new System.Windows.Forms.ToolStripButton();
            this.tbtnResolution = new System.Windows.Forms.ToolStripComboBox();
            this.tbtnForward = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnAbout = new System.Windows.Forms.ToolStripButton();
            this.tbtnSettings = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tmrLoading = new System.Windows.Forms.Timer(this.components);
            this.tabControl = new TablessControl();
            this.pgChart = new System.Windows.Forms.TabPage();
            this.lblLoading = new System.Windows.Forms.Label();
            this.zedGraph = new ZedGraph.ZedGraphControl();
            this.pgTable = new System.Windows.Forms.TabPage();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.pgCurvesList = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnRemAllCurves = new System.Windows.Forms.Button();
            this.btnRemoveCurve = new System.Windows.Forms.Button();
            this.btnAddCurve = new System.Windows.Forms.Button();
            this.tbAviableCurvers = new NormalChart.PlaceHolderTextBox();
            this.tbSelectedCurves = new NormalChart.PlaceHolderTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.lbAviableCurves = new NormalChart.CustomListBox();
            this.lbSelectedCurves = new NormalChart.CustomListBox();
            this.btnImportTags = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pgSettings = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnODBCSourceAdd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFindServers = new System.Windows.Forms.Button();
            this.btnRestoreDB = new System.Windows.Forms.Button();
            this.btnBackupDB = new System.Windows.Forms.Button();
            this.btnSetupDB = new System.Windows.Forms.Button();
            this.cmbServerName = new System.Windows.Forms.ComboBox();
            this.btnApplyConn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pgImport = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvTags = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCreateDataLog = new System.Windows.Forms.Button();
            this.tbNameFilter = new NormalChart.PlaceHolderTextBox();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.pgChart.SuspendLayout();
            this.pgTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.pgCurvesList.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pgSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pgImport.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTags)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnShowChart,
            this.tbtnShowTable,
            this.tbtnCurves,
            this.tbtnCSV,
            this.toolStripSeparator1,
            this.tbtnBack,
            this.tbtnResolution,
            this.tbtnForward,
            this.toolStripSeparator2,
            this.tbtnAbout,
            this.tbtnSettings});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(789, 40);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbtnShowChart
            // 
            this.tbtnShowChart.AutoSize = false;
            this.tbtnShowChart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnShowChart.Image = ((System.Drawing.Image)(resources.GetObject("tbtnShowChart.Image")));
            this.tbtnShowChart.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtnShowChart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnShowChart.Name = "tbtnShowChart";
            this.tbtnShowChart.Size = new System.Drawing.Size(50, 37);
            this.tbtnShowChart.Text = "Chart";
            this.tbtnShowChart.Click += new System.EventHandler(this.tbtnShowChart_Click);
            // 
            // tbtnShowTable
            // 
            this.tbtnShowTable.AutoSize = false;
            this.tbtnShowTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnShowTable.Image = ((System.Drawing.Image)(resources.GetObject("tbtnShowTable.Image")));
            this.tbtnShowTable.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtnShowTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnShowTable.Name = "tbtnShowTable";
            this.tbtnShowTable.Size = new System.Drawing.Size(50, 37);
            this.tbtnShowTable.Text = "Table";
            this.tbtnShowTable.Click += new System.EventHandler(this.tbtnShowTable_Click);
            // 
            // tbtnCurves
            // 
            this.tbtnCurves.AutoSize = false;
            this.tbtnCurves.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnCurves.Image = ((System.Drawing.Image)(resources.GetObject("tbtnCurves.Image")));
            this.tbtnCurves.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtnCurves.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnCurves.Name = "tbtnCurves";
            this.tbtnCurves.Size = new System.Drawing.Size(50, 37);
            this.tbtnCurves.Text = "Curves";
            this.tbtnCurves.Click += new System.EventHandler(this.tbtnCurves_Click);
            // 
            // tbtnCSV
            // 
            this.tbtnCSV.AutoSize = false;
            this.tbtnCSV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnCSV.Image = ((System.Drawing.Image)(resources.GetObject("tbtnCSV.Image")));
            this.tbtnCSV.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtnCSV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnCSV.Name = "tbtnCSV";
            this.tbtnCSV.Size = new System.Drawing.Size(50, 37);
            this.tbtnCSV.Text = "Export CSV";
            this.tbtnCSV.Click += new System.EventHandler(this.tbtnCSV_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // tbtnBack
            // 
            this.tbtnBack.AutoSize = false;
            this.tbtnBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnBack.Image = ((System.Drawing.Image)(resources.GetObject("tbtnBack.Image")));
            this.tbtnBack.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtnBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnBack.Name = "tbtnBack";
            this.tbtnBack.Size = new System.Drawing.Size(50, 37);
            this.tbtnBack.Text = "toolStripButton1";
            this.tbtnBack.Click += new System.EventHandler(this.tbtnBack_Click);
            // 
            // tbtnResolution
            // 
            this.tbtnResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbtnResolution.Items.AddRange(new object[] {
            "15 min",
            "30 min",
            "1 hour",
            "12 hours",
            "1 day"});
            this.tbtnResolution.Name = "tbtnResolution";
            this.tbtnResolution.Size = new System.Drawing.Size(75, 40);
            this.tbtnResolution.SelectedIndex = 0;
            this.tbtnResolution.SelectedIndexChanged += new System.EventHandler(this.tbtnResolution_SelectedIndexChanged);
            // 
            // tbtnForward
            // 
            this.tbtnForward.AutoSize = false;
            this.tbtnForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnForward.Image = ((System.Drawing.Image)(resources.GetObject("tbtnForward.Image")));
            this.tbtnForward.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtnForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnForward.Name = "tbtnForward";
            this.tbtnForward.Size = new System.Drawing.Size(50, 37);
            this.tbtnForward.Text = "toolStripButton1";
            this.tbtnForward.Click += new System.EventHandler(this.tbtnForward_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // tbtnAbout
            // 
            this.tbtnAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbtnAbout.AutoSize = false;
            this.tbtnAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnAbout.Image = ((System.Drawing.Image)(resources.GetObject("tbtnAbout.Image")));
            this.tbtnAbout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnAbout.Name = "tbtnAbout";
            this.tbtnAbout.Size = new System.Drawing.Size(50, 37);
            this.tbtnAbout.Text = "toolStripButton2";
            this.tbtnAbout.Click += new System.EventHandler(this.tbtnAbout_Click);
            // 
            // tbtnSettings
            // 
            this.tbtnSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbtnSettings.AutoSize = false;
            this.tbtnSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnSettings.Image = ((System.Drawing.Image)(resources.GetObject("tbtnSettings.Image")));
            this.tbtnSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbtnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnSettings.Name = "tbtnSettings";
            this.tbtnSettings.Size = new System.Drawing.Size(50, 37);
            this.tbtnSettings.Text = "toolStripButton1";
            this.tbtnSettings.Click += new System.EventHandler(this.tbtnSettings_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(789, 413);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // tmrLoading
            // 
            this.tmrLoading.Tick += new System.EventHandler(this.tmrLoading_Tick);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.pgChart);
            this.tabControl.Controls.Add(this.pgTable);
            this.tabControl.Controls.Add(this.pgCurvesList);
            this.tabControl.Controls.Add(this.pgSettings);
            this.tabControl.Controls.Add(this.pgImport);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 40);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(0, 0);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(789, 373);
            this.tabControl.TabIndex = 8;
            // 
            // pgChart
            // 
            this.pgChart.Controls.Add(this.lblLoading);
            this.pgChart.Controls.Add(this.zedGraph);
            this.pgChart.Location = new System.Drawing.Point(4, 22);
            this.pgChart.Name = "pgChart";
            this.pgChart.Size = new System.Drawing.Size(781, 347);
            this.pgChart.TabIndex = 0;
            this.pgChart.Text = "Chart";
            // 
            // lblLoading
            // 
            this.lblLoading.BackColor = System.Drawing.Color.Transparent;
            this.lblLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLoading.ForeColor = System.Drawing.Color.Black;
            this.lblLoading.Location = new System.Drawing.Point(332, 146);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(153, 27);
            this.lblLoading.TabIndex = 4;
            this.lblLoading.Text = "Loading data...";
            this.lblLoading.Visible = false;
            // 
            // zedGraph
            // 
            this.zedGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraph.Location = new System.Drawing.Point(0, 0);
            this.zedGraph.Name = "zedGraph";
            this.zedGraph.ScrollGrace = 0D;
            this.zedGraph.ScrollMaxX = 0D;
            this.zedGraph.ScrollMaxY = 0D;
            this.zedGraph.ScrollMaxY2 = 0D;
            this.zedGraph.ScrollMinX = 0D;
            this.zedGraph.ScrollMinY = 0D;
            this.zedGraph.ScrollMinY2 = 0D;
            this.zedGraph.Size = new System.Drawing.Size(781, 347);
            this.zedGraph.TabIndex = 3;
            this.zedGraph.UseExtendedPrintDialog = true;
            // 
            // pgTable
            // 
            this.pgTable.Controls.Add(this.dataGridView);
            this.pgTable.Location = new System.Drawing.Point(4, 22);
            this.pgTable.Name = "pgTable";
            this.pgTable.Size = new System.Drawing.Size(781, 347);
            this.pgTable.TabIndex = 1;
            this.pgTable.Text = "Table";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(781, 347);
            this.dataGridView.TabIndex = 2;
            // 
            // pgCurvesList
            // 
            this.pgCurvesList.Controls.Add(this.tableLayoutPanel2);
            this.pgCurvesList.Location = new System.Drawing.Point(4, 22);
            this.pgCurvesList.Name = "pgCurvesList";
            this.pgCurvesList.Padding = new System.Windows.Forms.Padding(3);
            this.pgCurvesList.Size = new System.Drawing.Size(781, 347);
            this.pgCurvesList.TabIndex = 2;
            this.pgCurvesList.Text = "Curves";
            this.pgCurvesList.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbAviableCurvers, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbSelectedCurves, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbAviableCurves, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbSelectedCurves, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnImportTags, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.button3, 2, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(775, 341);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.btnApply, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.btnRemAllCurves, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.btnRemoveCurve, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnAddCurve, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(290, 33);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(194, 270);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnApply.Location = new System.Drawing.Point(59, 183);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "APPLY";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnRemAllCurves
            // 
            this.btnRemAllCurves.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRemAllCurves.Location = new System.Drawing.Point(59, 88);
            this.btnRemAllCurves.Name = "btnRemAllCurves";
            this.btnRemAllCurves.Size = new System.Drawing.Size(75, 23);
            this.btnRemAllCurves.TabIndex = 2;
            this.btnRemAllCurves.Text = "<<";
            this.btnRemAllCurves.UseVisualStyleBackColor = true;
            this.btnRemAllCurves.Click += new System.EventHandler(this.btnRemAllCurves_Click);
            // 
            // btnRemoveCurve
            // 
            this.btnRemoveCurve.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRemoveCurve.Location = new System.Drawing.Point(59, 48);
            this.btnRemoveCurve.Name = "btnRemoveCurve";
            this.btnRemoveCurve.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveCurve.TabIndex = 1;
            this.btnRemoveCurve.Text = "<";
            this.btnRemoveCurve.UseVisualStyleBackColor = true;
            this.btnRemoveCurve.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAddCurve
            // 
            this.btnAddCurve.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddCurve.Location = new System.Drawing.Point(59, 8);
            this.btnAddCurve.Name = "btnAddCurve";
            this.btnAddCurve.Size = new System.Drawing.Size(75, 23);
            this.btnAddCurve.TabIndex = 0;
            this.btnAddCurve.Text = ">";
            this.btnAddCurve.UseVisualStyleBackColor = true;
            this.btnAddCurve.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbAviableCurvers
            // 
            this.tbAviableCurvers.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbAviableCurvers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tbAviableCurvers.ForeColor = System.Drawing.Color.Gray;
            this.tbAviableCurvers.Location = new System.Drawing.Point(3, 5);
            this.tbAviableCurvers.Name = "tbAviableCurvers";
            this.tbAviableCurvers.PlaceHolderText = "Aviable curvers";
            this.tbAviableCurvers.Size = new System.Drawing.Size(158, 20);
            this.tbAviableCurvers.TabIndex = 5;
            this.tbAviableCurvers.Text = "Aviable curves";
            this.tbAviableCurvers.TextChanged += new System.EventHandler(this.tbAviableCurvers_TextChanged);
            // 
            // tbSelectedCurves
            // 
            this.tbSelectedCurves.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbSelectedCurves.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tbSelectedCurves.ForeColor = System.Drawing.Color.Gray;
            this.tbSelectedCurves.Location = new System.Drawing.Point(490, 5);
            this.tbSelectedCurves.Name = "tbSelectedCurves";
            this.tbSelectedCurves.PlaceHolderText = "Displayed curves";
            this.tbSelectedCurves.Size = new System.Drawing.Size(171, 20);
            this.tbSelectedCurves.TabIndex = 6;
            this.tbSelectedCurves.Text = "Displayed curves";
            this.tbSelectedCurves.TextChanged += new System.EventHandler(this.tbSelectedCurves_TextChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.btnRename);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 306);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(287, 35);
            this.panel3.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.Location = new System.Drawing.Point(206, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "WinCC Script";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAdd.Location = new System.Drawing.Point(5, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(61, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnDelete.Location = new System.Drawing.Point(139, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(61, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRename
            // 
            this.btnRename.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRename.Location = new System.Drawing.Point(72, 6);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(61, 23);
            this.btnRename.TabIndex = 8;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // lbAviableCurves
            // 
            this.lbAviableCurves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAviableCurves.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbAviableCurves.FormattingEnabled = true;
            this.lbAviableCurves.ItemHeight = 18;
            this.lbAviableCurves.Location = new System.Drawing.Point(3, 33);
            this.lbAviableCurves.Name = "lbAviableCurves";
            this.lbAviableCurves.Size = new System.Drawing.Size(281, 270);
            this.lbAviableCurves.TabIndex = 10;
            // 
            // lbSelectedCurves
            // 
            this.lbSelectedCurves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSelectedCurves.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbSelectedCurves.FormattingEnabled = true;
            this.lbSelectedCurves.ItemHeight = 18;
            this.lbSelectedCurves.Location = new System.Drawing.Point(490, 33);
            this.lbSelectedCurves.Name = "lbSelectedCurves";
            this.lbSelectedCurves.Size = new System.Drawing.Size(282, 270);
            this.lbSelectedCurves.TabIndex = 11;
            // 
            // btnImportTags
            // 
            this.btnImportTags.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnImportTags.Location = new System.Drawing.Point(349, 311);
            this.btnImportTags.Name = "btnImportTags";
            this.btnImportTags.Size = new System.Drawing.Size(75, 24);
            this.btnImportTags.TabIndex = 7;
            this.btnImportTags.Text = "Import tags";
            this.btnImportTags.UseVisualStyleBackColor = true;
            this.btnImportTags.Click += new System.EventHandler(this.btnImportTags_Click);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button3.Location = new System.Drawing.Point(490, 312);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(78, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "WinCC Script";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pgSettings
            // 
            this.pgSettings.Controls.Add(this.groupBox2);
            this.pgSettings.Controls.Add(this.groupBox1);
            this.pgSettings.Location = new System.Drawing.Point(4, 22);
            this.pgSettings.Name = "pgSettings";
            this.pgSettings.Padding = new System.Windows.Forms.Padding(3);
            this.pgSettings.Size = new System.Drawing.Size(781, 347);
            this.pgSettings.TabIndex = 3;
            this.pgSettings.Text = "Settings";
            this.pgSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnODBCSourceAdd);
            this.groupBox2.Location = new System.Drawing.Point(292, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(271, 257);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "WinCC";
            // 
            // btnODBCSourceAdd
            // 
            this.btnODBCSourceAdd.Location = new System.Drawing.Point(30, 74);
            this.btnODBCSourceAdd.Name = "btnODBCSourceAdd";
            this.btnODBCSourceAdd.Size = new System.Drawing.Size(90, 23);
            this.btnODBCSourceAdd.TabIndex = 6;
            this.btnODBCSourceAdd.Text = "Add ODBC";
            this.btnODBCSourceAdd.UseVisualStyleBackColor = true;
            this.btnODBCSourceAdd.Click += new System.EventHandler(this.ODBCSourceAdd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFindServers);
            this.groupBox1.Controls.Add(this.btnRestoreDB);
            this.groupBox1.Controls.Add(this.btnBackupDB);
            this.groupBox1.Controls.Add(this.btnSetupDB);
            this.groupBox1.Controls.Add(this.cmbServerName);
            this.groupBox1.Controls.Add(this.btnApplyConn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 257);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MSSQL";
            // 
            // btnFindServers
            // 
            this.btnFindServers.Location = new System.Drawing.Point(30, 72);
            this.btnFindServers.Name = "btnFindServers";
            this.btnFindServers.Size = new System.Drawing.Size(90, 23);
            this.btnFindServers.TabIndex = 15;
            this.btnFindServers.Text = "Find servers";
            this.btnFindServers.UseVisualStyleBackColor = true;
            this.btnFindServers.Click += new System.EventHandler(this.btnFindServers_Click);
            // 
            // btnRestoreDB
            // 
            this.btnRestoreDB.Location = new System.Drawing.Point(30, 209);
            this.btnRestoreDB.Name = "btnRestoreDB";
            this.btnRestoreDB.Size = new System.Drawing.Size(90, 23);
            this.btnRestoreDB.TabIndex = 14;
            this.btnRestoreDB.Text = "Restore DB";
            this.btnRestoreDB.UseVisualStyleBackColor = true;
            this.btnRestoreDB.Click += new System.EventHandler(this.btnRestoreDB_Click);
            // 
            // btnBackupDB
            // 
            this.btnBackupDB.Location = new System.Drawing.Point(30, 180);
            this.btnBackupDB.Name = "btnBackupDB";
            this.btnBackupDB.Size = new System.Drawing.Size(90, 23);
            this.btnBackupDB.TabIndex = 13;
            this.btnBackupDB.Text = "Backup DB";
            this.btnBackupDB.UseVisualStyleBackColor = true;
            this.btnBackupDB.Click += new System.EventHandler(this.btnBackupDB_Click);
            // 
            // btnSetupDB
            // 
            this.btnSetupDB.Location = new System.Drawing.Point(30, 139);
            this.btnSetupDB.Name = "btnSetupDB";
            this.btnSetupDB.Size = new System.Drawing.Size(90, 23);
            this.btnSetupDB.TabIndex = 6;
            this.btnSetupDB.Text = "Setup DB";
            this.btnSetupDB.UseVisualStyleBackColor = true;
            this.btnSetupDB.Click += new System.EventHandler(this.btnSetupDB_Click);
            // 
            // cmbServerName
            // 
            this.cmbServerName.FormattingEnabled = true;
            this.cmbServerName.Location = new System.Drawing.Point(30, 45);
            this.cmbServerName.Name = "cmbServerName";
            this.cmbServerName.Size = new System.Drawing.Size(213, 21);
            this.cmbServerName.TabIndex = 1;
            // 
            // btnApplyConn
            // 
            this.btnApplyConn.Location = new System.Drawing.Point(153, 72);
            this.btnApplyConn.Name = "btnApplyConn";
            this.btnApplyConn.Size = new System.Drawing.Size(90, 23);
            this.btnApplyConn.TabIndex = 4;
            this.btnApplyConn.Text = "Apply";
            this.btnApplyConn.UseVisualStyleBackColor = true;
            this.btnApplyConn.Click += new System.EventHandler(this.btnApplyConn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Server";
            // 
            // pgImport
            // 
            this.pgImport.BackColor = System.Drawing.SystemColors.Control;
            this.pgImport.Controls.Add(this.panel2);
            this.pgImport.Controls.Add(this.panel1);
            this.pgImport.Location = new System.Drawing.Point(4, 22);
            this.pgImport.Name = "pgImport";
            this.pgImport.Padding = new System.Windows.Forms.Padding(3);
            this.pgImport.Size = new System.Drawing.Size(781, 347);
            this.pgImport.TabIndex = 4;
            this.pgImport.Text = "Import Tags";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvTags);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(775, 295);
            this.panel2.TabIndex = 1;
            // 
            // dgvTags
            // 
            this.dgvTags.AllowUserToAddRows = false;
            this.dgvTags.AllowUserToDeleteRows = false;
            this.dgvTags.AllowUserToResizeRows = false;
            this.dgvTags.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTags.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTags.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTags.Location = new System.Drawing.Point(0, 0);
            this.dgvTags.MultiSelect = false;
            this.dgvTags.Name = "dgvTags";
            this.dgvTags.ReadOnly = true;
            this.dgvTags.RowHeadersVisible = false;
            this.dgvTags.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTags.Size = new System.Drawing.Size(775, 295);
            this.dgvTags.TabIndex = 3;
            this.dgvTags.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvTags_CellPainting);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnCreateDataLog);
            this.panel1.Controls.Add(this.tbNameFilter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 46);
            this.panel1.TabIndex = 0;
            // 
            // btnCreateDataLog
            // 
            this.btnCreateDataLog.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCreateDataLog.Location = new System.Drawing.Point(662, 3);
            this.btnCreateDataLog.Name = "btnCreateDataLog";
            this.btnCreateDataLog.Size = new System.Drawing.Size(107, 31);
            this.btnCreateDataLog.TabIndex = 2;
            this.btnCreateDataLog.Text = "CreateDataLog";
            this.btnCreateDataLog.UseVisualStyleBackColor = true;
            this.btnCreateDataLog.Click += new System.EventHandler(this.btnCreateDataLog_Click);
            // 
            // tbNameFilter
            // 
            this.tbNameFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tbNameFilter.ForeColor = System.Drawing.Color.Gray;
            this.tbNameFilter.Location = new System.Drawing.Point(5, 14);
            this.tbNameFilter.Name = "tbNameFilter";
            this.tbNameFilter.PlaceHolderText = "Name Filter...";
            this.tbNameFilter.Size = new System.Drawing.Size(100, 20);
            this.tbNameFilter.TabIndex = 0;
            this.tbNameFilter.Text = "Name Filter...";
            this.tbNameFilter.TextChanged += new System.EventHandler(this.tbNameFilter_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 413);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "Normal Chart";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.pgChart.ResumeLayout(false);
            this.pgTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.pgCurvesList.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.pgSettings.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pgImport.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTags)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbtnShowChart;
        private System.Windows.Forms.ToolStripButton tbtnShowTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private TablessControl tabControl;
        private System.Windows.Forms.TabPage pgChart;
        private System.Windows.Forms.TabPage pgTable;
        private ZedGraph.ZedGraphControl zedGraph;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStripButton tbtnCSV;
        private System.Windows.Forms.TabPage pgCurvesList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStripButton tbtnCurves;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnAddCurve;
        private System.Windows.Forms.Button btnRemAllCurves;
        private System.Windows.Forms.Button btnRemoveCurve;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ToolStripComboBox tbtnResolution;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbtnForward;
        private System.Windows.Forms.ToolStripButton tbtnBack;
        private System.Windows.Forms.TabPage pgSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tbtnSettings;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnApplyConn;
        private System.Windows.Forms.ComboBox cmbServerName;
        private System.Windows.Forms.Button btnSetupDB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabPage pgImport;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvTags;
        private PlaceHolderTextBox tbNameFilter;
        private System.Windows.Forms.Button btnCreateDataLog;
        private PlaceHolderTextBox tbAviableCurvers;
        private PlaceHolderTextBox tbSelectedCurves;
        private CustomListBox lbAviableCurves;
        private CustomListBox lbSelectedCurves;
        private System.Windows.Forms.Button btnODBCSourceAdd;
        private System.Windows.Forms.Button btnRestoreDB;
        private System.Windows.Forms.Button btnBackupDB;
        private System.Windows.Forms.ToolStripButton tbtnAbout;
        private System.Windows.Forms.Button btnFindServers;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnImportTags;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.Timer tmrLoading;
    }
}

