using Foundation;
using System;
using UIKit;
using AVKit;
using AVFoundation;
/*In dieser Klasse wird das anzeigen von Videos implementiert*/
namespace bgf
{
    public partial class VideosController : UIViewController
    {
        public string VideoURL { get; set; }

        public VideosController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
        }
    }
}