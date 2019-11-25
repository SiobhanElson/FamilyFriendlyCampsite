using System;

namespace TestDataPopulation
{
    public class Program
    {
        public static void Main()
        {
            var databaseManipulation = new DatabaseManipulation(new RandomWordProvider());
            for (var i = 0; i < 20; i++)
            {
                Console.WriteLine($"Creating entry {i + 1}");
                databaseManipulation.InsertRandomRow();
            }
        }
    }
}