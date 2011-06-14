using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TwitterFriendshipTracker.Logic;
using SharpTestsEx;

namespace TwitterFriendshipTracker.Tests.Unit
{
    public class UserHistoryCollectionTests
    {
        [Test]
        public void should_create_new_history_when_getting_new_user()
        {
            var users = new UserHistoryCollection();
            var test = users["test"];

            users.Users.Should().Have.SameValuesAs("test");
        }

        [Test]
        public void should_return_same_history_no_matter_what_casing_used()
        {
            var users = new UserHistoryCollection();
            users["TEST"].Should().Be(users["test"]).And.Not.Be(users["testa"]);

            users.Users.Should().Have.SameValuesAs("test", "testa");
        }

        [Test]
        public void should_return_same_history_even_with_preceding_at()
        {
            var users = new UserHistoryCollection();
            users["test"].Should().Be(users["@test"]).And.Not.Be(users["test@"]);

            users.Users.Should().Have.SameValuesAs("test", "test@");
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

            users.LastHistory.Should().Be.Null();
            var user = users["test"];
            users.LastHistory.Should().Be(user);

            var otherUser = users["otheruser"];
            users.LastHistory.Should().Be(otherUser);
        }

        [Test]
        public void should_be_serializable()
        {
            var users = new UserHistoryCollection();
            var user = users["test"];

            var otherUsers = UserHistoryTests.RoundTrip(users);
            otherUsers.Users.Should().Have.SameSequenceAs(users.Users);
        }
    }
}
