using System;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;

namespace DatabaseTestProject
{
    [TestClass]
    public class DatabaseManipulationTests
    {
        [TestMethod]
        public void RunDatabaseReader()
        {
            DatabaseManipulation databaseManipulation = new DatabaseManipulation(new RandomWordProvider());
            databaseManipulation.DatabaseReader();
        }

        [TestMethod]
        public void RunDatabaseManipulator()
        {
            DatabaseManipulation databaseManipulation = new DatabaseManipulation(new RandomWordProvider());
            databaseManipulation.DatabaseManipulator();
        }


        [TestMethod]
        public void DatabaseManipulatorUsesRandomTitle()
        {
            //Arrange
            IRandomWordProvider fakeRandomWordProvider = A.Fake<IRandomWordProvider>();
            A.CallTo(() => fakeRandomWordProvider.GetWordAsync()).Returns("Ralph");

            //Act
            DatabaseManipulation databaseManipulation = new DatabaseManipulation(fakeRandomWordProvider);
            databaseManipulation.DatabaseManipulator();

            //Assert
            Assert.AreEqual("Ralph", GetLastDbField("Title"));
        }

        [TestMethod]
        public void DatabaseManipulatorUsesRandomCounty()
        {
            //Arrange
            IRandomWordProvider fakeRandomWordProvider = A.Fake<IRandomWordProvider>();
            A.CallTo(() => fakeRandomWordProvider.GetWordAsync()).Returns("Somerset");

            //Act
            DatabaseManipulation databaseManipulation = new DatabaseManipulation(fakeRandomWordProvider);
            databaseManipulation.DatabaseManipulator();

            //Assert
            Assert.AreEqual("Somerset", GetLastDbField("Location_County"));
        }

        [TestMethod]
        public void DatabaseManipulatorUsesRandomTown()
        {
            //Arrange
            IRandomWordProvider fakeRandomWordProvider = A.Fake<IRandomWordProvider>();
            A.CallTo(() => fakeRandomWordProvider.GetWordAsync()).Returns("Taunton");

            //Act
            DatabaseManipulation databaseManipulation = new DatabaseManipulation(fakeRandomWordProvider);
            databaseManipulation.DatabaseManipulator();

            //Assert
            Assert.AreEqual("Taunton", GetLastDbField("Location_Town"));
        }

        [TestMethod]
        public void DatabaseManipulatorUsesRandomWebsite()
        {
            //Arrange
            IRandomWordProvider fakeRandomWordProvider = A.Fake<IRandomWordProvider>();
            A.CallTo(() => fakeRandomWordProvider.GetWordAsync()).Returns("Blurb");

            //Act
            DatabaseManipulation databaseManipulation = new DatabaseManipulation(fakeRandomWordProvider);
            databaseManipulation.DatabaseManipulator();

            //Assert
            Assert.AreEqual("www.Blurb.com", GetLastDbField("Contact_Website"));
        }

        [TestMethod]
        public void DatabaseManipulatorUsesRandomEmail()
        {
            //Arrange
            IRandomWordProvider fakeRandomWordProvider = A.Fake<IRandomWordProvider>();
            A.CallTo(() => fakeRandomWordProvider.GetWordAsync()).Returns("Crunch");

            //Act
            DatabaseManipulation databaseManipulation = new DatabaseManipulation(fakeRandomWordProvider);
            databaseManipulation.DatabaseManipulator();

            //Assert
            Assert.AreEqual("Crunch@Crunch.com", GetLastDbField("Contact_Email"));
        }
        [TestMethod]
        public void DatabaseManipulatorUsesRandomPhone()
        {
            //Arrange
            IRandomWordProvider fakeRandomWordProvider = A.Fake<IRandomWordProvider>();
            A.CallTo(() => fakeRandomWordProvider.GetWordAsync()).Returns("Crunch");

            //Act
            DatabaseManipulation databaseManipulation = new DatabaseManipulation(fakeRandomWordProvider);
            databaseManipulation.DatabaseManipulator();
            //Arrange
            IRandomNumberProvider fakeRandomNumberProvider = A.Fake<IRandomNumberProvider>();
            A.CallTo(() => fakeRandomNumberProvider.GetWordAsync()).Returns("+44-785-554-3368");

            //Act
            DatabaseManipulation databaseManipulation1 = new DatabaseManipulation(fakeRandomNumberProvider);
            databaseManipulation1.DatabaseManipulator();

            //Assert
            Assert.AreEqual("+44-785-554-3368", GetLastDbField("Contact_Phone"));
        }

        [TestMethod]
        public void DatabaseManipulatorUsesRandomName()
        {
            //Arrange
            IRandomWordProvider fakeRandomWordProvider = A.Fake<IRandomWordProvider>();
            A.CallTo(() => fakeRandomWordProvider.GetWordAsync()).Returns("FancyMcFancyPants");

            //Act
            DatabaseManipulation databaseManipulation = new DatabaseManipulation(fakeRandomWordProvider);
            databaseManipulation.DatabaseManipulator();

            //Assert
            Assert.AreEqual("FancyMcFancyPants", GetLastDbField("Contact_Name"));
        }

        private string GetLastDbField(string fieldName)
        {
            SqlConnection conn = new SqlConnection(
                "Data Source=campsitefinder.database.windows.net;Initial Catalog=CampsiteFinder;User ID=Rob;Password=R0bp@ssw0rd123!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlDataReader rdr = null;
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand($"SELECT TOP 1 {fieldName} FROM Campsites ORDER BY ID DESC", conn);

                rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    return (string) rdr[0];
                }
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }

                if (conn != null)
                {
                    conn.Close();
                }
            }

            throw new Exception("Field not found");
        }
    }
}
