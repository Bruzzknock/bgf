using bgf.Model;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

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
        

       

        
        public void setEvent(Events_Tasks ev)
        {
            lblDatum.Text = ev.E_Date.ToShortDateString();
            lblName.Text = ev.E_Bezeichnung;
        }
    }
}