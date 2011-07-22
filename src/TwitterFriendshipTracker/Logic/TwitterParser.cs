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
        public static TwitterParser Default { get { return new TwitterParser(new TwitterAPI()); } }

        int maxRequestsPerCall;
        ITwitter twitter;

        public TwitterParser(ITwitter twitter) : this(twitter, 4) { }
        public TwitterParser(ITwitter twitter, int maxRequestsPerCall)
        {
            this.twitter = twitter;
            this.maxRequestsPerCall = maxRequestsPerCall;
        }

        public virtual IEnumerable<UserProfile> WhoAre(IEnumerable<long> theseUsers)
        {
            return WhoAre(theseUsers, 100);
        }

        public virtual IEnumerable<UserProfile> WhoAre(IEnumerable<long> theseUsers, int maxPerRequest)
        {
            int count = 0;
            return theseUsers.BatchAggregate(maxPerRequest).SelectMany(users =>
            {
                CheckRequestCount(count++);

                var xml = twitter.UserLookup(users);
                var doc = XDocument.Parse(xml);

                return doc.Descendants("user").Select(x =>
                    new UserProfile(
                        Long(x.Element("id")),
                        x.Element("name").Value,
                        x.Element("screen_name").Value,
                        Long(x.Element("followers_count")),
                        Long(x.Element("friends_count"))));
            });
        }

        private long Long(XElement element)
        {
            if (element != null)
                return long.Parse(element.Value);
            else
                return 0;
        }

        private void CheckRequestCount(int count)
        {
            if (count >= maxRequestsPerCall)
                throw new InvalidOperationException(string.Format("max requests exceeded: {0}", maxRequestsPerCall));
        }

        public virtual IEnumerable<long> FollowersFor(string user)
        {
            int count = 0;
            var cursor = -1L;
            while (cursor != 0)
            {
                CheckRequestCount(count++);
                var xml = twitter.Followers(user, cursor);
                var doc = XDocument.Parse(xml);
                foreach (var follower in doc.Descendants("id").Select(x => long.Parse(x.Value)))
                    yield return follower;

                cursor = long.Parse(doc.Descendants("next_cursor").Select(x => x.Value).FirstOrDefault() ?? "0");
            }
        }

    }
}
