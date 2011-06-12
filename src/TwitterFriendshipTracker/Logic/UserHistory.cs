using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitterFriendshipTracker.Logic
{
    [Serializable]
    public class UserHistory
    {
        [NonSerialized]
        ITwitterParser parser;
        [NonSerialized]
        DifferencesAnalyzer analyzer;

        string user;
        IList<UserHistoryEntry> entries;
        IList<long> lastCall;

        protected UserHistory() : this(TwitterParser.Default, null) { }
        public UserHistory(ITwitterParser parser, string user) : this(parser, user, null, null) { }
        public UserHistory(ITwitterParser parser, string user, IList<UserHistoryEntry> entries, IList<long> lastCall)
        {
            this.parser = parser;
            this.user = user;
            this.entries = entries ?? new List<UserHistoryEntry>();
            this.lastCall = lastCall;
            this.analyzer = new DifferencesAnalyzer(parser);
        }

        private bool InitIfNever()
        {
            if (lastCall == null)
            {
                lastCall = parser.FollowersFor(user).ToList();
                return true;
            }
            else return false;
        }

        public IEnumerable<UserHistoryEntry> Entries { get { return entries; } }
        public IEnumerable<long> LastCall { get { return lastCall; } }
        public UserHistoryEntry Update(DateTime date)
        {
            if (InitIfNever())
                return new UserHistoryEntry(date, new UserProfile[0], new UserProfile[0]);

            var followers = parser.FollowersFor(user).ToList();
            var result = Analyze(date, followers);

            if (!result.NothingHappened)
                entries.Add(result);

            return result;
        }

        private UserHistoryEntry Analyze(DateTime date, List<long> followers)
        {
            var result = analyzer.Analyze(date, lastCall, followers);
            lastCall = followers;
            return result;
        }

    }
}
