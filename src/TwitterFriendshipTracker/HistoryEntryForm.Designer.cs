namespace TwitterFriendshipTracker
{
    partial class HistoryEntryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryEntryForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CloseButton = new System.Windows.Forms.Button();
            this.WhatHappenedLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LostFollowersLabel = new System.Windows.Forms.Label();
            this.LostList = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.NewFollowersLabel = new System.Windows.Forms.Label();
            this.NewList = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Controls.Add(this.WhatHappenedLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(577, 44);
            this.panel1.TabIndex = 4;
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("Webdings", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Location = new System.Drawing.Point(529, 5);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(36, 36);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "r";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // WhatHappenedLabel
            // 
            this.WhatHappenedLabel.AutoSize = true;
            this.WhatHappenedLabel.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhatHappenedLabel.ForeColor = System.Drawing.Color.White;
            this.WhatHappenedLabel.Location = new System.Drawing.Point(12, 9);
            this.WhatHappenedLabel.Name = "WhatHappenedLabel";
            this.WhatHappenedLabel.Size = new System.Drawing.Size(301, 29);
            this.WhatHappenedLabel.TabIndex = 0;
            this.WhatHappenedLabel.Text = "Twitter Friendship Tracker";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(553, 356);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.LostFollowersLabel);
            this.panel3.Controls.Add(this.LostList);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(279, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(271, 350);
            this.panel3.TabIndex = 1;
            // 
            // LostFollowersLabel
            // 
            this.LostFollowersLabel.AutoSize = true;
            this.LostFollowersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LostFollowersLabel.ForeColor = System.Drawing.Color.Maroon;
            this.LostFollowersLabel.Location = new System.Drawing.Point(-4, 5);
            this.LostFollowersLabel.Name = "LostFollowersLabel";
            this.LostFollowersLabel.Size = new System.Drawing.Size(60, 24);
            this.LostFollowersLabel.TabIndex = 9;
            this.LostFollowersLabel.Text = "label2";
            // 
            // LostList
            // 
            this.LostList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LostList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LostList.FormattingEnabled = true;
            this.LostList.IntegralHeight = false;
            this.LostList.ItemHeight = 16;
            this.LostList.Location = new System.Drawing.Point(0, 34);
            this.LostList.Name = "LostList";
            this.LostList.Size = new System.Drawing.Size(268, 316);
            this.LostList.TabIndex = 8;
            this.LostList.DoubleClick += new System.EventHandler(this.NewList_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.NewFollowersLabel);
            this.panel2.Controls.Add(this.NewList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(270, 350);
            this.panel2.TabIndex = 0;
            // 
            // NewFollowersLabel
            // 
            this.NewFollowersLabel.AutoSize = true;
            this.NewFollowersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewFollowersLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.NewFollowersLabel.Location = new System.Drawing.Point(-1, 5);
            this.NewFollowersLabel.Name = "NewFollowersLabel";
            this.NewFollowersLabel.Size = new System.Drawing.Size(60, 24);
            this.NewFollowersLabel.TabIndex = 8;
            this.NewFollowersLabel.Text = "label1";
            // 
            // NewList
            // 
            this.NewList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewList.FormattingEnabled = true;
            this.NewList.IntegralHeight = false;
            this.NewList.ItemHeight = 16;
            this.NewList.Location = new System.Drawing.Point(3, 34);
            this.NewList.Name = "NewList";
            this.NewList.Size = new System.Drawing.Size(264, 316);
            this.NewList.TabIndex = 7;
            this.NewList.DoubleClick += new System.EventHandler(this.NewList_DoubleClick);
            // 
            // HistoryEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(577, 418);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HistoryEntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "History Entry";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label WhatHappenedLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LostFollowersLabel;
        private System.Windows.Forms.ListBox LostList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label NewFollowersLabel;
        private System.Windows.Forms.ListBox NewList;
        private System.Windows.Forms.Button CloseButton;
    }
}