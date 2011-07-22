using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TwitterFriendshipTracker.Logic;
using SharpTestsEx;
using Moq;

namespace TwitterFriendshipTracker.Tests.Unit
{
    public class UserHistoryCollectionTests
    {
        ITwitterParser GetAnyParser(string user)
        {
            var parser = new Mock<ITwitterParser>();
            parser.Setup(x => x.FollowersFor(user)).Returns(new long[0]);
            return parser.Object;
        }

        [Test]
        public void recently_created_history_doesnt_show_on_users()
        {
            var users = new UserHistoryCollection();
            var test = users["test"];

            users.Users.Should().Be.Empty();
        }


        [Test]
        public void should_create_new_history_when_getting_new_user()
        {
            var users = new UserHistoryCollection();
            var test = users["test"];
            test.Update(GetAnyParser("test"), DateTime.MinValue);
            users.Users.Should().Have.SameValuesAs("test");
        }

        [Test]
        public void should_be_able_to_remove_user()
        {
            var users = new UserHistoryCollection();
            var test = users["test"];
            test.Update(GetAnyParser("test"), DateTime.MinValue);
            users.Users.Should().Have.SameValuesAs("test");
            users.Remove("tesT").Should().Be.True();
            users.Users.Should().Be.Empty();
        }

        [Test]
        public void should_return_same_history_no_matter_what_casing_used()
        {
            var users = new UserHistoryCollection();
            var test = users["TEST"];

            test.Should().Be(users["test"]).And.Not.Be(users["testa"]);
            test.Update(GetAnyParser("test"), DateTime.MinValue);

            users.Users.Should().Have.SameValuesAs("test");
        }

        [Test]
        public void should_return_same_history_even_with_preceding_at()
        {
            var users = new UserHistoryCollection();
            var test = users["TEST"];

            test.Should().Be(users["@test"]).And.Not.Be(users["test@"]);
            test.Update(GetAnyParser("test"), DateTime.MinValue);

            users.Users.Should().Have.SameValuesAs("test");
        }

        [Test]
        public void should_delete_all_if_gc_on_historyless_users()
        {
            var users = new UserHistoryCollection();
            var user = users["test"];

            users.Collect().Should().Have.SameValuesAs("test");

            users.Users.Should().Be.Empty();

        }

        [Test]
        public void should_return_last_history_when_asked_to()
        {
            var users = new UserHistoryCollection();

            users.LastUser.Should().Be.Null();
            var user = users["test"];
            user.Update(GetAnyParser("test"), DateTime.MinValue);
            users.LastUser.Should().Be("test");

            var otherUser = users["otherUser"];
            users.LastUser.Should().Be("otheruser");
        }

        [Test]
        public void should_be_serializable()
        {
            var users = new UserHistoryCollection();
            var user = users["test"];

            var otherUsers = UserHistoryTests.RoundTrip(users);
            otherUsers.Users.Should().Have.SameSequenceAs(users.Users);
        }

        [Test]
        public void can_update_all()
        {
            var parser = new Mock<ITwitterParser>();
            parser.Setup(x => x.FollowersFor("asd")).Returns(new long[0]);
            parser.Setup(x => x.FollowersFor("qwe")).Returns(new long[0]);

            var users = new UserHistoryCollection();
            users["asd"].ToString();
            users["qwe"].ToString();
            users["asd"].ToString();

            var date = DateTime.Now;
            users.UpdateAll(parser.Object, date);
            users.LastUser.Should().Be("asd");

            parser.VerifyAll();
        }

        [Test]
        public void can_update_all_even_with_exception()
        {
            var parser = new Mock<ITwitterParser>();
            parser.Setup(x => x.FollowersFor("asd")).Throws<Exception>();
            parser.Setup(x => x.FollowersFor("qwe")).Returns(new long[0]);

            var users = new UserHistoryCollection();
            users["asd"].ToString();
            users["qwe"].ToString();
            users["asd"].ToString();

            var date = DateTime.Now;
            Executing.This(() => users.UpdateAll(parser.Object, date)).Should().Throw<InvalidOperationException>();

            parser.VerifyAll();
        }
    }
}
