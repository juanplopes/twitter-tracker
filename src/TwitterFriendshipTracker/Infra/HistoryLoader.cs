using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwitterFriendshipTracker.Logic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;

namespace TwitterFriendshipTracker.Infra
{
    public class HistoryLoader
    {
        private static string GetFileName()
        {
            return Assembly.GetExecutingAssembly().Location + ".history";
        }


        BinaryFormatter serializer = new BinaryFormatter();
        public UserHistoryCollection Load()
        {
            try
            {
                using (var file = File.OpenRead(GetFileName()))
                {
                    return (UserHistoryCollection)serializer.Deserialize(file);
                }
            }
            catch
            {
                return new UserHistoryCollection();
            }
        }


        public void Save(UserHistoryCollection history)
        {
            try
            {
                history.Collect();
                using (var file = File.Create(GetFileName()))
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
