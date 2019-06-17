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
    [Register ("PasswortController")]
    partial class PasswortController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnChange { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtAltes { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtNeues { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtWiederholen { get; set; }

        [Action ("BtnChange_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnChange_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnChange != null) {
                btnChange.Dispose ();
                btnChange = null;
            }

            if (txtAltes != null) {
                txtAltes.Dispose ();
                txtAltes = null;
            }

            if (txtNeues != null) {
                txtNeues.Dispose ();
                txtNeues = null;
            }

            if (txtWiederholen != null) {
                txtWiederholen.Dispose ();
                txtWiederholen = null;
            }
        }
    }
}