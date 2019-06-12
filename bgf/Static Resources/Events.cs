using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation;
using UIKit;
/*In dieser Klasse wird die Events und deren Attribute statisch implementiert*/
namespace bgf.Static_Resources
{
    
   public static class Events
   {
        public static DateTime[] Event_Date { get; set; }
        public static string[] Description { get; set; }
        public static int ID { get; set; }
   }
}