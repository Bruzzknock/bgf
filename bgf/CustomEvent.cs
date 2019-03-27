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

        public void setDate(DateTime date)
        {
            this.date = date;
        }

        public override void ViewDidLoad()
        {
            lblDatum.Text = date.ToShortDateString();
            lblDescription.Text = "Here will be short description of the event";
            this.Title = "Event Name";
        }
    }
}