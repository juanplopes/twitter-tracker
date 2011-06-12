using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace TwitterFriendshipTracker
{
    public class TwitterAPI : ITwitter
    {
        WebClient client = new WebClient();

        public string Followers(string user, long cursor)
        {
            return client.DownloadString(string.Format("http://api.twitter.com/1/followers/ids/{0}.xml?cursor={1}", user, cursor));
        }
    }
}
