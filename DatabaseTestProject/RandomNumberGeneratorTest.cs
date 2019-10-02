using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseTestProject
{
    [TestClass]
    public class RandomNumberGeneratorTest
    {
            [TestMethod]
            public void RunRandomNumberProvider()
            {
                IRandomNumberProvider randomNumberProvider = new RandomNumberProvider();

                string randomNumber = randomNumberProvider.GetWordAsync().Result;

                Assert.IsNotNull(randomNumber);

                Console.WriteLine(randomNumber);
            }
        
    }
}
