using CoreGraphics;
using Foundation;
using PdfKit;
using System;
using UIKit;

namespace bgf
{
    public partial class MagazineController : UIViewController
    {
        public MagazineController (IntPtr handle) : base (handle)
        {

        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var pdfView = new PdfView();

            pdfView.TranslatesAutoresizingMaskIntoConstraints = false;
            View.AddSubview(pdfView);

            pdfView.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor).Active = true;
            pdfView.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor).Active = true;
            pdfView.TopAnchor.ConstraintEqualTo(View.TopAnchor).Active = true;
            pdfView.BottomAnchor.ConstraintEqualTo(View.BottomAnchor).Active = true;

            var document = new PdfDocument(new NSUrl("https://bayes.wustl.edu/etj/articles/random.pdf"));
            pdfView.Document = document;
            pdfView.AutoScales = true;
            //letsgo


            // Perform any additional setup after loading the view, typically from a nib.
            //UILabel label = new UILabel(new CGRect(0, 200, View.Frame.Size.Width, 50));
            //label.Text = "Tutorial";
            //label.Font.WithSize(36);
            //View.Add(label.ViewForBaselineLayout);

            //this.View.AddSubview(uIScrollView);
        }
    }
}