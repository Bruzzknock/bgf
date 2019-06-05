using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using bgf.Model;
using bgf.Static_Resources;

namespace bgf
{
    public partial class CalendarView : UIViewController
    {
        private int counter = 0;
        List<Events_Tasks> e;
        private string[] months = new string[]{
                        "Januar", "Februar", "März", "April", "Mai", "Juni", "Juli", "August", "September", "Oktober",
                        "November", "Dezember"};

        public CalendarView (IntPtr handle) : base (handle)
        {
           
            
        }
        //setup Calendar is pushed
        public override void ViewDidLoad()
        {
            e = ConnectionManager.GetEvents();
            lblCurrentMonth.Text = months[0];

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
                
                if (counter == 0)//Jan
                {
                    lblCurrentMonth.Text = months[counter];
                    btnPreviousMonth.SetTitle(months[11], forState: UIControlState.Normal);
                    btnNextMonth.SetTitle(months[counter + 1], forState: UIControlState.Normal);
                    
                }

                if (counter == 1) //Feb
                {
                    lblCurrentMonth.Text = months[counter];
                    btnNextMonth.SetTitle(months[counter + 1], forState: UIControlState.Normal);
                    btnPreviousMonth.SetTitle(months[counter - 1], forState: UIControlState.Normal);
                    btnDayTwentyNine.Hidden = true;
                    btnDayThirty.Hidden = true;
                    btnDayThirtyOne.Hidden = true;
                }
                if (counter == 2) //Mar
                {
                    lblCurrentMonth.Text = months[counter];
                    btnNextMonth.SetTitle(months[counter + 1], forState: UIControlState.Normal);
                    btnPreviousMonth.SetTitle(months[counter - 1], forState: UIControlState.Normal);
                    btnDayTwentyNine.Hidden = false;
                    btnDayThirty.Hidden = false;
                    btnDayThirtyOne.Hidden = false;
                }
                if (counter == 3) //Apr
                {
                    lblCurrentMonth.Text = months[counter];
                    btnNextMonth.SetTitle(months[counter + 1], forState: UIControlState.Normal);
                    btnPreviousMonth.SetTitle(months[counter - 1], forState: UIControlState.Normal);
                    btnDayTwentyNine.Hidden = false;
                    btnDayThirty.Hidden = false;
                    btnDayThirtyOne.Hidden = true;
                }
                if (counter == 4) //May
                {
                    lblCurrentMonth.Text = months[counter];
                    btnNextMonth.SetTitle(months[counter + 1], forState: UIControlState.Normal);
                    btnPreviousMonth.SetTitle(months[counter - 1], forState: UIControlState.Normal);
                    btnDayTwentyNine.Hidden = false;
                    btnDayThirty.Hidden = false;
                    btnDayThirtyOne.Hidden = false;
                }
                if (counter == 5) //Jun
                {
                    lblCurrentMonth.Text = months[counter];
                    btnNextMonth.SetTitle(months[counter + 1], forState: UIControlState.Normal);
                    btnPreviousMonth.SetTitle(months[counter - 1], forState: UIControlState.Normal);
                    btnDayTwentyNine.Hidden = false;
                    btnDayThirty.Hidden = false;
                    btnDayThirtyOne.Hidden = true;
                }
                if (counter == 6) //Jul
                {
                    lblCurrentMonth.Text = months[counter];
                    btnNextMonth.SetTitle(months[counter + 1], forState: UIControlState.Normal);
                    btnPreviousMonth.SetTitle(months[counter - 1], forState: UIControlState.Normal);
                    btnDayTwentyNine.Hidden = false;
                    btnDayThirty.Hidden = false;
                    btnDayThirtyOne.Hidden = false;
                }
                if (counter == 7)//Aug
                {
                    lblCurrentMonth.Text = months[counter];
                    btnNextMonth.SetTitle(months[counter + 1], forState: UIControlState.Normal);
                    btnPreviousMonth.SetTitle(months[counter - 1], forState: UIControlState.Normal);
                    btnDayTwentyNine.Hidden = false;
                    btnDayThirty.Hidden = false;
                    btnDayThirtyOne.Hidden = false;
                }
                if (counter == 8)//Sep
                {
                    lblCurrentMonth.Text = months[counter];
                    btnNextMonth.SetTitle(months[counter + 1], forState: UIControlState.Normal);
                    btnPreviousMonth.SetTitle(months[counter - 1], forState: UIControlState.Normal);
                    btnDayTwentyNine.Hidden = false;
                    btnDayThirty.Hidden = false;
                    btnDayThirtyOne.Hidden = true;
                }
                if (counter == 9)//Okt
                {
                    lblCurrentMonth.Text = months[counter];
                    btnNextMonth.SetTitle(months[counter + 1], forState: UIControlState.Normal);
                    btnPreviousMonth.SetTitle(months[counter - 1], forState: UIControlState.Normal);
                    btnDayTwentyNine.Hidden = false;
                    btnDayThirty.Hidden = false;
                    btnDayThirtyOne.Hidden = false;
                }
                if (counter == 10)//Nov
                {
                    lblCurrentMonth.Text = months[counter];
                    btnNextMonth.SetTitle(months[counter + 1], forState: UIControlState.Normal);
                    btnPreviousMonth.SetTitle(months[counter - 1], forState: UIControlState.Normal);
                    btnDayTwentyNine.Hidden = false;
                    btnDayThirty.Hidden = false;
                    btnDayThirtyOne.Hidden = true;
                }
                if (counter == 11)//Dez
                {
                    lblCurrentMonth.Text = months[counter];
                    btnNextMonth.SetTitle(months[0], forState: UIControlState.Normal);
                    btnPreviousMonth.SetTitle(months[counter - 1], forState: UIControlState.Normal);
                    counter = 0;
                }
                counter++;
            };

            btnPreviousMonth.TouchUpInside += (sender, e) =>
            {

                counter--;
                lblCurrentMonth.Text = months[counter - 1];
                btnPreviousMonth.SetTitle(months[counter-2], forState: UIControlState.Normal);
                btnNextMonth.SetTitle(months[counter], forState: UIControlState.Normal);

                if (lblCurrentMonth.Text == months[3] || lblCurrentMonth.Text == months[5] || lblCurrentMonth.Text == months[8] || lblCurrentMonth.Text == months[10])
                {
                    btnDayTwentyNine.Hidden = false;
                    btnDayThirty.Hidden = false;
                    btnDayThirtyOne.Hidden = true;
                }
                else
                {
                    btnDayTwentyNine.Hidden = false;
                    btnDayThirty.Hidden = false;
                    btnDayThirtyOne.Hidden = false;
                }
                   
                if(lblCurrentMonth.Text==months[1])
                {
                    btnDayTwentyNine.Hidden = true;
                    btnDayThirty.Hidden = true;
                    btnDayThirtyOne.Hidden = true;
                }
                else
                {
                    btnDayTwentyNine.Hidden = false;
                    btnDayThirty.Hidden = false;
                    btnDayThirtyOne.Hidden = false;
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

    
           
    
}