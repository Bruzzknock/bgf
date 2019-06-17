using Foundation;
using System;
using UIKit;
using bgf.Static_Resources;
using bgf.Model;
using System.Collections.Generic;

/*In dieser Klasse wird die TableView initialisiert und die Events vom ConnectionManager.cs benutzt*/
namespace bgf
{
    public partial class EventController : UIViewController
    {
       public List<Events_Tasks> ev;
        
        public EventController (IntPtr handle) : base (handle)
        {

        }

        /*Mit dieser Methode wird die TableView initialisert beim Laden*/
        public override void ViewDidLoad()
        {
            ev = ConnectionManager.GetEvents();
            eventsTableView.Source = new EventsTV(ev, this);
            eventsTableView.RowHeight = 80;
            eventsTableView.ReloadData();
            
        }

        
    }
}