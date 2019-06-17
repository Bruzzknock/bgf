using bgf.Model;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace bgf
{
    public partial class InteresstsCustomCell : UITableViewCell
    {
        private Interrests interest;


        public InteresstsCustomCell (IntPtr handle) : base (handle)
        {
            this.SelectionStyle = UITableViewCellSelectionStyle.None;
        }

        public void setInteresst(Interrests interest)
        {
            this.interest = interest;
            lblTitle.Text = this.interest.Title;
            imgSelected.Image = this.interest.Image;
        }

        public void UpdateInteresst(Interrests i)
        {
            /*interest = i;
            if (interest.IsSelected)
            {
                interest.IsSelected = !interest.IsSelected;
                interest.Image = new UIImage("uncheck.png");
                imgSelected.Image = interest.Image;
            }
            else
            {
                interest.IsSelected = !interest.IsSelected;
                interest.Image = new UIImage("check.png");
                imgSelected.Image = interest.Image;
            }*/
        }
    }
}