using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FamilyFriendlyCampsite
{
    public interface ICampsiteRepository
    {
        IEnumerable<Campsite> GetCampsites();
    }

    public class CampsiteRepository : ICampsiteRepository
    {
        public IEnumerable<Campsite> GetCampsites()
        {
            var campsitesToReturn = new List<Campsite>();
            var conn = new SqlConnection(
                "Data Source=campsitefinder.database.windows.net;Initial Catalog=CampsiteFinder;User ID=Rob;Password=R0bp@ssw0rd123!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlDataReader rdr = null;

            try
            {
                conn.Open();
                using (var command = new SqlCommand("select * from dbo.Campsites", conn))
                {
                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        campsitesToReturn.Add(new Campsite
                        {
                            Id = (int) rdr[0],
                            Title = (string) rdr[1],
                            LocationCounty = (string) rdr[2],
                            LocationTown = (string) rdr[3],
                            ContactWebsite = (string) rdr[4],
                            ContactPhone = (string) rdr[5],
                            ContactEmail = (string) rdr[6],
                            ContactName = (string) rdr[7]
                        });
                    }
                }
            }
            finally
            {
                rdr?.Close();
                if (conn != null) conn.Close();
            }

            return campsitesToReturn;
        }
    }
}