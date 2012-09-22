namespace QuickStore
{
	partial class Main
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.btnOpen = new System.Windows.Forms.Button();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.btnAnalyze = new System.Windows.Forms.Button();
			this.btnRun = new System.Windows.Forms.Button();
			this.tbConsole = new System.Windows.Forms.TextBox();
			this.btnNext = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.pbProgress = new System.Windows.Forms.ToolStripProgressBar();
			this.tbNumStores = new System.Windows.Forms.ToolStripStatusLabel();
			this.label2 = new System.Windows.Forms.Label();
			this.tbFileName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cbCustomer = new System.Windows.Forms.ComboBox();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOpen
			// 
			this.btnOpen.Enabled = false;
			this.btnOpen.Location = new System.Drawing.Point(16, 38);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(80, 23);
			this.btnOpen.TabIndex = 0;
			this.btnOpen.Text = "Open CSV";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "CSV (Comma delimited)|*.csv";
			// 
			// btnAnalyze
			// 
			this.btnAnalyze.Enabled = false;
			this.btnAnalyze.Location = new System.Drawing.Point(16, 68);
			this.btnAnalyze.Name = "btnAnalyze";
			this.btnAnalyze.Size = new System.Drawing.Size(80, 23);
			this.btnAnalyze.TabIndex = 4;
			this.btnAnalyze.Text = "Analyze";
			this.btnAnalyze.UseVisualStyleBackColor = true;
			this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
			// 
			// btnRun
			// 
			this.btnRun.Enabled = false;
			this.btnRun.Location = new System.Drawing.Point(102, 68);
			this.btnRun.Name = "btnRun";
			this.btnRun.Size = new System.Drawing.Size(80, 23);
			this.btnRun.TabIndex = 4;
			this.btnRun.Text = "Run";
			this.btnRun.UseVisualStyleBackColor = true;
			this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
			// 
			// tbConsole
			// 
			this.tbConsole.BackColor = System.Drawing.SystemColors.Window;
			this.tbConsole.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbConsole.ForeColor = System.Drawing.SystemColors.WindowText;
			this.tbConsole.Location = new System.Drawing.Point(12, 97);
			this.tbConsole.Multiline = true;
			this.tbConsole.Name = "tbConsole";
			this.tbConsole.ReadOnly = true;
			this.tbConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbConsole.Size = new System.Drawing.Size(260, 139);
			this.tbConsole.TabIndex = 5;
			// 
			// btnNext
			// 
			this.btnNext.Enabled = false;
			this.btnNext.Location = new System.Drawing.Point(188, 68);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(80, 23);
			this.btnNext.TabIndex = 4;
			this.btnNext.Text = "Next";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pbProgress,
            this.tbNumStores});
			this.statusStrip1.Location = new System.Drawing.Point(0, 240);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(284, 22);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 6;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// pbProgress
			// 
			this.pbProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.pbProgress.Name = "pbProgress";
			this.pbProgress.Size = new System.Drawing.Size(205, 16);
			this.pbProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			// 
			// tbNumStores
			// 
			this.tbNumStores.Name = "tbNumStores";
			this.tbNumStores.Size = new System.Drawing.Size(72, 17);
			this.tbNumStores.Text = " 0000 / 9999 ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(83, 262);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "label2";
			// 
			// tbFileName
			// 
			this.tbFileName.Enabled = false;
			this.tbFileName.Location = new System.Drawing.Point(104, 41);
			this.tbFileName.Name = "tbFileName";
			this.tbFileName.ReadOnly = true;
			this.tbFileName.Size = new System.Drawing.Size(168, 20);
			this.tbFileName.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Customer Group:";
			// 
			// cbCustomer
			// 
			this.cbCustomer.FormattingEnabled = true;
			this.cbCustomer.Items.AddRange(new object[] {
            "ConAgra Foods",
            "Farmer John",
            "Jennie-O Turkey Store",
            "PepsiCo Warehouse Sales",
            "Timex"});
			this.cbCustomer.Location = new System.Drawing.Point(104, 12);
			this.cbCustomer.Name = "cbCustomer";
			this.cbCustomer.Size = new System.Drawing.Size(168, 21);
			this.cbCustomer.TabIndex = 8;
			this.cbCustomer.SelectedIndexChanged += new System.EventHandler(this.cbCustomer_SelectedIndexChanged);
			// 
			// Main
			// 
			this.AcceptButton = this.btnNext;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbCustomer);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.tbConsole);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnRun);
			this.Controls.Add(this.btnAnalyze);
			this.Controls.Add(this.tbFileName);
			this.Controls.Add(this.btnOpen);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Main";
			this.Text = "Quick Store";
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.Button btnAnalyze;
		private System.Windows.Forms.Button btnRun;
		private System.Windows.Forms.TextBox tbConsole;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel tbNumStores;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolStripProgressBar pbProgress;
		private System.Windows.Forms.TextBox tbFileName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbCustomer;
	}
}

