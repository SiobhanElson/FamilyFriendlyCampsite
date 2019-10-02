using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DatabaseTestProject
{
    [TestClass]
    public class RandomWordGeneratorTest
    {

        [TestMethod]
        public void RunRandomWordProvider()
        {
            IRandomWordProvider randomWordProvider = new RandomWordProvider();

            string randomWord = randomWordProvider.GetWordAsync().Result;

            Assert.IsNotNull(randomWord);

            Console.WriteLine(randomWord);
        }
    }
}
