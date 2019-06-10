using Foundation;
using System;
using UIKit;
using bgf.Static_Resources;
using System.Collections.Generic;
using bgf.Model;


namespace bgf
{
    public partial class CustomEvent : UIViewController
    {
        private DateTime date;
        public int e_ID;
        public String e_Bezeichnung;
        public String e_Beschreibung;
        public DateTime e_Datum;
        public TimeSpan e_Bis;
        public TimeSpan e_Von;
        int counter = 0;


        List< Events_Tasks> e;
        //private int counter;

        public CustomEvent (IntPtr handle) : base (handle)
        {
        }

        public CustomEvent()
        {

        }

        public void setDate(DateTime date)
        {
            this.date = date;
        }

        /*public override void ViewDidLoad()
        {
            lblDatum.Text = date.ToShortDateString();
            lblDescription.Text = "Here will be short description of the event";
            this.Title = "Event Name";
        }*/

        public override void ViewDidLoad()
        {

            
            base.ViewDidLoad();



            lblDatum.Text = e_Datum.ToShortDateString();
            lblDescription.Text = e_Beschreibung;
            lblBis.Text = e_Bis.ToString();
            lblVon.Text = e_Von.ToString();

            if (e_ID == Events.ID)
            {

                if (ConnectionManager.GetT() == false)
                {
                    btnAnAbmelden.TouchUpInside += (sender, e) =>
                    {





                        new UIAlertView("Anmeldung", "Sie haben sich angemeldet.", null, "Ok", null).Show();
                        btnAnAbmelden.SetTitle("Anmeldung", forState: UIControlState.Disabled);

                        ConnectionManager.InsertData();
                        btnAnAbmelden.Hidden = true;
                    
                   

                    };
                }
                else
                {
                    btnAnAbmelden.Hidden = true;
                }

            }









        }
        
           
        

        public int GetE_ID()
        {
           return e_ID;
        }

        

    }
}