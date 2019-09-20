using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace Wpf_Application_RAP_v01
{
    abstract class ERDAdapter
    {
        private const string db = "kit206";
        private const string user = "kit206";
        private const string pass = "kit206";
        private const string server = "alacritas.cis.utas.edu.au";

        private static MySqlConnection conn = null;

        //Part of step 2.3.3 in Week 8 tutorial. This method is a gift to you because .NET's approach to converting strings to enums is so horribly broken
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        /// <summary>
        /// Creates and returns (but does not open) the connection to the database.
        /// </summary>
        private static MySqlConnection GetConnection()
        {
            if (conn == null)
            {
                //Note: This approach is not thread-safe
                string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);
                conn = new MySqlConnection(connectionString);
            }
            return conn;
        }

        public static List<Researcher> fetchBasicResearcherDetails()
        {
            List<Researcher> res = new List<Researcher>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();
                //string queryString = @"select researcher.id, researcher.given_name, researcher.family_name,researcher.title ,position.level
                //                        from position 
                //                        left join researcher 
                //                        on position.id = researcher.id
                //                        where position.end is NULL
                //                        order by researcher.id";
                string queryString = "select given_name, family_name, title, IFNULL(level,\"\") from researcher";
                //MySqlCommand cmd = new MySqlCommand("select given_name, family_name, title from researcher", conn);
                MySqlCommand cmd = new MySqlCommand(queryString, conn);
                rdr = cmd.ExecuteReader();
                Level l;
                while (rdr.Read())
                {
                    //Note that in your assignment you will need to inspect the *type* of the
                    //employee/researcher before deciding which kind of concrete class to create.     
                    if (string.IsNullOrEmpty(rdr.GetString(3)))
                    {
                        l = Level.Student;
                    }
                    else
                    {
                        l = ParseEnum<Level>(rdr.GetString(3));
                    }
                    //l = ParseEnum<Level>(rdr.GetString(3));
                    res.Add(new Researcher { GivenName = rdr.GetString(0), FamilyName = rdr.GetString(1), Title = rdr.GetString(2),
                                             _Level = l});
                    //res.Add(new Researcher { GivenName = rdr.GetString(1), FamilyName = rdr.GetString(2), Title = rdr.GetString(3) });
                    //res.Add(new Researcher { GivenName = rdr.GetString(0), FamilyName = rdr.GetString(1), Title = rdr.GetString(2),  ThePosition = new Position( ParseEnum<EmploymentLevel>(rdr.GetString(3)))});
                    //res.Add(new Researcher { GivenName = rdr.GetString(0), FamilyName = rdr.GetString(1), Title = rdr.GetString(2), ThePosition = new Position { Level = ParseEnum<EmploymentLevel>(rdr.GetString(3)) } });
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
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

            return res;
        }
        //public static List<Position> fetchPossionDetails()
        //{
        //    List<Position> positions = new List<Position>();

        //    MySqlConnection conn = GetConnection();
        //    MySqlDataReader rdr = null;

        //    try
        //    {
        //        conn.Open();
        //        string queryString = @"select researcher.id, researcher.given_name,researcher.title ,position.level
        //                                from position 
        //                                left join researcher 
        //                                on position.id = researcher.id
        //                                where position.end is NULL
        //                                order by researcher.id";
        //        //MySqlCommand cmd = new MySqlCommand("select given_name, family_name, title from researcher", conn);
        //        MySqlCommand cmd = new MySqlCommand(queryString, conn);
        //        rdr = cmd.ExecuteReader();

        //        while (rdr.Read())
        //        {
        //            //Note that in your assignment you will need to inspect the *type* of the
        //            //employee/researcher before deciding which kind of concrete class to create.
        //            //res.Add(new Researcher { GivenName = rdr.GetString(0), FamilyName = rdr.GetString(1), Title = rdr.GetString(2) });
        //            positions.Add(new Position { });
        //        }
        //    }
        //    catch (MySqlException e)
        //    {
        //        Console.WriteLine("Error connecting to database: " + e);
        //    }
        //    finally
        //    {
        //        if (rdr != null)
        //        {
        //            rdr.Close();
        //        }
        //        if (conn != null)
        //        {
        //            conn.Close();
        //        }
        //    }

        //    return positions;
        //}
        public static List<Researcher> fetchFullResearcherDetails(int id)
        {
            List<Researcher> res = new List<Researcher>();
            return res;
        }

        public static List<Researcher> completeResearcherDetails(int id)
        {
            List<Researcher> res = new List<Researcher>();
            return res;
        }
        //public static List<Publication> fetchBasicPublicationDetails(int id)
        //{
        //    List<Publication> pub = new List<Publication>();
        //    return pub;
        //}
        //public static List<Publication> completePublicationDetails(int id)
        //{
        //    List<Publication> pub = new List<Publication>();
        //    return pub;
        //}
        public static int fetchPublicationCounts(DateTime fromDate, DateTime toDate)
        {
            return 0;
        }
    }
}
