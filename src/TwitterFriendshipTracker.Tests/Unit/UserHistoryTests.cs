using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TwitterFriendshipTracker.Logic;
using Moq;
using SharpTestsEx;

namespace TwitterFriendshipTracker.Tests.Unit
{
    public class UserHistoryTests
    {
        [Test]
        public void the_first_call_will_always_return_nothing_because_it_intializes_the_object()
        {
            var parser = new Mock<ITwitterParser>();
            parser.Setup(x => x.FollowersFor("test")).Returns(new long[] { 1, 2, 3 });
            var history = new UserHistory(parser.Object, "test");
            
            history.LastCall.Should().Be.Null();
            history.Entries.Should().Be.Empty();
            
            var date = new DateTime(2001, 9, 11);
            var result = history.Update(date);

            result.NothingHappened.Should().Be.True();

            history.LastCall.Should().Have.SameSequenceAs(1, 2, 3);
            history.Entries.Should().Be.Empty();
        }

        [Test]
        public void when_new_user_is_found()
        {
            var parser = new Mock<ITwitterParser>();
            parser.SetupSequence(x => x.FollowersFor("test"))
                .Returns(new long[] { 1, 2, 3 })
                .Returns(new long[] { 1, 2, 3, 4 });
            parser.SetupSequence(x => x.WhoAre(new[] { 4L })).Returns(new[] { new UserProfile(4, "4", "4L") });

            var history = new UserHistory(parser.Object, "test");

            var date = new DateTime(2001, 9, 11);
            history.Update(date);
            var result = history.Update(date);
            result.NewFollowers.Should().Have.SameSequenceAs(new[] { new UserProfile(4, "4", "4L") });
            result.LostFollowers.Should().Be.Empty();

            result.NothingHappened.Should().Be.False();

            history.LastCall.Should().Have.SameSequenceAs(1, 2, 3, 4);
            history.Entries.Should().Have.SameSequenceAs(result);
        }
    }
}
