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
            this.panel1 = new System.Windows.Forms.Panel();
            this.WhatHappenedLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.WhatHappenedLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(445, 44);
            this.panel1.TabIndex = 4;
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
            // HistoryEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(445, 310);
            this.Controls.Add(this.panel1);
            this.Name = "HistoryEntryForm";
            this.Text = "History Entry";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label WhatHappenedLabel;
    }
}