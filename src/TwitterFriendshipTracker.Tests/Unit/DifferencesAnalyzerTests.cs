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
    public class DifferencesAnalyzerTests
    {
        [Test]
        public void two_empty_lists()
        {
            var twitter = new Mock<ITwitterParser>();
            var analyzer = new DifferencesAnalyzer(twitter.Object);
            var date = new DateTime(2001, 09, 11);
            var entry = analyzer.Analyze(date, new long[0], new long[0]);

            entry.Date.Should().Be(date);
            entry.NewFollowers.Should().Be.Empty();
            entry.LostFollowers.Should().Be.Empty();
            entry.SomethingHappened.Should().Be.False();
            entry.FollowerCount.Should().Be(0);
        }

        [Test]
        public void gained_one_follower_from_zero()
        {
            var twitter = new Mock<ITwitterParser>();
            twitter.Setup(x => x.WhoAre(new[] { 42L })).Returns(new[] { new UserProfile(42, "42", "42L") });

            var analyzer = new DifferencesAnalyzer(twitter.Object);
            var date = new DateTime(2001, 09, 11);
            var entry = analyzer.Analyze(date, new long[0], new long[] { 42L });

            entry.Date.Should().Be(date);
            entry.NewFollowers.Should().Have.SameSequenceAs(new UserProfile(42, "42", "42L"));
            entry.LostFollowers.Should().Be.Empty();
            entry.SomethingHappened.Should().Be.True();
            entry.FollowerCount.Should().Be(1);
        }

        [Test]
        public void gained_one_follower_from_exinsting_ones()
        {
            var twitter = new Mock<ITwitterParser>();
            twitter.Setup(x => x.WhoAre(new[] { 42L })).Returns(new[] { new UserProfile(42, "42", "42L") });

            var analyzer = new DifferencesAnalyzer(twitter.Object);
            var date = new DateTime(2001, 09, 11);
            var entry = analyzer.Analyze(date, new long[] { 1L }, new long[] { 1L, 42L });

            entry.Date.Should().Be(date);
            entry.NewFollowers.Should().Have.SameSequenceAs(new UserProfile(42, "42", "42L"));
            entry.LostFollowers.Should().Be.Empty();
            entry.SomethingHappened.Should().Be.True();
            entry.FollowerCount.Should().Be(2);
        }

        [Test]
        public void lost_one_follower_from_zero()
        {
            var twitter = new Mock<ITwitterParser>();
            twitter.Setup(x => x.WhoAre(new[] { 42L })).Returns(new[] { new UserProfile(42, "42", "42L") });

            var analyzer = new DifferencesAnalyzer(twitter.Object);
            var date = new DateTime(2001, 09, 11);
            var entry = analyzer.Analyze(date, new long[] { 42L }, new long[] { });

            entry.Date.Should().Be(date);
            entry.NewFollowers.Should().Be.Empty();
            entry.LostFollowers.Should().Have.SameSequenceAs(new UserProfile(42, "42", "42L"));
            entry.SomethingHappened.Should().Be.True();
        }

        [Test]
        public void lost_one_follower_from_exinsting_ones()
        {
            var twitter = new Mock<ITwitterParser>();
            twitter.Setup(x => x.WhoAre(new[] { 42L })).Returns(new[] { new UserProfile(42, "42", "42L") });

            var analyzer = new DifferencesAnalyzer(twitter.Object);
            var date = new DateTime(2001, 09, 11);
            var entry = analyzer.Analyze(date, new long[] { 1L, 42L }, new long[] { 1L });

            entry.Date.Should().Be(date);
            entry.NewFollowers.Should().Be.Empty();
            entry.LostFollowers.Should().Have.SameSequenceAs(new UserProfile(42, "42", "42L"));
            entry.SomethingHappened.Should().Be.True();
            entry.FollowerCount.Should().Be(1);
        }

        [Test]
        public void lost_one_and_gained_another_follower_from_exinsting_ones_and_use_only_one_request()
        {
            var twitter = new Mock<ITwitterParser>();
            twitter.Setup(x => x.WhoAre(new[] { 43L, 42L })).Returns(new[] { 
                new UserProfile(42, "42", "42L"),
                new UserProfile(43, "43", "43L")
            });

            var analyzer = new DifferencesAnalyzer(twitter.Object);
            var date = new DateTime(2001, 09, 11);
            var entry = analyzer.Analyze(date, new long[] { 1L, 42L }, new long[] { 1L, 43L });

            entry.Date.Should().Be(date);
            entry.NewFollowers.Should().Have.SameSequenceAs(new UserProfile(43, "43", "43L"));
            entry.LostFollowers.Should().Have.SameSequenceAs(new UserProfile(42, "42", "42L"));
            entry.SomethingHappened.Should().Be.True();
            entry.FollowerCount.Should().Be(2);
        }
    }
}
