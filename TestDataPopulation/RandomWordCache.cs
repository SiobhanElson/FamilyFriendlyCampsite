using System;
using System.Collections.Generic;
using System.Linq;

namespace TestDataPopulation
{
    public class RandomWordCache
    {
        private readonly Func<IEnumerable<string>> populateCacheMethod;

        public RandomWordCache(Func<IEnumerable<string>> populateCacheMethod)
        {
            this.populateCacheMethod = populateCacheMethod;
        }

        public List<string> List { get; private set; } = new List<string>();

        public string GetWord()
        {
            if (List.Count == 0)
                PopulateList();

            var word = List.Last();
            List.Remove(word);
            return word;
        }

        private void PopulateList()
        {
            List = new List<string>(populateCacheMethod.Invoke());
        }
    }
}