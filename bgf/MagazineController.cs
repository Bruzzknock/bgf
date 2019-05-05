using Foundation;
using PdfKit;
using System;
using UIKit;

namespace bgf
{
    public partial class MagazineController : UIViewController
    {
        public string MagazineURL;
        private PdfPage pdfPage;
        private PdfView pdfView;
        private int pageDestination;

        public MagazineController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            pdfView = new PdfView();

            pdfView.TranslatesAutoresizingMaskIntoConstraints = false;
            View.AddSubview(pdfView);

            pdfView.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor).Active = true;
            pdfView.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor).Active = true;
            pdfView.TopAnchor.ConstraintEqualTo(View.TopAnchor).Active = true;
            pdfView.BottomAnchor.ConstraintEqualTo(btnNext.TopAnchor).Active = true;
            pdfView.DisplayDirection = PdfDisplayDirection.Vertical;

            var document = new PdfDocument(new NSUrl(MagazineURL));
            pdfView.Document = document;
            pdfView.AutoScales = true;
            UpdateCurrentPage();
            txtPage.Text = pdfPage.Page.PageNumber.ToString();
            pdfView.DisplaysPageBreaks = true;

                /*UIButton pageBefore = new UIButton();
                pageBefore.SetTitle("Bevor", UIControlState.Normal);
                View.AddSubview(pageBefore);*/

                // Perform any additional setup after loading the view, typically from a nib.
                //UILabel label = new UILabel(new CGRect(0, 200, View.Frame.Size.Width, 50));
                //label.Text = "Tutorial";
                //label.Font.WithSize(36);
                //View.Add(label.ViewForBaselineLayout);

                //this.View.AddSubview(uIScrollView);
        }

        private void UpdateCurrentPage()
        {
            pdfPage = pdfView.CurrentPage;
        }

        partial void BtnGo_TouchUpInside(UIButton sender)
        {
            UpdateCurrentPage();
            if (pdfPage.Page.PageNumber == pageDestination)
                pdfView.GoToPage(pdfPage);
            else
            {
                int currentPage = (int)pdfPage.Page.PageNumber;

                if (pageDestination > currentPage)
                {
                    for (int i = pageDestination - currentPage; i > 0; i--)
                        pdfView.GoToNextPage(btnNext);
                }
                else
                {
                    for (int i = currentPage - pageDestination; i > 0; i--)
                        pdfView.GoToPreviousPage(btnPrev);
                }

                UpdateCurrentPage();
            }
        }

        partial void BtnNext_TouchUpInside(UIButton sender)
        {
            UpdateCurrentPage();
            pdfView.GoToNextPage(sender);
            UpdateCurrentPage();
            updateTex(pdfPage.Page.PageNumber);
        }

        partial void BtnPrev_TouchUpInside(UIButton sender)
        {
            UpdateCurrentPage();
            pdfView.GoToPreviousPage(sender);
            UpdateCurrentPage();
            updateTex(pdfPage.Page.PageNumber);
        }
        private void updateTex(nint num)
        {
            txtPage.Text = num.ToString();
        }

        partial void txtPage_TextChanged(UIKit.UITextField sender)
        {            
            var isNumeric = int.TryParse(sender.Text, out int result);
            if (isNumeric)
                pageDestination = result;
        }
    }
}