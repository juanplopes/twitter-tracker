using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwitterFriendshipTracker.Logic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TwitterFriendshipTracker.Infra
{
    public class HistoryLoader
    {
        BinaryFormatter serializer = new BinaryFormatter();
        public UserHistory Load(string user)
        {
            try
            {
                using (var file = File.OpenRead(user + ".history"))
                {
                    return (UserHistory)serializer.Deserialize(file);
                }
            }
            catch
            {
                return new UserHistory(user);
            }
        }

        public void Save(UserHistory history)
        {
            try
            {
                using (var file = File.Create(history.Name + ".history"))
                {
                    serializer.Serialize(file, history);
                }
            }
            catch
            {
            }
        }
    }
}
