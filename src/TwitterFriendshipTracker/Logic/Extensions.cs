using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitterFriendshipTracker.Logic
{
    public static class Extensions
    {
        public static IEnumerable<IList<T>> BatchAggregate<T>(this IEnumerable<T> source, int batchSize)
        {
            var list = new List<T>(batchSize);

            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    list.Add(enumerator.Current);
                    if (list.Count == batchSize)
                    {
                        yield return list;
                        list = new List<T>(batchSize);
                    }
                }

                if (list.Any())
                    yield return list;
            }
        }
    }
}
