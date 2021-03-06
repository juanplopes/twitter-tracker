﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TwitterFriendshipTracker.Logic;
using Moq;
using SharpTestsEx;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace TwitterFriendshipTracker.Tests.Unit
{
    public class UserHistoryTests
    {
        [Test]
        public void the_first_call_will_always_return_nothing_because_it_intializes_the_object()
        {
            var parser = new Mock<ITwitterParser>();
            parser.Setup(x => x.FollowersFor("test")).Returns(new long[] { 1, 2, 3 });
            var history = new UserHistory("test");

            history.LastCall.Should().Be.Null();
            history.Entries.Should().Be.Empty();

            var date = new DateTime(2001, 9, 11);
            var result = history.Update(parser.Object, date);

            result.SomethingHappened.Should().Be.False();
            result.FollowerCount.Should().Be(3);

            history.LastCall.Should().Have.SameSequenceAs(1, 2, 3);
            history.Entries.Should().Have.SameSequenceAs(result);
        }

        [Test]
        public void when_new_user_is_found()
        {
            var parser = new Mock<ITwitterParser>();
            parser.SetupSequence(x => x.FollowersFor("test"))
                .Returns(new long[] { 1, 2, 3 })
                .Returns(new long[] { 1, 2, 3, 4 });
            parser.SetupSequence(x => x.WhoAre(new[] { 4L })).Returns(new[] { new UserProfile(4, "4", "4L") });

            var history = new UserHistory("test");

            var date = new DateTime(2001, 9, 11);
            var result1 = history.Update(parser.Object, date);
            var result2 = history.Update(parser.Object, date);
            result2.NewFollowers.Should().Have.SameSequenceAs(new[] { new UserProfile(4, "4", "4L") });
            result2.LostFollowers.Should().Be.Empty();
            result2.FollowerCount.Should().Be(4);

            result2.SomethingHappened.Should().Be.True();

            history.LastCall.Should().Have.SameSequenceAs(1, 2, 3, 4);
            history.Entries.Should().Have.SameSequenceAs(result1, result2);
        }

        [Test]
        public void when_nothing_happen_no_new_history_is_created()
        {
            var parser = new Mock<ITwitterParser>();
            parser.SetupSequence(x => x.FollowersFor("test"))
                .Returns(new long[] { 1, 2, 3 })
                .Returns(new long[] { 1, 2, 3 });

            var history = new UserHistory("test");

            var date = new DateTime(2001, 9, 11);
            var result1 = history.Update(parser.Object, date);
            var result2 = history.Update(parser.Object, date);

            history.Entries.Should().Have.SameSequenceAs(result1);
        }

        [Test]
        public void can_calculate_network_grow()
        {
            var entry = new UserHistoryEntry(DateTime.Now, new[] { new UserProfile(10, "asd", "qwe", 10, 5) }, new[] { new UserProfile(10, "asd", "qwe", 11, 5) }, 250);
            entry.NetworkRaise.Should().Be(10);
            entry.NetworkLoss.Should().Be(11);
        }

        [Test]
        public void can_calculate_network_grow_for_empty_history()
        {
            var entry = new UserHistoryEntry();
            entry.NetworkRaise.Should().Be(0);
            entry.NetworkLoss.Should().Be(0);
        }

        [Test]
        public void should_be_serializable()
        {
            var entries = new[] { new UserHistoryEntry(new DateTime(), new[] { new UserProfile(2, "", "") }, new UserProfile[0], 0) };
            var history = new UserHistory("test", entries, new long[] { 1, 3, 4 });

            var valueOf = RoundTrip(history);
            valueOf.Entries.Should().Not.Be.Empty();
            valueOf.LastCall.Should().Not.Be.Empty();
        }

        public static T RoundTrip<T>(T history)
        {
            var formatter = new BinaryFormatter();
            var memory = new MemoryStream();

            formatter.Serialize(memory, history);

            memory.Seek(0, SeekOrigin.Begin);

            var result = formatter.Deserialize(memory);
            var valueOf = result.Should().Be.OfType<T>().And.ValueOf;
            return valueOf;
        }
    }
}
