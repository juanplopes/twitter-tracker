using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using SharpTestsEx;
using TwitterFriendshipTracker.Logic;

namespace TwitterFriendshipTracker.Tests.Unit
{
    public class TwitterParser_Followers_Tests
    {
        [Test]
        public void can_parse_list_with_no_followers_no_cursor()
        {
            var twitter = new Mock<ITwitter>();
            twitter.Setup(x => x.Followers("test", -1)).Returns("<ids></ids>");

            var parser = new TwitterParser(twitter.Object);
            parser.FollowersFor("test").Should().Be.Empty();

            twitter.VerifyAll();
        }

        [Test]
        public void can_parse_list_with_1_follower_no_cursor()
        {
            var twitter = new Mock<ITwitter>();
            twitter.Setup(x => x.Followers("test", -1)).Returns("<ids><id>123</id></ids>");

            var parser = new TwitterParser(twitter.Object);
            parser.FollowersFor("test").Should().Have.SameSequenceAs(123);
            twitter.VerifyAll();
        }

        [Test]
        public void can_parse_list_with_2_followers_no_cursor()
        {
            var twitter = new Mock<ITwitter>();
            twitter.Setup(x => x.Followers("test", -1)).Returns("<ids><id>123</id><id>456</id></ids>");

            var parser = new TwitterParser(twitter.Object);
            parser.FollowersFor("test").Should().Have.SameSequenceAs(123, 456);
            twitter.VerifyAll();
        }

        [Test]
        public void can_parse_list_with_2_followers_with_cursor_only_on_first_page()
        {
            var twitter = new Mock<ITwitter>();
            twitter.Setup(x => x.Followers("test", -1)).Returns("<ids><id>123</id><id>456</id><next_cursor>1234567</next_cursor></ids>");
            twitter.Setup(x => x.Followers("test", 1234567)).Returns("<ids><id>234</id><id>567</id></ids>");

            var parser = new TwitterParser(twitter.Object);
            parser.FollowersFor("test").Should().Have.SameSequenceAs(123, 456, 234, 567);
            twitter.VerifyAll();
        }

        [Test]
        public void can_parse_list_with_2_followers_with_cursor_on_all_pages()
        {
            var twitter = new Mock<ITwitter>();
            twitter.Setup(x => x.Followers("test", -1)).Returns(@"<ids><id>123</id><id>456</id><next_cursor>1234567</next_cursor></ids>");
            twitter.Setup(x => x.Followers("test", 1234567)).Returns(@"<ids><id>123</id><id>456</id><next_cursor>1234568</next_cursor></ids>");
            twitter.Setup(x => x.Followers("test", 1234568)).Returns(@"<ids><id>123</id><id>456</id><next_cursor>0</next_cursor></ids>");

            var parser = new TwitterParser(twitter.Object);
            parser.FollowersFor("test").Should().Have.SameSequenceAs(123, 456, 123, 456, 123, 456);
            twitter.VerifyAll();
        }
    }
}
