using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

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
            

            btnFirstDay.TouchUpInside += (sender, e) => {
                this.NavigationController.PushViewController(createCustomEventVC(1), true);
            };

            btnSecondDay.TouchUpInside += (sender, e) => {
                this.NavigationController.PushViewController(createCustomEventVC(2), true);
            };

            btnThirdDay.TouchUpInside += (sender, e) => {
                this.NavigationController.PushViewController(createCustomEventVC(3), true);
            };

            btnFourthDay.TouchUpInside += (sender, e) => {                
                this.NavigationController.PushViewController(createCustomEventVC(4), true);
            };

            btnFifthDay.TouchUpInside += (sender, e) => {
                this.NavigationController.PushViewController(createCustomEventVC(5), true);
            };

            btnSixthDay.TouchUpInside += (sender, e) => {
                this.NavigationController.PushViewController(createCustomEventVC(6), true);
            };

            btnSeventhDay.TouchUpInside += (sender, e) => {
                this.NavigationController.PushViewController(createCustomEventVC(7), true);
            };

            btnEightDay.TouchUpInside += (sender, e) => {
                this.NavigationController.PushViewController(createCustomEventVC(8), true);
            };

            btnNinthDay.TouchUpInside += (sender, e) => {
                this.NavigationController.PushViewController(createCustomEventVC(9), true);
            };

            btnTenthDay.TouchUpInside += (sender, e) => {
                this.NavigationController.PushViewController(createCustomEventVC(10), true);
            };

            btnEleventhDay.TouchUpInside += (sender, e) => {
                this.NavigationController.PushViewController(createCustomEventVC(11), true);
            };

            btnTwelfthDay.TouchUpInside += (sender, e) => {
                this.NavigationController.PushViewController(createCustomEventVC(12), true);
            };

            btnThirteenthDay.TouchUpInside += (sender, e) => {
                this.NavigationController.PushViewController(createCustomEventVC(13), true);
            };

            btnFourteenthDay.TouchUpInside += (sender, e) => {
                this.NavigationController.PushViewController(createCustomEventVC(14), true);
            };

            btnFifteenthDay.TouchUpInside += (sender, e) => {
                this.NavigationController.PushViewController(createCustomEventVC(15), true);
            };

            btnSixteenthDay.TouchUpInside += (sender, e) => {
                this.NavigationController.PushViewController(createCustomEventVC(16), true);
            };

            btnSeventeenthDay.TouchUpInside += (sender, e) => {
                this.NavigationController.PushViewController(createCustomEventVC(17), true);
            };

            btnEighteenthDay.TouchUpInside += (sender, e) => {
                this.NavigationController.PushViewController(createCustomEventVC(18), true);
            };

            btnNineteenthDay.TouchUpInside += (sender, e) => {
                this.NavigationController.PushViewController(createCustomEventVC(19), true);
            };

            btnDayTwenty.TouchUpInside += (sender, e) => {
                this.NavigationController.PushViewController(createCustomEventVC(20), true);
            };

            btnDayTwentyOne.TouchUpInside += (sender, e) => {
                this.NavigationController.PushViewController(createCustomEventVC(21), true);
            };

            btnDayTwentyTwo.TouchUpInside += (sender, e) => {
                this.NavigationController.PushViewController(createCustomEventVC(22), true);
            };

            btnDayTwentyThree.TouchUpInside += (sender, e) => {
                this.NavigationController.PushViewController(createCustomEventVC(23), true);
            };

            btnDayTwentyFour.TouchUpInside += (sender, e) => {               
                this.NavigationController.PushViewController(createCustomEventVC(24), true);
            };

            btnDayTwentyFive.TouchUpInside += (sender, e) => {
                this.NavigationController.PushViewController(createCustomEventVC(25), true);
            };

            btnDayTwentySix.TouchUpInside += (sender, e) => {
                this.NavigationController.PushViewController(createCustomEventVC(26), true);
            };

            btnDayTwentySeven.TouchUpInside += (sender, e) => {
                this.NavigationController.PushViewController(createCustomEventVC(27), true);
            };

            btnDayTwentyEight.TouchUpInside += (sender, e) => {
                this.NavigationController.PushViewController(createCustomEventVC(28), true);
            };

            btnDayTwentyNine.TouchUpInside += (sender, e) => {
                this.NavigationController.PushViewController(createCustomEventVC(29), true);
            };

            btnDayThirty.TouchUpInside += (sender, e) => {
                this.NavigationController.PushViewController(createCustomEventVC(30), true);
            };

            btnDayThirtyOne.TouchUpInside += (sender, e) => {
                this.NavigationController.PushViewController(createCustomEventVC(31), true);
            };

            btnNextMonth.TouchUpInside += (sender, e) =>
            {
                
                string[] months = new string[]{
                        "Januar", "Februar", "März", "April", "Mai", "Juni", "Juli", "August", "September", "Oktober",
                        "November", "Dezember"};

                lblCurrentMonth.Text = months[0];

                int i=0;

                switch(i)
                {
                    case 0:
                        lblCurrentMonth.Text = months[0];
                        
                        break;
                    case 1:
                        lblCurrentMonth.Text = months[1];
                        
                        break;
                    case 2:
                        lblCurrentMonth.Text = months[2];
                        
                        break;

                }

                
            };

            


        }

        private CustomEvent createCustomEventVC(int day)
        {
            CustomEvent customEvent =(CustomEvent)this.Storyboard.InstantiateViewController("CustomEvent");
            customEvent.setDate(new DateTime(DateTime.Now.Year, 3, day));
            return customEvent;
        }

       
       
    }

    public class Months
    {
        public string Value { get; set; }
        public int Key { get; set; }

        public static List<Months> GetMonths()
        {
            var months = new List<Months>()
            {
                new Months() {Key=0, Value ="Januar"},
                new Months() {Key=1, Value ="Februar"},
                new Months() {Key=2, Value = "März"},
                new Months() {Key=3, Value = "April"},
                new Months() {Key=4, Value = "Mai"},
                new Months() {Key=5, Value = "Juni"},
                new Months() {Key=6, Value = "Juli"},
                new Months() {Key=7, Value = "August"},
                new Months() {Key=8, Value = "September"},
                new Months() {Key=9, Value = "Oktober"},
                new Months() {Key=10,Value = "November"},
                new Months() {Key=11, Value = "Dezember"}
            };
            return months;
        }
    }
}