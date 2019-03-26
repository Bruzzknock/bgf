using Foundation;
using System;
using UIKit;

namespace bgf
{
    public partial class CalendarView : UIViewController
    {
        public CalendarView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            this.View.BackgroundColor = UIColor.LightGray;
            lblCurrentMonth.Text = DateTime.Now.Month.ToString();
            btnPreviousMonth.SetTitle((DateTime.Now.Month - 1).ToString(),UIControlState.Normal);
            btnNextMonth.SetTitle((DateTime.Now.Month + 1).ToString(), UIControlState.Normal);

            CustomEvent customEvent;            

            btnFirstDay.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(new DateTime(DateTime.Now.Year,Convert.ToInt32(lblCurrentMonth.Text),1));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnSecondDay.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(new DateTime(DateTime.Now.Year, Convert.ToInt32(lblCurrentMonth.Text), 2));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnThirdDay.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(new DateTime(DateTime.Now.Year, Convert.ToInt32(lblCurrentMonth.Text), 3));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnFourthDay.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(new DateTime(DateTime.Now.Year, Convert.ToInt32(lblCurrentMonth.Text), 4));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnFifthDay.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(new DateTime(DateTime.Now.Year, Convert.ToInt32(lblCurrentMonth.Text), 5));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnSixthDay.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(new DateTime(DateTime.Now.Year, Convert.ToInt32(lblCurrentMonth.Text), 6));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnSeventhDay.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(new DateTime(DateTime.Now.Year, Convert.ToInt32(lblCurrentMonth.Text), 7));
                this.NavigationController.PushViewController(customEvent, true);
            };
        }
    }
}