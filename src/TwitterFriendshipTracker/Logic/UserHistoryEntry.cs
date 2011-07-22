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
        public string RelativeTime { get { return Date.RelativeTo(DateTime.Now); } }

        IList<UserProfile> newFollowers;
        IList<UserProfile> lostFollowers;
        long followerCount;

        public IEnumerable<UserProfile> NewFollowers { get { return newFollowers ?? new UserProfile[0]; } }
        public IEnumerable<UserProfile> LostFollowers { get { return lostFollowers ?? new UserProfile[0]; } }

        public long NetworkRaise { get { return NewFollowers.Sum(x => x.Followers); } }
        public long NetworkLoss { get { return LostFollowers.Sum(x => x.Followers); } }

        public long FollowerCount { get { return followerCount; } }
        public long NewFollowersCount { get { return NewFollowers.Count(); } }
        public long LostFollowersCount { get { return LostFollowers.Count(); } }
        public bool HasNewFollowers { get { return NewFollowersCount > 0; } }
        public bool HasLostFollowers { get { return LostFollowersCount > 0; } }
        public bool SomethingHappened { get { return HasNewFollowers || HasLostFollowers; } }

        public string FormattedRaise { get { return string.Format("+{0} ({1})", NewFollowersCount, NetworkRaise); } }
        public string FormattedLoss { get { return string.Format("-{0} ({1})", LostFollowersCount, NetworkLoss); } }


        public UserHistoryEntry(DateTime date, IList<UserProfile> newFollowers, IList<UserProfile> lostFollowers, int followerCount) : this()
        {
            this.Date = date;
            this.newFollowers = newFollowers;
            this.lostFollowers = lostFollowers;
            this.followerCount = followerCount;
            
        }
    }
}
