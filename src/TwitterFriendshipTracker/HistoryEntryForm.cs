using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwitterFriendshipTracker.Logic;

namespace TwitterFriendshipTracker
{
    public partial class HistoryEntryForm : Form
    {
        public HistoryEntryForm(UserHistoryEntry entry)
        {
            InitializeComponent();
            
            WhatHappenedLabel.Text = string.Format("Total followers: {0}", entry.FollowerCount);
            NewFollowersLabel.Text = string.Format("New followers: {0}", entry.NewFollowersCount);
            LostFollowersLabel.Text = string.Format("Lost followers: {0}", entry.LostFollowersCount);
        }


    }
}
