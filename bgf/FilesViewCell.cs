using System;
using bgf.Static_Resources;
using Foundation;
using UIKit;

namespace bgf
{
    public partial class FilesViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("FilesViewCell");
        public static readonly UINib Nib;

        static FilesViewCell()
        {
            Nib = UINib.FromName("FilesViewCell", NSBundle.MainBundle);
            
        }

        protected FilesViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public void setFile(File file)
        {
            imgThumbnail.Image = file.Image;
            lblName.Text = file.Title;
        }
    }
}
