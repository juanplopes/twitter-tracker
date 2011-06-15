using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwitterFriendshipTracker.Logic;
using System.Diagnostics;

namespace TwitterFriendshipTracker
{
    public partial class HistoryEntryForm : Form
    {
        public HistoryEntryForm(UserHistoryEntry entry)
        {
            InitializeComponent();
            
            WhatHappenedLabel.Text = string.Format("{0}, followers: {1}", entry.Date, entry.FollowerCount);
            NewFollowersLabel.Text = string.Format("New followers: {0}", entry.NewFollowersCount);
            LostFollowersLabel.Text = string.Format("Lost followers: {0}", entry.LostFollowersCount);
            NewList.DataSource = entry.NewFollowers;
            LostList.DataSource = entry.LostFollowers;
        }

        private void NewList_DoubleClick(object sender, EventArgs e)
        {
            var user = ((UserProfile)(sender as ListBox).SelectedItem).ScreenName;
            Process.Start(string.Format("http://twitter.com/{0}", user));
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
