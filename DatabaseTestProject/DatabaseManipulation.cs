using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseTestProject
{
    public class DatabaseManipulation
    {
        public void DatabaseReader()
        {
            SqlConnection conn = new SqlConnection(
                "Data Source=campsitefinder.database.windows.net;Initial Catalog=CampsiteFinder;User ID=bob;Password=B0bp@ssw0rd123!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlDataReader rdr = null;
            //SqlCommand command = new SqlCommand("SELECT * from dbo.Campsites, conn");

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand("select * from dbo.Campsites", conn);

                rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    // write the data on to the screen
                    Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3} \t | {4} \t | {5} \t | {6}",
                    // call the objects from their index
                    rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6]));
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
            //using (SqlDataReader reader = command.ExecuteReader())
            //{
            //    // while there is another record present
            //    while (reader.Read())
            //    {
            //        // write the data on to the screen
            //        Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3}",
            //        // call the objects from their index
            //        reader[0], reader[1], reader[2], reader[3]));
            //    }
            //}
        }
    }
}
