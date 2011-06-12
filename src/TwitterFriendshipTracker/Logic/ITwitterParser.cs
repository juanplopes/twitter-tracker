using System;
using System.Collections.Generic;
namespace TwitterFriendshipTracker.Logic
{
    public interface ITwitterParser
    {
        IEnumerable<long> FollowersFor(string user);
        IEnumerable<UserProfile> WhoAre(IEnumerable<long> theseUsers);
        IEnumerable<UserProfile> WhoAre(IEnumerable<long> theseUsers, int maxPerRequest);
    }
}
