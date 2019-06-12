using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
/*In dieser Klasse wird die Attribute vom Benutzer implementiert*/
namespace bgf.Static_Resources
{
    public static class Benutzer
    {
        public static int ID { get; set; }
        public static string Username { get; set; }
        public static string Email { get; set; }
        public static string Rolle { get; set; }
    }
}