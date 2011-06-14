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

        public IEnumerable<string> Users { get { return users.Keys; } }

        UserHistory lastHistory = null;
        public UserHistory LastHistory { get { return lastHistory; } }

        public UserHistory this[string user]
        {
            get
            {
                user = NormalizeUsername(user);
                
                if (!users.TryGetValue(user, out lastHistory))
                    return users[user] = lastHistory = new UserHistory(user);

                return lastHistory;
            }
        }

        static string NormalizeUsername(string user)
        {
            if (user.StartsWith("@")) user = user.Substring(1);
            return user.ToLower();
        }


        public IList<string> Collect()
        {
            var who = users.Values.Where(x => x.IsEmpty).Select(x => x.Name).ToList();
            who.ForEach(x=>users.Remove(x));
            return who;
        }
    }
}
