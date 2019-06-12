using Foundation;
using System;
using UIKit;

namespace bgf
{
    public partial class SettingController : UIViewController
    {
        UIViewController owner;

        public SettingController (IntPtr handle) : base (handle)
        {
        }

        public SettingController(EventController eventController)
        {
            this.owner = eventController;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            btnAbmelden.TouchUpInside += (sender, e) =>
            {
                bgf.Helpers.Settings.Clear();


            };

        }
    }
}