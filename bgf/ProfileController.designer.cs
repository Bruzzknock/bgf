// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace bgf
{
    [Register ("ProfileController")]
    partial class ProfileController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel CreditPoints_Label { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView profileImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel User_Label { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CreditPoints_Label != null) {
                CreditPoints_Label.Dispose ();
                CreditPoints_Label = null;
            }

            if (profileImage != null) {
                profileImage.Dispose ();
                profileImage = null;
            }

            if (User_Label != null) {
                User_Label.Dispose ();
                User_Label = null;
            }
        }
    }
}