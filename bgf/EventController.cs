using Foundation;
using System;
using UIKit;
using bgf.Static_Resources;
using bgf.Model;
using System.Collections.Generic;

namespace bgf
{
    public partial class EventController : UIViewController
    {
       public List<Events_Tasks> ev;
        
        public EventController (IntPtr handle) : base (handle)
        {

        }

        public override void ViewDidLoad()
        {
            ev = ConnectionManager.GetEvents();
            eventsTableView.Source = new EventsTV(ev, this);
            eventsTableView.RowHeight = 80;
            eventsTableView.ReloadData();
            
        }

        private CustomEvent createCustomEventVC(int day)
        {
            CustomEvent customEvent = (CustomEvent)this.Storyboard.InstantiateViewController("CustomEvent");
            customEvent.setDate(new DateTime(DateTime.Now.Year, 3, day));
            return customEvent;
        }
    }
}