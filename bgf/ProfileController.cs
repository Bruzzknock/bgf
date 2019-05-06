using Foundation;
using System;
using UIKit;

namespace bgf
{
    public partial class ProfileController : UIViewController
    {
        public ProfileController (IntPtr handle) : base (handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            profileImage.Image = UIImage.FromBundle("bak2.jpg");

            User_Label.Text = "kica";
            CreditPoints_Label.Text = "10";
        }
    }
}