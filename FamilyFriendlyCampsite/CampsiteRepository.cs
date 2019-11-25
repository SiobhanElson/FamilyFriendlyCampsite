using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace FamilyFriendlyCampsite
{
    public class CampsiteRepository
    {
        public IEnumerable<Campsite> GetCampsites()
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
                return GetCampsites();
            }
            finally
            {
                if (rdr != null) rdr.Close();
                if (conn != null) conn.Close();
            }
        }
    }
}
