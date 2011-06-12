using System;
namespace TwitterFriendshipTracker
{
    public interface ITwitter
    {
        string Followers(string user, long cursor);
    }
}
