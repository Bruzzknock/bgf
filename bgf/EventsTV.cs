using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation;
using UIKit;
using AVFoundation;
using AVKit;
using bgf.Model;
using bgf.Static_Resources;

/*In dieser Klasse wird das Table View initialisier. Diese zeigt die verschiedenen Events an*/
namespace bgf
{
    class EventsTV : UITableViewSource
    {

        List<Events_Tasks> events;
        UIViewController owner;

        /*Default Konstruktor*/
        public EventsTV(List<Events_Tasks> events, EventController eventController)
        {
            this.events = events;
            this.owner = eventController;
           
        }

        /*Mit dieser Methode wird die Zelle einer TableView initialisiert*/
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (EventViewCell)tableView.DequeueReusableCell("EventsCell", indexPath);
            var ev = events[indexPath.Row];
            cell.setEvent(ev);
            return cell;
        }

        /*Mit dieser Methode wird die Anzahl von Reihen*/
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return events.Count;
        }

        /*Mit dieser Methode werden die Events in der CustomEvent initialisert und im Customevent angezeigt*/
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {


            CustomEvent customevent = owner.Storyboard.InstantiateViewController("CustomEvent") as CustomEvent;
            if (customevent != null)
            {
                customevent.e_ID = events[indexPath.Row].E_ID;
                customevent.e_Datum = events[indexPath.Row].E_Date;
                customevent.e_Beschreibung = events[indexPath.Row].E_Beschreibung;
                customevent.e_Von = events[indexPath.Row].E_Von;
                customevent.e_Bis = events[indexPath.Row].E_Bis;
                owner.NavigationController.PushViewController(customevent, true);

                Events.ID = events[indexPath.Row].E_ID;
            }
            

        }


    }
}