﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using SharpTestsEx;
using TwitterFriendshipTracker.Logic;

namespace TwitterFriendshipTracker.Tests.Unit
{
    public class TwitterParser_WhoAre_Tests
    {
        [Test]
        public void can_parse_who_are_with_no_parameter()
        {
            var ids = new long [] {  };
            var twitter = new Mock<ITwitter>();
            var parser = new TwitterParser(twitter.Object);
            parser.WhoAre(ids).Should().Be.Empty();
        }
        [Test]
        public void can_parse_who_are_with_1_parameter_but_returning_nothing()
        {
            var ids = new long[] { 1 };
            var twitter = new Mock<ITwitter>();
            twitter.Setup(x => x.UserLookup(ids)).Returns(@"<users></users>");

            var parser = new TwitterParser(twitter.Object);
            parser.WhoAre(ids).Should().Be.Empty();

            twitter.VerifyAll();
        }
        [Test]
        public void can_parse_who_are_with_1_user()
        {
            var ids = new long[] { 42 };
            var twitter = new Mock<ITwitter>();
            twitter.Setup(x => x.UserLookup(ids)).Returns(
                @"<users>
                    <user><id>42</id><name>Ford Prefect</name><screen_name>ford42</screen_name></user>
                </users>");

            var parser = new TwitterParser(twitter.Object);
            parser.WhoAre(ids).Should().Have.SameSequenceAs(new UserProfile(42, "Ford Prefect", "ford42"));

            twitter.VerifyAll();
        }

        [Test]
        public void can_parse_who_are_with_2_users()
        {
            var ids = new long[] { 42, 43 };
            var twitter = new Mock<ITwitter>();
            twitter.Setup(x => x.UserLookup(ids)).Returns(
                @"<users>
                    <user><id>42</id><name>Ford Prefect</name><screen_name>ford42</screen_name></user>
                    <user><id>43</id><name>Arthur Dent</name><screen_name>arthur</screen_name></user>
                </users>");

            var parser = new TwitterParser(twitter.Object);
            parser.WhoAre(ids).Should().Have.SameSequenceAs(
                new UserProfile(42, "Ford Prefect", "ford42"),
                new UserProfile(43, "Arthur Dent", "arthur"));

            twitter.VerifyAll();
        }

        [Test]
        public void can_parse_who_are_with_4_users_using_max_per_request_equals_2()
        {
            var twitter = new Mock<ITwitter>();
            twitter.Setup(x => x.UserLookup(new long[] { 42, 43 })).Returns(
                @"<users>
                    <user><id>42</id><name>Ford Prefect</name><screen_name>ford42</screen_name></user>
                    <user><id>43</id><name>Arthur Dent</name><screen_name>arthur</screen_name></user>
                </users>");

            twitter.Setup(x => x.UserLookup(new long[] { 44, 45 })).Returns(
            @"<users>
                    <user><id>44</id><name>Ford Prefect</name><screen_name>ford42</screen_name></user>
                    <user><id>45</id><name>Arthur Dent</name><screen_name>arthur</screen_name></user>
                </users>");


            var parser = new TwitterParser(twitter.Object);
            parser.WhoAre(new long [] { 42, 43, 44, 45 }, 2).Should().Have.SameSequenceAs(
                new UserProfile(42, "Ford Prefect", "ford42"),
                new UserProfile(43, "Arthur Dent", "arthur"),
                new UserProfile(44, "Ford Prefect", "ford42"),
                new UserProfile(45, "Arthur Dent", "arthur"));

            twitter.VerifyAll();
        }
    }
}
