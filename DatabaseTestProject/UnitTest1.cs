using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DatabaseTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DatabaseManipulation databaseManipulation = new DatabaseManipulation();
            databaseManipulation.DatabaseReader();
        }
    }
}
