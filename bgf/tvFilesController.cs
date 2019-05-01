using bgf.Static_Resources;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace bgf
{
    public partial class tvFilesController : UIViewController
    {
        public List<File> data = new List<File>();

        public tvFilesController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            UIImage image = new UIImage("bak2.jpg");
            data.Add(new File(image, "Prvi ajtem", "neki url",false));
            data.Add(new File(image, "Drugi ajtem", "url",true));

            filesTableView.Source = new FileTVS(data,this);
            filesTableView.RowHeight = 80;
            filesTableView.ReloadData();
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            var filesController = segue.DestinationViewController as FilesController;

            if (filesController != null)
            {
                filesController.show = false;
            }
        }
    }
}