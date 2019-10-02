using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DatabaseTestProject
{
    public class RandomWordProvider : IRandomWordProvider
    {
        private readonly HttpClient client = new HttpClient();

        public RandomWordProvider()
        {
            client.BaseAddress = new Uri("https://random-word-api.herokuapp.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetWordAsync()
        {
            var response = await client.GetAsync("/word?key=6LW33BWR&number=1");
            string[] result = null;
            if (response.IsSuccessStatusCode) result = await response.Content.ReadAsAsync<string[]>();

            return result.Single();
        }


        private class RandomName
        {
            public string[] RandomNameStrings { get; set; }
        }
    }

    public interface IRandomWordProvider
    {
        Task<string> GetWordAsync();
    }
}