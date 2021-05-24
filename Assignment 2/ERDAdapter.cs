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

		//Need to add multiple positions, publications, student supervised
        //Fetch full Researcher details from database
        public static Researcher FetchFullResearcherDetails(int ResearcherID)
        {
        	List<Position> Positions = new List<Position>(); // List of Researcher's previous and current Positions
        	
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

				// Or could use select *
                MySqlCommand cmd = new MySqlCommand("select id, type, given_name, family_name," +
                	"title, unit, campus, email, photo, degree, supervisor_id, level, utas_start," + 
                	"current_start from researcher where id=?ResearcherID", conn);
                rdr = cmd.ExecuteReader();

				//Researcher information
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
				Position.EmploymentLevel Level = ParseEnum<Position.EmploymentLevel>(rdr.GetString(11));
				String UtasStart = rdr.GetDateTime(12);
				String CurrentStart = rdr.GetDateTime(13);
				
				Position CurrentPosition = new Position { EmploymentLevel = Level, Start = CurrentStart, End = NULL};
				
				Positions.Add(CurrentPosition);
				
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

        // Fetch basic details for all Researchers
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
                    	Positions = new List<Position>() {new Position {EmploymentLevel = ParseEnum<Position.EmploymentLevel>(rdr.GetString(5)), Start = NULL, End = NULL}},
                    	Photo = rdr.GetString(6)
                    });
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
				MySqlCommand cmd = new MySqlCommand("select * from researcher where id=?ResearcherID", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
					//Update Researcher information
					BasicResearcher.Unit = rdr.GetString(5);
					BasicResearcher.CurrentCampus = ParseEnum<Researcher.Campus>(rdr.GetString(6));
					BasicResearcher.Email = rdr.GetString(7);
					BasicResearcher.Photo = rdr.GetString(8);
					BasicResearcher.Degree = rdr.GetString(9);		
					BasicResearcher.SupervisorID = rdr.GetString(10);
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

            return BasicResearchers;
        }


        //Fetch full Researcher Position history 
        public static Researcher FetchFullResearcherPositions(Researcher R)
        {
        	int ID = R.ID; // Researcher's ID
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select * from position where id=?ID", conn);
                rdr = cmd.ExecuteReader();

				  while (rdr.Read())
                {
                    Position.EmploymentLevel Level = ParseEnum<Position.EmploymentLevel>(rdr.GetString(1));
					DateTime Start = rdr.GetDateTime(2);
					DateTime End = rdr.GetDateTime(3);
					
					if(End != NULL){
						R.Positions.Add(new Position {EmploymentLevel = Level, Start = this.Start, End = this.End});
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

            return FullResearcher;
        }


        // Fetch basic details for all Publications by a Researcher
        public static List<Publication> FetchBasicPublicationDetails(Researcher R)
        {
        	List<String> DOIList = new List<String>();	// List of Researcher's Publication DOIs
            List<Publication> BasicPublications = new List<Publication>();
            
            int ID = R.ID;	// Researcher's ID
            String cDOI = ""; // The current DOI for searching

			// Fetch all Researcher's Publication's DOI
			try
            {
            	MySqlConnection conn = GetConnection();
				MySqlDataReader rdr = null;
                conn.Open();
				
				MySqlCommand cmd = new MySqlCommand("select doi from researcher_publication where researcher_id=?ID", conn);
				rdr = cmd.ExecuteReader();

				while (rdr.Read())
				{
					DOIList.Add( rdr.GetString(0) );
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
			
			
            try
            {
				MySqlConnection conn = GetConnection();
				MySqlDataReader rdr = null;
                conn.Open();
				
				while (DOIList.Count != 0) {
					// Get next DOI
					cDOI = DOIList[0];
				
					MySqlCommand cmd = new MySqlCommand("select title, year from publication where doi=?cDOI", conn);
					rdr = cmd.ExecuteReader();

					while (rdr.Read())
					{
						BasicPublications.Add(new Publication { DOI = cDOI, Title = rdr.GetString(0), Year = rdr.GetInt32(1) });
					}
					
					DOIList.Remove(0);
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
					P.Type = ParseEnum<Publication.OutputType>(rdr.GetString(4));
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
        	
    		for(int i=0; i<Pcount.Length; i++){
    			PCount[i] = 0;	// Set default value
    		
    			for(int j=0; j<P.Count; j++){
    				if(P[j].Year == (To + i)){
    					PCount++;
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
                MessageBox.Show("An error occurred while " + msg + ". Try again later.\n\nError Details:\n" + e,
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
