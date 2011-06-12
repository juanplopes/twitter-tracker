using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitterFriendshipTracker.Logic
{
    [Serializable]
    public struct UserHistoryEntry
    {
        public DateTime Date { get; private set; }

        IList<UserProfile> newFollowers;
        IList<UserProfile> lostFollowers;
        int followerCount;

        public IEnumerable<UserProfile> NewFollowers { get { return newFollowers; } }
        public IEnumerable<UserProfile> LostFollowers { get { return lostFollowers; } }

        public int FollowerCount { get { return followerCount; } }
        public int NewFollowersCount { get { return newFollowers.Count; } }
        public int LostFollowersCount { get { return lostFollowers.Count; } }
        public bool HasNewFolloers { get { return NewFollowersCount > 0; } }
        public bool HasLostFollowers { get { return LostFollowersCount > 0; } }
        public bool SomethingHappened { get { return HasNewFolloers || HasLostFollowers; } }

        public UserHistoryEntry(DateTime date, IList<UserProfile> newFollowers, IList<UserProfile> lostFollowers, int followerCount) : this()
        {
            this.Date = date;
            this.newFollowers = newFollowers;
            this.lostFollowers = lostFollowers;
            this.followerCount = followerCount;
            
        }
    }
}
