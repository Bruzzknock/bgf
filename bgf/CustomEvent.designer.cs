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
    [Register ("CustomEvent")]
    partial class CustomEvent
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnAnAbmelden { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblDatum { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblDescription { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnAnAbmelden != null) {
                btnAnAbmelden.Dispose ();
                btnAnAbmelden = null;
            }

            if (lblDatum != null) {
                lblDatum.Dispose ();
                lblDatum = null;
            }

            if (lblDescription != null) {
                lblDescription.Dispose ();
                lblDescription = null;
            }
        }
    }
}