using Foundation;
using System;
using UIKit;

namespace bgf
{
    public partial class CustomEvent : UIViewController
    {
        private DateTime date;
        public CustomEvent (IntPtr handle) : base (handle)
        {
        }

        public CustomEvent(DateTime date)
        {
            this.date = date;
            //lblDatum.Text = date.ToString();
            //lblDescription.Text = "Here will be short description of the event";
            //this.Title = "Event Name";
        }
    }
}