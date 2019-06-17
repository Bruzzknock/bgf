using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bgf.Model;
using bgf.Static_Resources;
using Foundation;
using MySql.Data.MySqlClient;
using UIKit;
using Xamarin.Auth;
/*
* Hier ist die Verbindung mit der Datenbank. Es werden jeweils die Dokumente (Magazine, Videos, Präsentationen) und die Events hier
* abgerufen.*/




namespace bgf.Static_Resources
{
    public static class ConnectionManager
    {
        //Die Verbindungsdaten zur Datenbank wird hier als String gespeichert.
        static string connStr = "server=bak.teamoddity.com;user=root;database=BAK;password=BAKpasswd";
        static MySqlConnection conn = new MySqlConnection(connStr);
        static string URLAddon = "http://bak.teamoddity.com";

        //Das Login wird mit dieser Methode überprüft, ob ein User vorhanden ist oder nicht.
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

        public static void updatePassword(string password)
        {
            try
            {
                Debug.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "UPDATE `Benutzer` SET `Benutzer_Passwort` = @password WHERE Benutzer_Name = @username;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", Benutzer.Username);
                cmd.Parameters.AddWithValue("@password", password);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            conn.Close();
            Debug.WriteLine("Done.");
        }

        public static bool isOldPasswordCorrect(string password)
        {
            bool oldPassword = false;

            try
            {
                Debug.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT * FROM Benutzer where Benutzer_Name = @username AND Benutzer_Passwort = @password;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", Benutzer.Username);
                cmd.Parameters.AddWithValue("@password", password);

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    oldPassword = true;
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            conn.Close();
            Debug.WriteLine("Done.");

            return oldPassword;
        }

        /*Mit dieser Methode werden die Magazine, Videos, Präsentationen aus der Datenbank ausgelesen */
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
                    f.URL = URLAddon + (string)rdr[2];
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


        /*Mit dieser Methode werden die Magazine, Videos, Präsentationen aus der Datenbank ausgelesen 
           und jeweils nach Interessen gefiltert*/
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
                    f.URL = URLAddon + (string)rdr[2];
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

        /*Mit dieser Methode werden Teilnehmer von Events in die Datenbank eingetragen*/
        public static void InsertData()
        {
            try
            {
                Debug.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "Select * From Benutzer_Event;";
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sql, conn);

                DataSet ds = new DataSet("Events_Eintragung");

                sqlDataAdapter.FillSchema(ds, SchemaType.Source, "Benutzer_Events");
                sqlDataAdapter.Fill(ds, "Benutzer_Events");

                DataTable tblBE;
                tblBE = ds.Tables["Benutzer_Events"];

                DataRow drCurrent;
                drCurrent = tblBE.NewRow();


                drCurrent["Benutzer_ID"] = Benutzer.ID;
                drCurrent["Event_ID"] = Events.ID;

                tblBE.Rows.Add(drCurrent);

                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(sqlDataAdapter);
                sqlDataAdapter.Update(ds, "Benutzer_Events");
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            conn.Close();
            Debug.WriteLine("Done.");

        }

        /*Mit dieser Methode werden die Datum von der Magazine, Videos, Präsentationen aus der Datenbank ausgelesen */
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

        /*Mit dieser Methode werden die Interressen aus der Datenbank ausgelesen*/
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

        public static void UpdateInterests(List<bool> selectedList)
        {
            try
            {
                Debug.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "DELETE FROM `Benutzer_Interessen` WHERE Benutzer_ID = @id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", Benutzer.ID);

                cmd.ExecuteNonQuery();

                //treba insertinto
                for(int i = 1;i < selectedList.Count;i++)
                {
                    if (selectedList[i])
                    {
                        string sql1 = "INSERT INTO Benutzer_Interessen (Benutzer_ID, Interessen_ID) VALUES(@id, @val);";

                        MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                        cmd1.Parameters.AddWithValue("@username", Benutzer.ID);
                        cmd1.Parameters.AddWithValue("@val", Interests.ID[i]);

                        cmd1.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            conn.Close();
            Debug.WriteLine("Done.");
        }

        public static List<int> GetInterestsFromUser()
        {
            List<int> interestsID = new List<int>();
            interestsID.Add(0);

            try
            {
                Debug.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT * FROM Benutzer_Interessen WHERE Benutzer_ID = @id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", Benutzer.ID);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    interestsID.Add((int)rdr[1]);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            conn.Close();
            Debug.WriteLine("Done.");

            return interestsID;
        }

        /*Mit dieser Methode werden die Datentypen der Dokumente aus der Datenbank ausgelesen*/
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

        /*Mit dieser Methode werden die Veranstaltungen aus der Datenbank ausgelesen*/
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

        /*Mit dieser Methode werden die Teilnehmer einer Veranstaltung ausgelesen*/
        public static bool GetT()
        {
            Boolean angemeldet = false;
            int count = 0;

            try
            {
                Debug.WriteLine("Connecting to MySLQ...");
                conn.Open();


                string sql = "Select Count(*) FROM Benutzer_Event WHERE Benutzer_ID=" + Benutzer.ID + " && Event_ID=" + Events.ID + ";";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                
                while(rdr.Read())
                {
                    count = (int)rdr[0];
                }
                rdr.Close();
                if(count > 1)
                {
                    angemeldet = true;
                }
                else
                {
                    angemeldet = false;
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            conn.Close();
            Debug.WriteLine("Done.");
            return angemeldet;
        }

        /*Mit dieser Methode der Datentyp "pdf" abgfragt um zu wissen ob es eine Magazin ist oder nicht*/
        private static bool isMagazine(string type)
        {
            if (type.Contains("pdf"))
                return true;
            else
                return false;
        }
    }
}