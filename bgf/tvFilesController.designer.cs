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
    [Register ("tvFilesController")]
    partial class tvFilesController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnFilter { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnInterest { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnType { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnYear { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView filesTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView uiPicker { get; set; }

        [Action ("BtnFilter_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnFilter_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnInterest_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnInterest_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnType_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnType_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnYear_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnYear_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnFilter != null) {
                btnFilter.Dispose ();
                btnFilter = null;
            }

            if (btnInterest != null) {
                btnInterest.Dispose ();
                btnInterest = null;
            }

            if (btnType != null) {
                btnType.Dispose ();
                btnType = null;
            }

            if (btnYear != null) {
                btnYear.Dispose ();
                btnYear = null;
            }

            if (filesTableView != null) {
                filesTableView.Dispose ();
                filesTableView = null;
            }

            if (uiPicker != null) {
                uiPicker.Dispose ();
                uiPicker = null;
            }
        }
    }
}