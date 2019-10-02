using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTestProject
{
    public class RandomNumberProvider : IRandomNumberProvider
    {
        private readonly HttpClient client = new HttpClient();

        public RandomNumberProvider()
        {
            client.BaseAddress = new Uri("https://node-data-generator.herokuapp.com/api");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetWordAsync()
        {
            var response = await client.GetAsync("/phone?country=uk&fomat=1&n=1");
            string[] result = null;
            if (response.IsSuccessStatusCode) result = await response.Content.ReadAsAsync<string[]>();

            return result.Single();
        }

        public class Rootobject
        {
            public string[] Property1 { get; set; }
        }

    }

    public interface IRandomNumberProvider
    {
        Task<string> GetWordAsync();
    }
}

