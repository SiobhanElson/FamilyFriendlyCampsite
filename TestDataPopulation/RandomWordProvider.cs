using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace TestDataPopulation
{
    public interface IRandomWordProvider
    {
        string GetWord();
    }

    [ExcludeFromCodeCoverage]
    public class RandomWordProvider : IRandomWordProvider
    {
        private readonly HttpClient client = new HttpClient();
        private readonly RandomWordCache randomWordCache;

        public RandomWordProvider()
        {
            client.BaseAddress = new Uri("https://api.wordnik.com/v4/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            randomWordCache = new RandomWordCache(PopulateCacheMethod);
        }

        public string GetWord()
        {
            return randomWordCache.GetWord();
        }

        private IEnumerable<string> PopulateCacheMethod()
        {
            var responseTask =
                client.GetStringAsync(
                    "words.json/randomWords?hasDictionaryDef=true&maxCorpusCount=-1&minDictionaryCount=1&maxDictionaryCount=-1&minLength=5&maxLength=-1&limit=600&api_key=zrk0a1j7ag65d6r3k6xp0a92gay1d2sb2nanhrjaf0sv77554");

            var response = responseTask.Result;
            var randomWordResponse = JsonConvert.DeserializeObject<List<RandomWordResponse>>(response);

            return randomWordResponse.Select(w => w.Word);
        }

        public class RandomWordResponse
        {
            public int Id { get; set; }
            public string Word { get; set; }
        }
    }
}