using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace bgf.Static_Resources
{
    public class File
    {
        private string title;
        private UIImage image;
        private string url;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public UIImage Image
        {
            get { return image; }
            set { image = value; }
        }

        public string URL
        {
            get { return url; }
            set { url = value; }
        }

        public bool Show;

        public File(UIImage image,string title, string url,bool show)
        {
            this.image = image;
            this.title = title;
            this.url = url;
            this.Show = show;
        }
    }
}