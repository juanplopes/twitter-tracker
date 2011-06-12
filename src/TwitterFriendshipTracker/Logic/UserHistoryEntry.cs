using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitterFriendshipTracker.Logic
{
    public struct UserHistoryEntry
    {
        public DateTime Date { get; private set; }
        public IList<UserProfile> NewFollowers { get; private set; }
        public IList<UserProfile> LostFollowers { get; private set; }
        
        public bool NothingHappened { get { return NewFollowers.Count == 0 && LostFollowers.Count == 0; } }

        public UserHistoryEntry(DateTime date, IList<UserProfile> newFollowers, IList<UserProfile> lostFollowers) : this()
        {
            this.Date = date;
            this.NewFollowers = newFollowers;
            this.LostFollowers = lostFollowers;
        }
    }
}
