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
            entry = SetTitleLabel(entry);
        }

        private UserHistoryEntry SetTitleLabel(UserHistoryEntry entry)
        {
            if (entry.HasNewFolloers && entry.HasLostFollowers)
                WhatHappenedLabel.Text = string.Format("You've gained {0} and lost {1} followers", entry.NewFollowersCount, entry.LostFollowersCount);
            else if (entry.HasNewFolloers)
                WhatHappenedLabel.Text = string.Format("You've gained {0} followers", entry.NewFollowersCount);
            else if (entry.HasLostFollowers)
                WhatHappenedLabel.Text = string.Format("You've lost {0} followers", entry.LostFollowersCount);
            else
                WhatHappenedLabel.Text = "Nothing happened";
            return entry;
        }

    }
}
