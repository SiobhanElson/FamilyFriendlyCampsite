using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDataPopulation;

namespace DatabaseTestProject
{
    [TestClass]
    public class RandomWordCacheTest
    {
        private RandomWordCache randomWordCache;
        private string[] values;

        [TestInitialize]
        public void Setup()
        {
            values = new[] {"one", "random", "do dah"};
            randomWordCache = new RandomWordCache(() => values);
        }

        [TestMethod]
        public void GetWordShouldReturnWord()
        {
            //Act
            var returnedWord = randomWordCache.GetWord();

            //Assert
            CollectionAssert.Contains(values, returnedWord);
        }

        [TestMethod]
        public void GetWordShouldReturnWordAndRemoveWord()
        {
            //Act
            var returnedWord = randomWordCache.GetWord();

            CollectionAssert.DoesNotContain(randomWordCache.List, returnedWord);
        }

        [TestMethod]
        public void WhenOutOfWordsShouldRepopulateList()
        {
            _ = randomWordCache.GetWord();
            _ = randomWordCache.GetWord();
            _ = randomWordCache.GetWord();

            CollectionAssert.AreEquivalent(new List<string>(), randomWordCache.List);

            var returnedWord = randomWordCache.GetWord();
            CollectionAssert.Contains(values, returnedWord);
            Assert.AreEqual(2, randomWordCache.List.Count);
        }

        [DataTestMethod]
        [DataRow("one", "random", "duplicate", "duplicate")]
        [DataRow("one", "duplicate", "random", "duplicate")]
        [DataRow("duplicate", "one", "random", "duplicate", "duplicate")]
        [DataRow("duplicate", "duplicate")]
        public void GetWordShouldBeFineWithDuplicates(params string[] testValues)
        {
            randomWordCache = new RandomWordCache(() => testValues);

            Assert.AreEqual(0, randomWordCache.List.Count);

            for (var i = 0; i < testValues.Length; i++)
            {
                _ = randomWordCache.GetWord();

                Assert.AreEqual(testValues.Length - (i + 1), randomWordCache.List.Count);
            }
        }
    }
}