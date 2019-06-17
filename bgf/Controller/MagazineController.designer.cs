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
    [Register ("MagazineController")]
    partial class MagazineController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnGo { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnNext { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnPrev { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtPage { get; set; }

        [Action ("BtnGo_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnGo_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnNext_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnNext_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnPrev_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnPrev_TouchUpInside (UIKit.UIButton sender);

        [Action ("txtPage_TextChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void txtPage_TextChanged (UIKit.UITextField sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnGo != null) {
                btnGo.Dispose ();
                btnGo = null;
            }

            if (btnNext != null) {
                btnNext.Dispose ();
                btnNext = null;
            }

            if (btnPrev != null) {
                btnPrev.Dispose ();
                btnPrev = null;
            }

            if (txtPage != null) {
                txtPage.Dispose ();
                txtPage = null;
            }
        }
    }
}