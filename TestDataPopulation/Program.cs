using System;
using System.Data.SqlClient;

namespace TestDataPopulation
{
    public class Program
    {
            public static void Main()
            {
                var databaseManipulation = new DatabaseManipulation(new RandomWordProvider());
                for (int i = 0; i < 200; i++)
                {
                    databaseManipulation.InsertRandomRow();
                }
            }

        //    private string GetLastDbField(string fieldName)
        //    {
        //        SqlConnection conn = new SqlConnection(
        //            "Data Source=campsitefinder.database.windows.net;Initial Catalog=CampsiteFinder;User ID=Rob;Password=R0bp@ssw0rd123!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //        SqlDataReader rdr = null;
        //        try
        //        {
        //            conn.Open();
        //            SqlCommand command = new SqlCommand($"SELECT TOP 1 {fieldName} FROM Campsites ORDER BY ID DESC", conn);

        //            rdr = command.ExecuteReader();

        //            while (rdr.Read())
        //            {
        //                return (string)rdr[0];
        //            }
        //        }
        //        finally
        //        {
        //            if (rdr != null)
        //            {
        //                rdr.Close();
        //            }

        //            if (conn != null)
        //            {
        //                conn.Close();
        //            }
        //        }

        //        throw new Exception("Field not found");
        //    }
        }
    }
