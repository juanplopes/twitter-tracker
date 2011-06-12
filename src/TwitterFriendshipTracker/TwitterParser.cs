using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml.Linq;

namespace TwitterFriendshipTracker
{
    public class TwitterParser
    {
        ITwitter twitter;
        public TwitterParser(ITwitter twitter)
        {
            this.twitter = twitter;
        }


        public IEnumerable<int> FollowersFor(string user)
        {
            var cursor = -1L;
            while (cursor != 0)
            {
                var xml = twitter.Followers(user, cursor);
                var doc = XDocument.Parse(xml);
                foreach (var follower in doc.Descendants("id").Select(x => int.Parse(x.Value)))
                    yield return follower;
                cursor = long.Parse(doc.Descendants("next_cursor").First().Value);
            }
        }

    }
}
