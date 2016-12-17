namespace RLReplayManager
{
    partial class ReplayManagerForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReplayManagerForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateAPIKeyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.APIKeyTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.autoUploadNewReplaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.UploadButton = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.OrangeGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.BlueGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.UploadProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.UploadStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ReplayGridView = new System.Windows.Forms.DataGridView();
            this.ErrorTextBox = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrangeGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueGridView)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReplayGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(956, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpdateAPIKeyMenuItem,
            this.autoUploadNewReplaysToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // UpdateAPIKeyMenuItem
            // 
            this.UpdateAPIKeyMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.APIKeyTextBox});
            this.UpdateAPIKeyMenuItem.Name = "UpdateAPIKeyMenuItem";
            this.UpdateAPIKeyMenuItem.Size = new System.Drawing.Size(211, 22);
            this.UpdateAPIKeyMenuItem.Text = "Update API Key";
            // 
            // APIKeyTextBox
            // 
            this.APIKeyTextBox.Name = "APIKeyTextBox";
            this.APIKeyTextBox.Size = new System.Drawing.Size(300, 23);
            this.APIKeyTextBox.TextChanged += new System.EventHandler(this.APIKeyTextBox_TextChanged);
            // 
            // autoUploadNewReplaysToolStripMenuItem
            // 
            this.autoUploadNewReplaysToolStripMenuItem.CheckOnClick = true;
            this.autoUploadNewReplaysToolStripMenuItem.Name = "autoUploadNewReplaysToolStripMenuItem";
            this.autoUploadNewReplaysToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.autoUploadNewReplaysToolStripMenuItem.Text = "Auto Upload New Replays";
            this.autoUploadNewReplaysToolStripMenuItem.CheckedChanged += new System.EventHandler(this.autoUploadNewReplaysToolStripMenuItem_CheckedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UploadButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(956, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // UploadButton
            // 
            this.UploadButton.Image = ((System.Drawing.Image)(resources.GetObject("UploadButton.Image")));
            this.UploadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(65, 22);
            this.UploadButton.Text = "Upload";
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(956, 692);
            this.splitContainer1.SplitterDistance = 499;
            this.splitContainer1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(956, 499);
            this.dataGridView1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.BlueGridView);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.OrangeGridView);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Size = new System.Drawing.Size(956, 189);
            this.splitContainer2.SplitterDistance = 470;
            this.splitContainer2.TabIndex = 0;
            // 
            // OrangeGridView
            // 
            this.OrangeGridView.AllowUserToAddRows = false;
            this.OrangeGridView.AllowUserToDeleteRows = false;
            this.OrangeGridView.AllowUserToResizeRows = false;
            this.OrangeGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.OrangeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrangeGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrangeGridView.Location = new System.Drawing.Point(0, 33);
            this.OrangeGridView.Name = "OrangeGridView";
            this.OrangeGridView.ReadOnly = true;
            this.OrangeGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OrangeGridView.Size = new System.Drawing.Size(482, 156);
            this.OrangeGridView.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Orange";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BlueGridView
            // 
            this.BlueGridView.AllowUserToAddRows = false;
            this.BlueGridView.AllowUserToDeleteRows = false;
            this.BlueGridView.AllowUserToResizeRows = false;
            this.BlueGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.BlueGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BlueGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BlueGridView.Location = new System.Drawing.Point(0, 33);
            this.BlueGridView.Name = "BlueGridView";
            this.BlueGridView.ReadOnly = true;
            this.BlueGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.BlueGridView.Size = new System.Drawing.Size(470, 156);
            this.BlueGridView.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 33);
            this.label2.TabIndex = 0;
            this.label2.Text = "Blue";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UploadProgressBar,
            this.UploadStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 719);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(956, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // UploadProgressBar
            // 
            this.UploadProgressBar.Name = "UploadProgressBar";
            this.UploadProgressBar.Size = new System.Drawing.Size(100, 16);
            this.UploadProgressBar.Visible = false;
            // 
            // UploadStatusLabel
            // 
            this.UploadStatusLabel.Name = "UploadStatusLabel";
            this.UploadStatusLabel.Size = new System.Drawing.Size(0, 17);
            this.UploadStatusLabel.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(956, 499);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ReplayGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(948, 473);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Replays";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ErrorTextBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(948, 473);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Errors and Crap";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ReplayGridView
            // 
            this.ReplayGridView.AllowUserToAddRows = false;
            this.ReplayGridView.AllowUserToDeleteRows = false;
            this.ReplayGridView.AllowUserToResizeRows = false;
            this.ReplayGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ReplayGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReplayGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReplayGridView.Location = new System.Drawing.Point(3, 3);
            this.ReplayGridView.Name = "ReplayGridView";
            this.ReplayGridView.ReadOnly = true;
            this.ReplayGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ReplayGridView.Size = new System.Drawing.Size(942, 467);
            this.ReplayGridView.TabIndex = 2;
            this.ReplayGridView.SelectionChanged += new System.EventHandler(this.ReplayGridView_SelectionChanged);
            // 
            // ErrorTextBox
            // 
            this.ErrorTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ErrorTextBox.Location = new System.Drawing.Point(3, 3);
            this.ErrorTextBox.Multiline = true;
            this.ErrorTextBox.Name = "ErrorTextBox";
            this.ErrorTextBox.Size = new System.Drawing.Size(942, 467);
            this.ErrorTextBox.TabIndex = 0;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "RL Replay Manager";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // ReplayManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 741);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ReplayManagerForm";
            this.Text = "Replay Manager";
            this.Load += new System.EventHandler(this.ReplayManagerForm_Load);
            this.Resize += new System.EventHandler(this.ReplayManagerForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OrangeGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueGridView)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReplayGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton UploadButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView OrangeGridView;
        private System.Windows.Forms.DataGridView BlueGridView;
        private System.Windows.Forms.ToolStripMenuItem UpdateAPIKeyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoUploadNewReplaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox APIKeyTextBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar UploadProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel UploadStatusLabel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView ReplayGridView;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox ErrorTextBox;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

