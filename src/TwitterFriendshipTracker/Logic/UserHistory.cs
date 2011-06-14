using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitterFriendshipTracker.Logic
{
    [Serializable]
    public class UserHistory
    {
        string user;
        IList<UserHistoryEntry> entries;
        IList<long> lastCall;

        public UserHistory(string user) : this(user, null, null) { }
        public UserHistory(string user, IList<UserHistoryEntry> entries, IList<long> lastCall)
        {
            this.user = user;
            this.entries = entries ?? new List<UserHistoryEntry>();
            this.lastCall = lastCall;
        }


        public IEnumerable<UserHistoryEntry> Entries { get { return entries; } }
        public IEnumerable<long> LastCall { get { return lastCall; } }
        public string Name { get { return user; } }
        public bool IsEmpty { get { return lastCall == null; } }

        private bool InitIfNever(ITwitterParser parser)
        {
            if (lastCall == null)
            {
                lastCall = parser.FollowersFor(user).ToList();
                return true;
            }
            else return false;
        }

        public UserHistoryEntry Update(ITwitterParser parser, DateTime date)
        {
            if (InitIfNever(parser))
                return new UserHistoryEntry(date, new UserProfile[0], new UserProfile[0], lastCall.Count);

            var followers = parser.FollowersFor(user).ToList();
            var result = Analyze(parser, date, followers);

            if (result.SomethingHappened)
                entries.Add(result);

            return result;
        }

        private UserHistoryEntry Analyze(ITwitterParser parser, DateTime date, List<long> followers)
        {
            var result = new DifferencesAnalyzer(parser).Analyze(date, lastCall, followers);
            lastCall = followers;
            return result;
        }

    }
}
