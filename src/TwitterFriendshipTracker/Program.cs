using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TwitterFriendshipTracker.Infra;
using TwitterFriendshipTracker.Logic;

namespace TwitterFriendshipTracker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.FirstOrDefault() == "update")
            {
                new HistoryLoader().UpdateAll(TwitterParser.Default);
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
