using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestDataPopulation
{
    public class RandomNumberProvider
    {
        private static Random random = new Random();

        public static string RandomNumberString(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            //
            //string randomMobileNumber = "07" + RandomNumberString(9);
        }

        public static string RandomLandlineNumber(int length)
        {
            return new string("01" + RandomNumberString(9));
        }

        public static string RandomMobileNumber(int length)
        {
            return new string("07" + RandomNumberString(9));
        }
    }



    //    client.BaseAddress = new Uri("https://node-data-generator.herokuapp.com/api");
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(
        //        new MediaTypeWithQualityHeaderValue("application/json"));
        //}

        //public async Task<string> GetWordAsync()
        //{
        //    var response = await client.GetAsync("/phone?country=uk&fomat=1&n=1");
        //    string[] result = null;
        //    if (response.IsSuccessStatusCode) result = await response.Content.ReadAsAsync<string[]>();

        //    return result.Single();


        public class Rootobject
        {
            public string[] Property1 { get; set; }
        }

    

    //public interface IRandomNumberProvider
    //{
    //    Task<string> ;
    //}
}


