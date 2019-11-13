using System;
using System.Data.SqlClient;

namespace TestDataPopulation
{
    public class DatabaseManipulation
    {
        private readonly IRandomWordProvider _randomWordProvider;
        //RandomNumberProvider randomNumberProvider = new RandomNumberProvider();

        public DatabaseManipulation(IRandomWordProvider randomWordProvider)
        {
            _randomWordProvider = randomWordProvider;
        }

        //public DatabaseManipulation(IRandomNumberProvider randomNumberProvider)
        //{
        //    _randomNumberProvider = randomNumberProvider;
        //}

        public void DatabaseReader()
        {
            var conn = new SqlConnection(
                "Data Source=campsitefinder.database.windows.net;Initial Catalog=CampsiteFinder;User ID=Rob;Password=R0bp@ssw0rd123!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlDataReader rdr = null;
            try
            {
                conn.Open();
                var command = new SqlCommand("select * from dbo.Campsites", conn);

                rdr = command.ExecuteReader();

                while (rdr.Read())
                    // write the data on to the screen
                    Console.WriteLine("{0} \t | {1} \t | {2} \t | {3} \t | {4} \t | {5} \t | {6}", rdr[0], rdr[1],
                        rdr[2], rdr[3], rdr[4], rdr[5], rdr[6]);
            }
            finally
            {
                if (rdr != null) rdr.Close();
                if (conn != null) conn.Close();
            }
        }

        public void InsertRandomRow()
        {
            //put in html request

            //foreach loop

            //assimilate strings
            SqlConnection conn = null;
            var inputTitle = _randomWordProvider.GetWord();
            var inputCounty = _randomWordProvider.GetWord();
            var inputTown = _randomWordProvider.GetWord();
            var inputWebsite = $"www.{_randomWordProvider.GetWord()}.com";
            var inputPhone = RandomNumberProvider.RandomNumberSelection();
            var inputEmail = _randomWordProvider.GetWord() + "@" + _randomWordProvider.GetWord() + ".com";
            var inputName = _randomWordProvider.GetWord();
            var insertString =
                @"insert into dbo.Campsites(Title, Location_County, Location_Town, Contact_Website, Contact_Phone, Contact_Email, Contact_Name) values(@Title, @County, @Town, @Website, @Phone, @Email, @Name)";
            try
            {
                conn = new SqlConnection(
                    "Server=tcp:campsitefinder.database.windows.net,1433;Initial Catalog=CampsiteFinder;Persist Security Info=False;User ID=Rob;Password=R0bp@ssw0rd123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

                conn.Open();
                var cmd = new SqlCommand(insertString, conn);

                cmd.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Title",
                    Value = inputTitle
                });
                cmd.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@County",
                    Value = inputCounty
                });
                cmd.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Town",
                    Value = inputTown
                });
                cmd.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Website",
                    Value = inputWebsite
                });
                cmd.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Phone",
                    Value = inputPhone
                });
                cmd.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Email",
                    Value = inputEmail
                });
                cmd.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = inputName
                });
                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }
    }
}