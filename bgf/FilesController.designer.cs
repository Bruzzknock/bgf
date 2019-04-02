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
    [Register ("FilesController")]
    partial class FilesController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITabBarItem Files { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Files != null) {
                Files.Dispose ();
                Files = null;
            }
        }
    }
}