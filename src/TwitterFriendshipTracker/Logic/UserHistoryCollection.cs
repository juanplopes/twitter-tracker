using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitterFriendshipTracker.Logic
{
    [Serializable]
    public class UserHistoryCollection
    {
        Dictionary<string, UserHistory> users = new Dictionary<string, UserHistory>();

        public IEnumerable<string> Users { get { return users.Where(x => !x.Value.IsEmpty).Select(x => x.Key); } }

        string lastUser = null;
        public string LastUser { get { return lastUser; } }

        public bool Remove(string user)
        {
            return users.Remove(NormalizeUsername(user));
        }

        public UserHistory this[string user]
        {
            get
            {
                lastUser = user = NormalizeUsername(user);
                UserHistory history;
                if (!users.TryGetValue(user, out history))
                    return users[user] = history = new UserHistory(user);

                return history;
            }
        }

        public void UpdateAll(ITwitterParser parser, DateTime date)
        {
            Exception last = null;
            foreach (var user in users.Values)
                try
                {
                    user.Update(parser, date);
                }
                catch (Exception e) { last = new InvalidOperationException("Error updating " + user, e); }
            if (last != null) throw last;
        }

        static string NormalizeUsername(string user)
        {
            if (user.StartsWith("@")) user = user.Substring(1);
            return user.ToLower();
        }


        public IList<string> Collect()
        {
            var who = users.Values.Where(x => x.IsEmpty).Select(x => x.Name).ToList();
            who.ForEach(x => users.Remove(x));
            return who;
        }
    }
}
