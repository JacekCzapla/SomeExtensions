﻿using System.Collections.Generic;
using System.Linq;

namespace SomeExtensions
{
    public static class ListExtensions
    {
        public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(this List<List<T>> sequences)
        {
            // base case: 
            IEnumerable<IEnumerable<T>> result = new[] { Enumerable.Empty<T>() };
            foreach (var sequence in sequences)
            {
                var s = sequence; // don't close over the loop variable 
                // recursive case: use SelectMany to build the new product out of the old one 
                result =
                  from seq in result
                  from item in s
                  select seq.Concat(new[] { item });
            }
            return result;
        }
    }
}