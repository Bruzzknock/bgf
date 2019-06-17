using bgf.Static_Resources;
using Foundation;
using System;
using UIKit;

namespace bgf
{
    public partial class PasswortController : UIViewController
    {
        public PasswortController (IntPtr handle) : base (handle)
        {
        }

        partial void BtnChange_TouchUpInside(UIButton sender)
        {
            if (AreThePasswordsSame())
            {
                if (ConnectionManager.isOldPasswordCorrect(txtAltes.Text.Trim()))
                {
                    ConnectionManager.updatePassword(txtNeues.Text.Trim());

                    new UIAlertView("Password updated", "Password is updated", null, "OK", null).Show();
                    txtNeues.Text = "";
                    txtAltes.Text = "";
                    txtWiederholen.Text = "";
                    bgf.Helpers.Settings.Clear();
                }
                else
                    new UIAlertView("Incorrect password", "Old password is incorrect", null, "OK", null).Show();
            }
        }

        private bool AreThePasswordsSame()
        {
            if (txtNeues.Text == txtWiederholen.Text)
                return true;
            else
            {
                new UIAlertView("Passwords mismatch", "There is a password mismatch", null, "OK", null).Show();

                return false;
            }
        }
    }
}