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
        UIKit.UITableView filesTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (filesTableView != null) {
                filesTableView.Dispose ();
                filesTableView = null;
            }
        }
    }
}