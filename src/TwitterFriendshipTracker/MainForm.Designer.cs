namespace TwitterFriendshipTracker
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.UserInput = new System.Windows.Forms.TextBox();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.ResultsGrid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.userHistoryEntryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.followerCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newFollowersCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lostFollowersCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsGrid)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userHistoryEntryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // UserInput
            // 
            this.UserInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserInput.Location = new System.Drawing.Point(14, 50);
            this.UserInput.MaxLength = 20;
            this.UserInput.Name = "UserInput";
            this.UserInput.Size = new System.Drawing.Size(337, 31);
            this.UserInput.TabIndex = 0;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateButton.Location = new System.Drawing.Point(357, 50);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(141, 31);
            this.UpdateButton.TabIndex = 1;
            this.UpdateButton.Text = "update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // ResultsGrid
            // 
            this.ResultsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultsGrid.AutoGenerateColumns = false;
            this.ResultsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateDataGridViewTextBoxColumn,
            this.followerCountDataGridViewTextBoxColumn,
            this.newFollowersCountDataGridViewTextBoxColumn,
            this.lostFollowersCountDataGridViewTextBoxColumn});
            this.ResultsGrid.DataSource = this.userHistoryEntryBindingSource;
            this.ResultsGrid.Location = new System.Drawing.Point(13, 87);
            this.ResultsGrid.Name = "ResultsGrid";
            this.ResultsGrid.Size = new System.Drawing.Size(485, 391);
            this.ResultsGrid.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 44);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Twitter Friendship Tracker";
            // 
            // userHistoryEntryBindingSource
            // 
            this.userHistoryEntryBindingSource.DataSource = typeof(TwitterFriendshipTracker.Logic.UserHistoryEntry);
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // followerCountDataGridViewTextBoxColumn
            // 
            this.followerCountDataGridViewTextBoxColumn.DataPropertyName = "FollowerCount";
            this.followerCountDataGridViewTextBoxColumn.HeaderText = "Followers";
            this.followerCountDataGridViewTextBoxColumn.Name = "followerCountDataGridViewTextBoxColumn";
            this.followerCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // newFollowersCountDataGridViewTextBoxColumn
            // 
            this.newFollowersCountDataGridViewTextBoxColumn.DataPropertyName = "NewFollowersCount";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.newFollowersCountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.newFollowersCountDataGridViewTextBoxColumn.HeaderText = "New";
            this.newFollowersCountDataGridViewTextBoxColumn.Name = "newFollowersCountDataGridViewTextBoxColumn";
            this.newFollowersCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lostFollowersCountDataGridViewTextBoxColumn
            // 
            this.lostFollowersCountDataGridViewTextBoxColumn.DataPropertyName = "LostFollowersCount";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Maroon;
            this.lostFollowersCountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.lostFollowersCountDataGridViewTextBoxColumn.HeaderText = "Lost";
            this.lostFollowersCountDataGridViewTextBoxColumn.Name = "lostFollowersCountDataGridViewTextBoxColumn";
            this.lostFollowersCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(510, 490);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ResultsGrid);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.UserInput);
            this.Name = "MainForm";
            this.Text = "Twitter Friendship Tracker";
            ((System.ComponentModel.ISupportInitialize)(this.ResultsGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userHistoryEntryBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserInput;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.DataGridView ResultsGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn followerCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn newFollowersCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lostFollowersCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource userHistoryEntryBindingSource;
    }
}

