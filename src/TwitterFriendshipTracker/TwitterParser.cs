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

        public IEnumerable<UserProfile> WhoAre(IEnumerable<long> theseUsers)
        {
            var xml = twitter.UserLookup(theseUsers);
            var doc = XDocument.Parse(xml);

            return doc.Descendants("user").Select(x =>
                new UserProfile(long.Parse(x.Element("id").Value), x.Element("name").Value, x.Element("screen_name").Value));
        }

        public IEnumerable<long> FollowersFor(string user)
        {
            var cursor = -1L;
            while (cursor != 0)
            {
                var xml = twitter.Followers(user, cursor);
                var doc = XDocument.Parse(xml);
                foreach (var follower in doc.Descendants("id").Select(x => long.Parse(x.Value)))
                    yield return follower;

                cursor = long.Parse(doc.Descendants("next_cursor").Select(x => x.Value).FirstOrDefault() ?? "0");
            }
        }

    }
}
