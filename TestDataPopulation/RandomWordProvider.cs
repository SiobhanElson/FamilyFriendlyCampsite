using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestDataPopulation
{
    public class RandomWordProvider : IRandomWordProvider
    {
        private readonly HttpClient client = new HttpClient();

        public RandomWordProvider()
        {
            client.BaseAddress = new Uri("https://api.wordnik.com/v4/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetWordAsync()
        {
            var response =
                await client.GetStringAsync(
                    "words.json/randomWord?hasDictionaryDef=true&maxCorpusCount=-1&minDictionaryCount=1&maxDictionaryCount=-1&minLength=5&maxLength=-1&api_key=zrk0a1j7ag65d6r3k6xp0a92gay1d2sb2nanhrjaf0sv77554");

            var randomWordResponse = JsonConvert.DeserializeObject<RandomWordResponse>(response);
            return randomWordResponse.Word;
        }

        private class RandomWordResponse
        {
            public int Id { get; set; }
            public string Word { get; set; }
        }


        //private class RandomName
        //{
        //    public string[] RandomNameStrings { get; set; }
        //}
    }

    public interface IRandomWordProvider
    {
        Task<string> GetWordAsync();
    }
}