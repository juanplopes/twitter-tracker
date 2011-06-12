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

        public UserProfile(long id, string name, string screenName) : this()
        {
            this.Id = id;
            this.Name = name;
            this.ScreenName = screenName;
        }
    }
}
