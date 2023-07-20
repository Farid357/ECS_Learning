using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace Tools
{
    public static class Extensions
    {
        public static T GetRandom<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));
            
            int random = Random.Range(0, enumerable.Count());
            return enumerable.ElementAt(random);
        }
    }
}