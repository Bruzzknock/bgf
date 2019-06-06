using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bgf.Model;
using bgf.Static_Resources;
using Foundation;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cms;
using UIKit;

namespace bgf.Static_Resources
{
    public static class ConnectionManager
    {
        static string connStr = "server=bak.teamoddity.com;user=root;database=BAK;password=BAKpasswd";
        static MySqlConnection conn = new MySqlConnection(connStr);

        public static bool Anmelden(string username, string password)
        {
            bool loggedIn = false;

            try
            {
                Debug.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT * FROM Benutzer where Benutzer_Name = @username AND Benutzer_Passwort = @password;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username",username);
                cmd.Parameters.AddWithValue("@password", password);

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    loggedIn = true;

                    Benutzer.ID = (int)rdr[0];
                    Benutzer.Username = (string)rdr[1];
                    Benutzer.Email = (string)rdr[2];
                    Benutzer.Rolle = (string)rdr[4];
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            conn.Close();
            Debug.WriteLine("Done.");

            return loggedIn;
        }

        public static List<File> GetFiles()
        {
            List<File> files = new List<File>();

            try
            {
                Debug.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT * FROM Archiv;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    File f = new File();
                    f.ID = (int)rdr[0];
                    f.Title = (string)rdr[1];
                    f.URL = "http://bak.teamoddity.com" + (string)rdr[2];
                    f.Date = (DateTime)rdr[3];
                    f.isMagazine = isMagazine((string)rdr[4]);
                    f.Image = f.isMagazine ? new UIImage("pdf.png") : new UIImage("videoicon.png");
                    f.Interest = (interest)rdr[5];

                    files.Add(f);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            conn.Close();
            Debug.WriteLine("Done.");

            return files;
        }
        
        public static List<File> GetFiles(string date,string interest, string type)
        {
            List<File> files = new List<File>();

            try
            {
                Debug.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT * FROM Archiv WHERE ";

                if (date != "Alle")
                {
                    sql += "year(Archiv_Datum) = " + date + " ";
                }

                if (interest != "Alle")
                {
                    sql += date != "Alle" ? "AND Interessen_ID =" + Interests.GetIdByDesc(interest) + " " : "Interessen_ID =" + Interests.GetIdByDesc(interest) + " ";
                }

                if (type != "Alle")
                {
                    sql += date != "Alle" || interest != "Alle" ? "AND Archiv_Format = '" + type + "';" : "Archiv_Format = '" + type + "';";
                }

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    File f = new File();
                    f.ID = (int)rdr[0];
                    f.Title = (string)rdr[1];
                    f.URL = "http://bak.teamoddity.com/data/" + (string)rdr[2];
                    f.Date = (DateTime)rdr[3];
                    f.isMagazine = isMagazine((string)rdr[4]);
                    f.Image = f.isMagazine ? new UIImage("pdf.png") : new UIImage("videoicon.png");
                    f.Interest = (interest)rdr[5];

                    files.Add(f);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            conn.Close();
            Debug.WriteLine("Done.");

            return files;
        }

        public static string[] GetDates()
        {
            List<string> dates = new List<string>();
            dates.Add("Alle");

            try
            {
                Debug.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT DISTINCT year(Archiv_Datum) FROM Archiv;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    dates.Add(((int)rdr[0]).ToString());
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            conn.Close();
            Debug.WriteLine("Done.");

            return dates.ToArray();
        }

        public static string[] GetInterests()
        {
            List<string> interests = new List<string>();
            interests.Add("Alle");
            List<int> interestsID = new List<int>();
            interestsID.Add(0);

            try
            {
                Debug.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT * FROM Interessen;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    interestsID.Add((int)rdr[0]);
                    interests.Add((string)rdr[1]);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            conn.Close();
            Debug.WriteLine("Done.");

            Interests.ID = interestsID.ToArray();
            Interests.Interest_Desc = interests.ToArray();

            return interests.ToArray();
        }

        public static string[] GetType()
        {
            List<string> types = new List<string>();
            types.Add("Alle");

            try
            {
                Debug.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT DISTINCT Archiv_Format FROM Archiv;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    types.Add((string)rdr[0]);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            conn.Close();
            Debug.WriteLine("Done.");

            return types.ToArray();
        }

        public static List<Events_Tasks> GetEvents()
        {
            List<Events_Tasks> events = new List<Events_Tasks>();
            

            try
            {
                Debug.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT Event_ID, Event_Bezeichnung, Event_Datum, Event_Beschreibung, Event_Von, Event_Bis FROM Events;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while(rdr.Read())
                {
                    Events_Tasks e = new Events_Tasks();

                    e.E_ID = (int)rdr[0];
                    e.E_Bezeichnung = (string)rdr[1];
                    e.E_Date = (DateTime)rdr[2];
                    e.E_Beschreibung = (string)rdr[3];
                    e.E_Von = (TimeSpan)rdr[4];
                    e.E_Bis = (TimeSpan)rdr[5];

                    

                    events.Add(e);
                }
                rdr.Close();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            conn.Close();
            Debug.WriteLine("Done.");

            return events;
        }

        private static bool isMagazine(string type)
        {
            if (type.Contains("pdf"))
                return true;
            else
                return false;
        }
    }
}