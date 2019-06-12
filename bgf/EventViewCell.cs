using bgf.Model;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;
/*In dieser Klasse wird die EventCell implementiert für die Veranstaltungen*/
namespace bgf
{
    public partial class EventViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("EventViewCell");
        public static readonly UINib Nib;

        static EventViewCell()
        {
            Nib = UINib.FromName("EventViewCell", NSBundle.MainBundle);

        }

      

        protected EventViewCell (IntPtr handle) : base (handle)
        {

            
        }
        
        /*Die Event_Datum, Event_Bezeichnung werden hier übergeben*/
        public void setEvent(Events_Tasks ev)
        {
            lblDatum.Text = ev.E_Date.ToShortDateString();
            lblName.Text = ev.E_Bezeichnung;
        }
    }
}