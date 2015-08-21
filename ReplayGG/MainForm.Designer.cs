namespace ReplayGG
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.DownloadReplayGroup = new System.Windows.Forms.GroupBox();
            this.DownloadReplayProgress = new System.Windows.Forms.ProgressBar();
            this.DownloadReplayButton = new System.Windows.Forms.Button();
            this.DownloadReplayUrlText = new System.Windows.Forms.TextBox();
            this.DownloadReplayUrlLabel = new System.Windows.Forms.Label();
            this.DownloadReplayStatusLabel = new System.Windows.Forms.Label();
            this.ManageReplaysGroup = new System.Windows.Forms.GroupBox();
            this.ManageReplaysDeleteButton = new System.Windows.Forms.Button();
            this.ManageReplaysLaunchReplayButton = new System.Windows.Forms.Button();
            this.ManageReplaysRefreshListButton = new System.Windows.Forms.Button();
            this.ManageReplaysList = new System.Windows.Forms.ListView();
            this.FilenameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CreationDateCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ManageReplaysStopLaunchButton = new System.Windows.Forms.Button();
            this.DownloadReplayGroup.SuspendLayout();
            this.ManageReplaysGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // DownloadReplayGroup
            // 
            this.DownloadReplayGroup.Controls.Add(this.DownloadReplayStatusLabel);
            this.DownloadReplayGroup.Controls.Add(this.DownloadReplayProgress);
            this.DownloadReplayGroup.Controls.Add(this.DownloadReplayButton);
            this.DownloadReplayGroup.Controls.Add(this.DownloadReplayUrlText);
            this.DownloadReplayGroup.Controls.Add(this.DownloadReplayUrlLabel);
            this.DownloadReplayGroup.Location = new System.Drawing.Point(12, 12);
            this.DownloadReplayGroup.Name = "DownloadReplayGroup";
            this.DownloadReplayGroup.Size = new System.Drawing.Size(473, 137);
            this.DownloadReplayGroup.TabIndex = 0;
            this.DownloadReplayGroup.TabStop = false;
            this.DownloadReplayGroup.Text = "Download Replay";
            // 
            // DownloadReplayProgress
            // 
            this.DownloadReplayProgress.Location = new System.Drawing.Point(22, 81);
            this.DownloadReplayProgress.Name = "DownloadReplayProgress";
            this.DownloadReplayProgress.Size = new System.Drawing.Size(436, 23);
            this.DownloadReplayProgress.TabIndex = 3;
            // 
            // DownloadReplayButton
            // 
            this.DownloadReplayButton.Location = new System.Drawing.Point(192, 52);
            this.DownloadReplayButton.Name = "DownloadReplayButton";
            this.DownloadReplayButton.Size = new System.Drawing.Size(75, 23);
            this.DownloadReplayButton.TabIndex = 2;
            this.DownloadReplayButton.Text = "Download Replay";
            this.DownloadReplayButton.UseVisualStyleBackColor = true;
            this.DownloadReplayButton.Click += new System.EventHandler(this.DownloadReplayButton_Click);
            // 
            // DownloadReplayUrlText
            // 
            this.DownloadReplayUrlText.Location = new System.Drawing.Point(130, 24);
            this.DownloadReplayUrlText.Name = "DownloadReplayUrlText";
            this.DownloadReplayUrlText.Size = new System.Drawing.Size(328, 22);
            this.DownloadReplayUrlText.TabIndex = 1;
            // 
            // DownloadReplayUrlLabel
            // 
            this.DownloadReplayUrlLabel.AutoSize = true;
            this.DownloadReplayUrlLabel.Location = new System.Drawing.Point(19, 27);
            this.DownloadReplayUrlLabel.Name = "DownloadReplayUrlLabel";
            this.DownloadReplayUrlLabel.Size = new System.Drawing.Size(105, 13);
            this.DownloadReplayUrlLabel.TabIndex = 0;
            this.DownloadReplayUrlLabel.Text = "Your replay.gg link:";
            // 
            // DownloadReplayStatusLabel
            // 
            this.DownloadReplayStatusLabel.AutoSize = true;
            this.DownloadReplayStatusLabel.Location = new System.Drawing.Point(127, 112);
            this.DownloadReplayStatusLabel.Name = "DownloadReplayStatusLabel";
            this.DownloadReplayStatusLabel.Size = new System.Drawing.Size(64, 13);
            this.DownloadReplayStatusLabel.TabIndex = 4;
            this.DownloadReplayStatusLabel.Text = "Status: Idle";
            this.DownloadReplayStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ManageReplaysGroup
            // 
            this.ManageReplaysGroup.Controls.Add(this.ManageReplaysStopLaunchButton);
            this.ManageReplaysGroup.Controls.Add(this.ManageReplaysList);
            this.ManageReplaysGroup.Controls.Add(this.ManageReplaysRefreshListButton);
            this.ManageReplaysGroup.Controls.Add(this.ManageReplaysLaunchReplayButton);
            this.ManageReplaysGroup.Controls.Add(this.ManageReplaysDeleteButton);
            this.ManageReplaysGroup.Location = new System.Drawing.Point(12, 155);
            this.ManageReplaysGroup.Name = "ManageReplaysGroup";
            this.ManageReplaysGroup.Size = new System.Drawing.Size(473, 344);
            this.ManageReplaysGroup.TabIndex = 2;
            this.ManageReplaysGroup.TabStop = false;
            this.ManageReplaysGroup.Text = "Manage Replays";
            // 
            // ManageReplaysDeleteButton
            // 
            this.ManageReplaysDeleteButton.Enabled = false;
            this.ManageReplaysDeleteButton.Location = new System.Drawing.Point(353, 24);
            this.ManageReplaysDeleteButton.Name = "ManageReplaysDeleteButton";
            this.ManageReplaysDeleteButton.Size = new System.Drawing.Size(105, 23);
            this.ManageReplaysDeleteButton.TabIndex = 1;
            this.ManageReplaysDeleteButton.Text = "Delete";
            this.ManageReplaysDeleteButton.UseVisualStyleBackColor = true;
            this.ManageReplaysDeleteButton.Click += new System.EventHandler(this.ManageReplaysDeleteButton_Click);
            // 
            // ManageReplaysLaunchReplayButton
            // 
            this.ManageReplaysLaunchReplayButton.Enabled = false;
            this.ManageReplaysLaunchReplayButton.Location = new System.Drawing.Point(353, 53);
            this.ManageReplaysLaunchReplayButton.Name = "ManageReplaysLaunchReplayButton";
            this.ManageReplaysLaunchReplayButton.Size = new System.Drawing.Size(105, 23);
            this.ManageReplaysLaunchReplayButton.TabIndex = 2;
            this.ManageReplaysLaunchReplayButton.Text = "Launch";
            this.ManageReplaysLaunchReplayButton.UseVisualStyleBackColor = true;
            this.ManageReplaysLaunchReplayButton.Click += new System.EventHandler(this.ManageReplaysLaunchReplayButton_Click);
            // 
            // ManageReplaysRefreshListButton
            // 
            this.ManageReplaysRefreshListButton.Location = new System.Drawing.Point(353, 304);
            this.ManageReplaysRefreshListButton.Name = "ManageReplaysRefreshListButton";
            this.ManageReplaysRefreshListButton.Size = new System.Drawing.Size(105, 23);
            this.ManageReplaysRefreshListButton.TabIndex = 3;
            this.ManageReplaysRefreshListButton.Text = "Refresh";
            this.ManageReplaysRefreshListButton.UseVisualStyleBackColor = true;
            this.ManageReplaysRefreshListButton.Click += new System.EventHandler(this.ManageReplaysRefreshList_Click);
            // 
            // ManageReplaysList
            // 
            this.ManageReplaysList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ManageReplaysList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FilenameCol,
            this.CreationDateCol});
            this.ManageReplaysList.FullRowSelect = true;
            this.ManageReplaysList.Location = new System.Drawing.Point(22, 24);
            this.ManageReplaysList.MultiSelect = false;
            this.ManageReplaysList.Name = "ManageReplaysList";
            this.ManageReplaysList.Size = new System.Drawing.Size(325, 303);
            this.ManageReplaysList.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.ManageReplaysList.TabIndex = 4;
            this.ManageReplaysList.UseCompatibleStateImageBehavior = false;
            this.ManageReplaysList.View = System.Windows.Forms.View.Details;
            this.ManageReplaysList.SelectedIndexChanged += new System.EventHandler(this.ManageReplaysList_SelectedIndexChanged);
            // 
            // FilenameCol
            // 
            this.FilenameCol.Text = "Filename";
            this.FilenameCol.Width = 201;
            // 
            // CreationDateCol
            // 
            this.CreationDateCol.Text = "CreationDate";
            this.CreationDateCol.Width = 120;
            // 
            // ManageReplaysStopLaunchButton
            // 
            this.ManageReplaysStopLaunchButton.Enabled = false;
            this.ManageReplaysStopLaunchButton.Location = new System.Drawing.Point(353, 82);
            this.ManageReplaysStopLaunchButton.Name = "ManageReplaysStopLaunchButton";
            this.ManageReplaysStopLaunchButton.Size = new System.Drawing.Size(105, 23);
            this.ManageReplaysStopLaunchButton.TabIndex = 5;
            this.ManageReplaysStopLaunchButton.Text = "Stop";
            this.ManageReplaysStopLaunchButton.UseVisualStyleBackColor = true;
            this.ManageReplaysStopLaunchButton.Click += new System.EventHandler(this.ManageReplaysStopLaunchButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 511);
            this.Controls.Add(this.ManageReplaysGroup);
            this.Controls.Add(this.DownloadReplayGroup);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "ReplayGG";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DownloadReplayGroup.ResumeLayout(false);
            this.DownloadReplayGroup.PerformLayout();
            this.ManageReplaysGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox DownloadReplayGroup;
        private System.Windows.Forms.Label DownloadReplayUrlLabel;
        private System.Windows.Forms.Button DownloadReplayButton;
        private System.Windows.Forms.TextBox DownloadReplayUrlText;
        private System.Windows.Forms.ProgressBar DownloadReplayProgress;
        private System.Windows.Forms.Label DownloadReplayStatusLabel;
        private System.Windows.Forms.GroupBox ManageReplaysGroup;
        private System.Windows.Forms.Button ManageReplaysDeleteButton;
        private System.Windows.Forms.Button ManageReplaysLaunchReplayButton;
        private System.Windows.Forms.Button ManageReplaysRefreshListButton;
        private System.Windows.Forms.ListView ManageReplaysList;
        private System.Windows.Forms.ColumnHeader FilenameCol;
        private System.Windows.Forms.ColumnHeader CreationDateCol;
        private System.Windows.Forms.Button ManageReplaysStopLaunchButton;
    }
}

