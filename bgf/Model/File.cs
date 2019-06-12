using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
/*In dieser Klasse wird die Attribute vom Archiv implementiert*/
namespace bgf.Model
{
    public enum interest { Journal = 1, Sport, Essen, Video, Gesundheit, Buecher, Praesentation};
    public class File
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public interest Interest { get; set; }
        public UIImage Image { get; set; }
        public string URL { get; set; }
        public bool isMagazine { get; set; }
        public DateTime Date { get; set; }
    }

}