using System;
using System.Linq;

namespace TestDataPopulation
{
    public class RandomNumberProvider
    {
        private static readonly Random random = new Random();

        public static string RandomNumberString(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomLandlineNumber(int length)
        {
            return new string("01" + RandomNumberString(9));
        }

        public static string RandomMobileNumber(int length)
        {
            return new string("07" + RandomNumberString(9));
        }

        public static string RandomNumberSelection()
        {
            string[] randomString = {RandomLandlineNumber(11), RandomMobileNumber(11)};
            var index = random.Next(randomString.Length);
            return randomString[index];
        }
    }
}