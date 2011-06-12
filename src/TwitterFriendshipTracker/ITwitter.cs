using System;
using System.Collections.Generic;
namespace TwitterFriendshipTracker
{
    public interface ITwitter
    {
        string Followers(string user, long cursor);
        string UserLookup(IEnumerable<long> ids);
    }
}
