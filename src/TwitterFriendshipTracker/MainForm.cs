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
        ITwitterParser parser = TwitterParser.Default;
        UserHistoryCollection history = null;
        public MainForm()
        {
            InitializeComponent();
            history = loader.Load();
            UpdateList();
        }

        private void UpdateList()
        {
            var lastUser = history.LastUser;
            UserInput.DataSource = history.Users.ToArray();
            UserInput.Text = lastUser;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            var user = RefreshUserData();
            UpdateUser(user);
        }

        private void UpdateUser(UserHistory user)
        {
            var entry = user.Update(parser, DateTime.Now);
            loader.Save(history);
            UpdateList();
            new HistoryEntryForm(entry).ShowDialog();
        }

        private UserHistory RefreshUserData()
        {
            var user = history[UserInput.Text];
            userHistoryEntryBindingSource.DataSource = user.Entries.OrderByDescending(x=>x.Date);
            return user;
        }

        private void ResultsGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var entry = (UserHistoryEntry)ResultsGrid[e.ColumnIndex, e.RowIndex].OwningRow.DataBoundItem;
            new HistoryEntryForm(entry).ShowDialog();
        }

        private void UserInput_TextChanged(object sender, EventArgs e)
        {
            RefreshUserData();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                history.Remove(UserInput.Text);
                UpdateList();
                loader.Save(history);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            loader.Save(history);
        }
      
    }
}
