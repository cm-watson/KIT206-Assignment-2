using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows; //for generating a MessageBox upon encountering an error

using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace Assignment_2
{
    public abstract class ERDAdapter
    {
        //If including error reporting within this class (as this sample does) then you'll need a way
        //to control whether the errors are actually shown or silently ignored, since once you have
        //connected the GUI to the Boss object then the GUI designer will execute its code, which
        //will try to connect to the database to load live data into the GUI at design time.
        private static bool reportingErrors = false;

        //These would not be hard coded in the source file normally, but read from the application's settings (and, ideally, with some amount of basic encryption applied)
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


        /* Researcher related commands */

        //Need to add publications, student supervised
        //Fetch full Researcher details from database
        public static Researcher FetchFullResearcherDetails(int ResearcherID)
        {
            List<Position> Positions = new List<Position>(); // List of Researcher's previous and current Positions
            Researcher FullResearcher = new Researcher(1, Type.Staff, "Place", "Holder", "Null",
                "KIT206", Campus.Hobart, "null@utas.edu.au", "no.com", "BICT",
                -1, new List<Publication>(), new List<Position>()); ;

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                // Or could use select *
                MySqlCommand cmd = new MySqlCommand("select id, type, given_name, family_name," +
                    "title, unit, campus, email, photo, degree, supervisor_id, level, utas_start," +
                    "current_start from researcher where id=" + ResearcherID, conn);
                rdr = cmd.ExecuteReader();

                //Researcher information
                while (rdr.Read())
                {
                    Type CurrentType = ParseEnum<Type>(rdr.GetString(1));
                    String GivenName = rdr.GetString(2);
                    String FamilyName = rdr.GetString(3);
                    String Title = rdr.GetString(4);
                    String Unit = rdr.GetString(5);
                    Campus CurrentCampus = ParseEnum<Campus>(rdr.GetString(6).Replace(" ", "_"));
                    String Email = rdr.GetString(7);
                    String Photo = rdr.GetString(8);
                    String Degree = rdr.IsDBNull(9) ? "" : rdr.GetString(9);
                    int SupervisorID = rdr.IsDBNull(10) ? -1 : rdr.GetInt32(10);
                    EmploymentLevel Level = rdr.IsDBNull(11) ? EmploymentLevel.NULL : ParseEnum<EmploymentLevel>(rdr.GetString(11));
                    DateTime UtasStart = rdr.GetDateTime(12);
                    DateTime CurrentStart = rdr.GetDateTime(13);

                    Position CurrentPosition = new Position(Level, CurrentStart, DateTime.Now);

                    Positions.Add(CurrentPosition);

                    // Create new researcher 
                    FullResearcher = new Researcher(ResearcherID, CurrentType,
                        GivenName, FamilyName, Title,
                        Unit, CurrentCampus, Email,
                        Photo, Degree, SupervisorID, new List<Publication>(), Positions
                    );
                }
            }
            catch (MySqlException e)
            {
                ReportError("loading researcher", e);
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

            // Add positions
            FullResearcher = FetchFullResearcherPositions(FullResearcher);

            return FullResearcher;
        }

        // Fetch basic details for all Researchers
        public static List<Researcher> FetchBasicResearcherDetails()
        {
            List<Researcher> BasicResearchers = new List<Researcher>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select id, type, given_name, family_name, title, level, photo, current_start from researcher", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    BasicResearchers.Add(new Researcher(
                        rdr.GetInt32(0),                    // ID
                        ParseEnum<Type>(rdr.GetString(1)),  // ResearcherType
                        rdr.GetString(2),                   // GivenName
                        rdr.GetString(3),                   // FamilyName
                        rdr.GetString(4),                   // Title
                        "",                                 // Unit
                        Campus.Hobart,                      // Campus
                        "",                                 // Email
                        rdr.GetString(6),                   // Photo
                        "",                                 // Degree
                        -1,                                 // Supervisor ID
                        new List<Publication>(), 			// Publications
                        new List<Position> { 				// Positions
                        	new Position(rdr.IsDBNull(5) ? EmploymentLevel.NULL : ParseEnum<EmploymentLevel>(rdr.GetString(5)), rdr.GetDateTime(7), DateTime.MinValue)
                        }
                    ));
                }
            }
            catch (MySqlException e)
            {
                ReportError("loading researchers", e);
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

            return BasicResearchers;
        }

        // Complete details for Researcher
        public static Researcher CompleteResearcherDetails(Researcher BasicResearcher)
        {
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;
            // The ResearcherID of the passed Researcher
            int ResearcherID = BasicResearcher.ID;

            try
            {
                conn.Open();

                // Or could use select *
                MySqlCommand cmd = new MySqlCommand("select * from researcher where id=" + ResearcherID, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    // Update Researcher information
                    BasicResearcher.Unit = rdr.GetString(5);
                    BasicResearcher.CurrentCampus = ParseEnum<Campus>(rdr.GetString(6));
                    BasicResearcher.Email = rdr.GetString(7);
                    BasicResearcher.Photo = rdr.GetString(8);
                    BasicResearcher.Degree = rdr.IsDBNull(9) ? "" : rdr.GetString(9);
                    BasicResearcher.SupervisorID = rdr.IsDBNull(10) ? -1 : rdr.GetInt32(10);
                }
            }
            catch (MySqlException e)
            {
                ReportError("updating Researcher", e);
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

            // Add all researcher positions 
            BasicResearcher = FetchFullResearcherPositions(BasicResearcher);

            return BasicResearcher;
        }


        /* Position related commands */

        //Fetch full Researcher Position history 
        public static Researcher FetchFullResearcherPositions(Researcher R)
        {
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select * from position where id=" + R.ID, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    // Add positions that aren't current
                    if (!rdr.IsDBNull(3))
                    {
                        EmploymentLevel Level = ParseEnum<EmploymentLevel>(rdr.GetString(1));
                        DateTime Start = rdr.GetDateTime(2);
                        DateTime End = rdr.GetDateTime(3);

                        R.Positions.Add(new Position(Level, Start, End));
                    }
                }
            }
            catch (MySqlException e)
            {
                ReportError("loading researcher positions", e);
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

            return R;
        }


        /* Publication related commands */

        // Fetch basic details for all Publications by a Researcher
        public static List<Publication> FetchBasicPublicationDetails(Researcher R)
        {
            List<String> DOIList = new List<String>();	// List of Researcher's Publication DOIs
            List<Publication> BasicPublications = new List<Publication>();

            int ID = R.ID;	// Researcher's ID
            String cDOI = ""; // The current DOI for searching

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            // Fetch all Researcher's Publication's DOI
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select doi from researcher_publication where researcher_id=?ID", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    DOIList.Add(rdr.GetString(0));
                }
            }
            catch (MySqlException e)
            {
                ReportError("fetching researchers publication DOIs", e);
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

            // Fetch basic Publication details
            try
            {
                conn = GetConnection();
                rdr = null;
                conn.Open();

                while (DOIList.Count != 0)
                {
                    // Get next DOI
                    cDOI = DOIList[0];

                    MySqlCommand cmd = new MySqlCommand("select title, year from publication where doi=?cDOI", conn);
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        BasicPublications.Add(new Publication(
                            cDOI,               // DOI
                            rdr.GetString(0),   // Title
                            "",                 // Authors
                            rdr.GetInt32(1),    // Year
                            "",                 // Cite
                            DateTime.MinValue   // DateAvailable
                        ));
                    }

                    DOIList.RemoveAt(0);
                }
            }
            catch (MySqlException e)
            {
                ReportError("loading basic publications", e);
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

            return BasicPublications;
        }

        // Complete details for Publication
        public static Publication CompletePublicationDetails(Publication P)
        {
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;
            // The DOI of the passed Publication
            String DOI = P.DOI;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select * from publication where doi=?DOI", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Update Publication information
                    P.Authors = rdr.GetString(2);
                    P.Type = ParseEnum<OutputType>(rdr.GetString(4));
                    P.Cite = rdr.GetString(5);
                    P.DateAvailable = rdr.GetDateTime(6);
                }
            }
            catch (MySqlException e)
            {
                ReportError("updating publication", e);
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

            return P;
        }

        // Returns the number of publications from a researcher that were published per year.
        // Has O(n^2). Future revisions can make it O(n) with PCount[-1*(From-Year)]
        public static int[] FetchPublicationCounts(int From, int To, Researcher R)
        {
            int[] PCount = new int[(To - From) + 1]; // int array with length equal to number of years (inclusive)
            List<Publication> P = FetchBasicPublicationDetails(R); // List of all publications by researcher

            for (int i = 0; i < PCount.Length; i++)
            {
                PCount[i] = 0;  // Set default value

                for (int j = 0; j < P.Count; j++)
                {
                    if (P[j].Year == (To + i))
                    {
                        PCount[i]++;
                    }
                }
            }

            return PCount;
        }



        /// <summary>
        /// In a more complete application this error would be logged to a file
        /// and the error reported back to the original caller, who is closer
        /// to the GUI and hence better able to produce the error message box
        /// (which would not show the actual error details like this does).
        /// </summary>
        private static void ReportError(string msg, Exception e)
        {
            if (reportingErrors)
            {
                //MessageBox.Show("An error occurred while " + msg + ". Try again later.\n\nError Details:\n" + e,
                //    "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                Console.WriteLine("An error occurred while " + msg + ". Try again later.\n\nError Details:\n" + e);
            }
        }
    }
}