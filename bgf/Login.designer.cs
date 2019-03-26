// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace bgf
{
    [Register ("Login")]
    partial class Login
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnAnmelden { get; set; }

        [Action ("anmelden:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void anmelden (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnAnmelden != null) {
                btnAnmelden.Dispose ();
                btnAnmelden = null;
            }
        }
    }
}