using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitterFriendshipTracker.Logic
{
    [Serializable]
    public struct UserProfile
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string ScreenName { get; private set; }
        public long Followers { get; private set; }
        public long Friends { get; private set; }

        public UserProfile(long id, string name, string screenName) : this(id, name, screenName, 0, 0) { }
        public UserProfile(long id, string name, string screenName, long followers, long friends) : this()
        {
            this.Id = id;
            this.Name = name;
            this.ScreenName = screenName;
            this.Followers = followers;
            this.Friends = friends;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1}) +{2}", Name, ScreenName, Followers, Friends);
        }
    }
}
