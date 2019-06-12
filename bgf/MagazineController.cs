using Foundation;
using PdfKit;
using System;
using UIKit;
/*In dieser Klasse wird die Magazine implementiert. Beim Aufruf einer Magazine in der File TableView wird das hier aufgerufen*/

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

        /*In dieser Methode wird das ausgewählte Magazin initialisiert.*/
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

        /*Diese Methode wird verwendet um das aktuelle Seite vom Magazin anzuzeigen*/
        private void UpdateCurrentPage()
        {
            pdfPage = pdfView.CurrentPage;
        }

        /*Diese Methode wird verwendet wenn man eine Seitenanzahl eingibt*/
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
        /*In dieser Methode ruft man die nächste Seite auf*/
        partial void BtnNext_TouchUpInside(UIButton sender)
        {
            UpdateCurrentPage();
            pdfView.GoToNextPage(sender);
            UpdateCurrentPage();
            updateTex(pdfPage.Page.PageNumber);
        }

        /*In dieser Methode ruft man die vorherige Seite auf*/
        partial void BtnPrev_TouchUpInside(UIButton sender)
        {
            UpdateCurrentPage();
            pdfView.GoToPreviousPage(sender);
            UpdateCurrentPage();
            updateTex(pdfPage.Page.PageNumber);
        }
        /*In dieser Methode wandelt man die eingegeben Seitenanzahl auf nint um*/
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