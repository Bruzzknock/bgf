using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bgf;
using Foundation;
using Org.BouncyCastle.Asn1.Cms;
using UIKit;
/*In dieser Klasse wird die Attribute vom Events implementiert*/
namespace bgf.Model
{
    public class Events_Tasks
    {
        public int E_ID { get; set; }

        public string E_Bezeichnung { get; set; }

        public DateTime E_Date { get; set; }

        public string E_Beschreibung { get; set; }

        public TimeSpan E_Von { get; set; }

        public TimeSpan E_Bis { get; set; }

        /*Default Konstruktor*/
        public Events_Tasks()
        {
            this.E_ID = E_ID;
            this.E_Date = E_Date;
            this.E_Bezeichnung = E_Bezeichnung;
            this.E_Beschreibung = E_Beschreibung;
            this.E_Von = E_Von;
            this.E_Bis = E_Bis;
        }

        
    }
    

}