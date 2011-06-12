using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml.Linq;

namespace TwitterFriendshipTracker.Logic
{
    public class TwitterParser : ITwitterParser
    {
        private TwitterParser() { }

        ITwitter twitter;
        public TwitterParser(ITwitter twitter)
        {
            this.twitter = twitter;
        }

        public virtual IEnumerable<UserProfile> WhoAre(IEnumerable<long> theseUsers)
        {
            return WhoAre(theseUsers, 100);
        }

        public virtual IEnumerable<UserProfile> WhoAre(IEnumerable<long> theseUsers, int maxPerRequest)
        {
            return theseUsers.BatchAggregate(maxPerRequest).SelectMany(users =>
            {
                var xml = twitter.UserLookup(users);
                var doc = XDocument.Parse(xml);

                return doc.Descendants("user").Select(x =>
                    new UserProfile(long.Parse(x.Element("id").Value), x.Element("name").Value, x.Element("screen_name").Value));
            });
        }

        public virtual IEnumerable<long> FollowersFor(string user)
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
