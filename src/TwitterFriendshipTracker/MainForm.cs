using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwitterFriendshipTracker.Logic;
using TwitterFriendshipTracker.Infra;

namespace TwitterFriendshipTracker
{
    public partial class MainForm : Form
    {
        HistoryLoader loader = new HistoryLoader();
        public MainForm()
        {
            InitializeComponent();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            var history = loader.Load(UserInput.Text);
            new HistoryEntryForm(history.Update(TwitterParser.Default, DateTime.Now)).ShowDialog();
            userHistoryEntryBindingSource.DataSource = history.Entries;
            loader.Save(history);
        }
    }
}
