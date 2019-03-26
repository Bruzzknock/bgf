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
        //setup Calendar is pushed
        public override void ViewDidLoad()
        {
            this.View.BackgroundColor = UIColor.LightGray;
            lblCurrentMonth.Text = DateTime.Now.Month.ToString();
            btnPreviousMonth.SetTitle((DateTime.Now.Month - 1).ToString(),UIControlState.Normal);
            btnNextMonth.SetTitle((DateTime.Now.Month + 1).ToString(), UIControlState.Normal);

            CustomEvent customEvent;            

            btnFirstDay.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(1));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnSecondDay.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(2));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnThirdDay.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(3));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnFourthDay.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(4));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnFifthDay.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(5));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnSixthDay.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(6));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnSeventhDay.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(7));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnEightDay.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(8));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnNinthDay.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(9));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnTenthDay.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(10));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnEleventhDay.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(11));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnTwelfthDay.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(12));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnThirteenthDay.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(13));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnFourteenthDay.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(14));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnFifteenthDay.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(15));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnSixteenthDay.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(16));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnSeventeenthDay.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(17));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnEighteenthDay.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(18));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnNineteenthDay.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(19));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnDayTwenty.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(20));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnDayTwentyOne.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(21));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnDayTwentyTwo.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(22));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnDayTwentyThree.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(23));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnDayTwentyFour.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(24));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnDayTwentyFive.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(25));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnDayTwentySix.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(26));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnDayTwentySeven.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(27));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnDayTwentyEight.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(28));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnDayTwentyNine.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(29));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnDayThirty.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(30));
                this.NavigationController.PushViewController(customEvent, true);
            };

            btnDayThirtyOne.TouchUpInside += (sender, e) => {
                customEvent = new CustomEvent(createDate(31));
                this.NavigationController.PushViewController(customEvent, true);
            };
        }

        private DateTime createDate(int day)
        {
            return new DateTime(DateTime.Now.Year, Convert.ToInt32(lblCurrentMonth.Text), day);
        }
    }
}