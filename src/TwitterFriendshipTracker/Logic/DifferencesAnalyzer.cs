﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitterFriendshipTracker.Logic
{
    [Serializable]
    public class DifferencesAnalyzer
    {
        ITwitterParser parser;
        public DifferencesAnalyzer(ITwitterParser parser)
        {
            this.parser = parser;
        }

        public UserHistoryEntry Analyze(DateTime date, IList<long> before, IList<long> after)
        {
            var gainedIds = after.Except(before);
            var lostIds = before.Except(after);

            var allProfiles = parser.WhoAre(gainedIds.Concat(lostIds)).ToLookup(x => x.Id);

            var gained = Separate(gainedIds, allProfiles);
            var lost = Separate(lostIds, allProfiles);

            return new UserHistoryEntry(date, gained, lost, after.Count);
        }

        private static UserProfile[] Separate(IEnumerable<long> gainedIds, ILookup<long, UserProfile> allProfiles)
        {
            return gainedIds.SelectMany(x => allProfiles[x]).Distinct().ToArray();
        }
    }
}
