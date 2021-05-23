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
    abstract class ERDAdapter
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


        //Fetch full Researcher details from database
        public static Researcher FetchFullResearcherDetails(int ResearcherID)
        {
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

				// Or could use select *
                MySqlCommand cmd = new MySqlCommand("select id, type, given_name, family_name, 
                	title, unit, campus, email, photo, degree, supervisor_id, level, utas_start, 
                	current_start from researcher where id=?ResearcherID", conn);
                rdr = cmd.ExecuteReader();

				//Researcher information
				List<Position> Positions = new List<Position>;
				int ID = rdr.GetInt32(0);
				Type CurrentType = ParseEnum<Type>(rdr.GetString(1));
				String GivenName = rdr.GetString(2);
				String FamilyName = rdr.GetString(3);
				String Title = rdr.GetString(4);
				String Unit = rdr.GetString(5);
				Researcher.Campus CurrentCampus = ParseEnum<Researcher.Campus>(rdr.GetString(6));
				String Email = rdr.GetString(7);
				String Photo = rdr.GetString(8);
				String Degree = rdr.GetString(9);		
				int SupervisorID = rdr.GetString(10);	
				String Level = rdr.GetString(11);
				String UtasStart = rdr.GetDateTime(12);
				String CurrentStart = rdr.GetDateTime(13);
				
				Position CurrentPosition = new Position { EmploymentLevel = Level, Start = CurrentStart, End = NULL};
				
				Positions.add(CurrentPosition);
				
				//Create new researcher 
				Researcher FullResearcher = new Researcher { ID = this.ID, CurrentType = this.CurrentType, 
					GivenName = this.GivenName, FamilyName = this.FamilyName, Title = this.Title, 
					Unit = this.Unit, CurrentCampus = CurrentCampus, Email = this.Email, 
					Photo = this.Photo, Degree = this.Degree, SupervisorID = this.SupervisorID, Positions = this.Positions
				};
               
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

            return FullResearcher;
        }
        

        // Fetch basic details for Researchers
        public static List<Researcher> FetchBasicResearcherDetails()
        {
            List<Researcher> BasicResearchers = new List<Researcher>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();
				
                MySqlCommand cmd = new MySqlCommand("select id, type, given_name, family_name, title, level, photo from researcher", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    BasicResearchers.Add(new Researcher { ID = rdr.GetInt32(0), 
                    Type = ParseEnum<Researcher.Type>(rdr.GetString(1)), GivenName = rdr.GetString(2), 
                    FamilyName = rdr.GetString(3), Title = rdr.GetString(4),
                    Positions = new List<Position> {new Position {EmploymentLevel = ParseEnum<Position.EmploymentLevel>(rdr.GetString(5)), Start = NULL, End = NULL}},
                    Photo = rdr.GetString(6)
                    });
                }
            }
            catch (MySqlException e)
            {
                ReportError("loading staff", e);
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




        //For step 2.3 in Week 8 tutorial
        public static List<TrainingSession> LoadTrainingSessions(int id)
        {
            List<TrainingSession> work = new List<TrainingSession>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select title, year, type, available " +
                                                    "from publication as pub, researcher_publication as respub " +
                                                    "where pub.doi=respub.doi and researcher_id=?id", conn);

                cmd.Parameters.AddWithValue("id", id);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    work.Add(new TrainingSession
                    {
                        Title = rdr.GetString(0),
                        Year = rdr.GetInt32(1),
                        Mode = ParseEnum<Mode>(rdr.GetString(2)),
                        Certified = rdr.GetDateTime(3)
                    });
                }
            }
            catch (MySqlException e)
            {
                ReportError("loading training sessions", e);
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

            return work;
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
                MessageBox.Show("An error occurred while " + msg + ". Try again later.\n\nError Details:\n" + e,
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
