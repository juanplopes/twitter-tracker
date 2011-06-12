using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace TwitterFriendshipTracker.Logic
{
    public class TwitterAPI : ITwitter
    {
        WebClient client = new WebClient();

        public string Followers(string user, long cursor)
        {
            return client.DownloadString(string.Format("http://api.twitter.com/1/followers/ids/{0}.xml?cursor={1}", user, cursor));
        }

        public string UserLookup(IEnumerable<long> ids)
        {
            var parameter = string.Join(",", ids.Select(x => x.ToString()).ToArray());

            return client.DownloadString(string.Format("http://api.twitter.com/1/users/lookup.xml?user_id={0}", parameter));
        }
    }
}
