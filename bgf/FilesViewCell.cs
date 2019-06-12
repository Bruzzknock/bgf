using System;
using bgf.Model;
using bgf.Static_Resources;
using Foundation;
using UIKit;
/*In dieser Klasse wird die FileCell initialisert */
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
            // Note: this .ctor should not contain any initialization logic.user
        }

        /*In dieser Methode werden die File_Name und Bild implementiert*/
        public void setFile(File file)
        {
            imgThumbnail.Image = file.Image;
            lblName.Text = file.Title;
        }
    }
}
