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
        ITwitter twitter;
        
        string user;
        IList<UserHistoryEntry> entries = new List<UserHistoryEntry>();

        protected UserHistory() : this(new TwitterAPI(), null) { }
        public UserHistory(ITwitter twitter, string user)
        {
            this.twitter = twitter;
            this.user = user;
        }

        public UserHistoryEntry Update(DateTime date)
        {
            return new UserHistoryEntry();
        }

    }
}
