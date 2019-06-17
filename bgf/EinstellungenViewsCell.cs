using bgf.Model;
using Foundation;
using System;
using UIKit;

namespace bgf
{
    public partial class EinstellungenViewsCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("EinstellungenViewsCell");
        public static readonly UINib Nib;
        public EinstellungenViewsCell (IntPtr handle) : base (handle)
        {

        }

        static EinstellungenViewsCell()
        {
            Nib = UINib.FromName("EinstellungenViewsCell", NSBundle.MainBundle);
        }

        /*In dieser Methode werden die File_Name und Bild implementiert*/
        public void setFile(Einstellungen file)
        {
            lblTitle.Text = file.Label;
        }
    }
}