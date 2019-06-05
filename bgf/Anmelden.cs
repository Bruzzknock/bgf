
using System;
using System.Drawing;
using bgf.Static_Resources;
using Foundation;
using UIKit;

namespace bgf
{
    public partial class Anmelden : UIViewController
    {
        public event EventHandler OnLoginSuccess;

        public Anmelden(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        partial void BtnAnmelden_TouchUpInside(UIButton sender)
        {            
            if (ConnectionManager.Anmelden(txtUsername.Text,txtPassword.Text))
                OnLoginSuccess(this, new EventArgs());
                //if(txtUsername.Text == "Betina" && txtPassword.Text == "123" )
                //{
                //OnLoginSuccess(this, new EventArgs());
                //}
            else
                new UIAlertView("Login Error","Bad username or password",null,"OK",null).Show();
        }

        #endregion
    }
}