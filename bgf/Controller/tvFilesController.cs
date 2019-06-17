using bgf.Model;
using bgf.Static_Resources;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;
/*In dieser Klasse wird die einzelnen Dokumente, Videos und Präsentationen mit Filter implemetiert*/
namespace bgf
{
    public partial class tvFilesController : UIViewController
    {
        private enum CurrentlySelected { Date, Interest, Type};
        public List<File> data;
        private PickerModel model;
        private CurrentlySelected currentlySelected;
        private nint pckDate;
        private nint pckInterest;
        private nint pckType;
        private UIColor dark = new UIColor(18f / 255.0f, 19f / 255.0f, 15f / 255.0f, 255f / 255.0f);
        private UIColor bright = new UIColor(230f / 255.0f, 230f / 255.0f, 233f / 255.0f, 255f / 255.0f);

        /*Default Konstruktor*/
        public tvFilesController(IntPtr handle) : base(handle)
        {

        }

        /*Mit dieser Methode wird die Magazine und Videos angezeigt*/
        public override void ViewDidLoad()
        {
            data = ConnectionManager.GetFiles();
            model = new PickerModel();
            model.Source = ConnectionManager.GetDates();
            currentlySelected = CurrentlySelected.Date;
            SelectFilter(btnYear);
            model.DidSelectionChange += saveSelection;
            uiPicker.Model = model;

            filesTableView.Source = new FileTVS(data,this);
            filesTableView.RowHeight = 80;
            filesTableView.ReloadData();
        }

        /*In dieser Methode ruft man das gewünschte Auswahlt ab - nach Datum , Interesse oder Datatypes sortieren*/
        private void saveSelection()
        {
            switch (currentlySelected)
            {
                case CurrentlySelected.Date:
                    pckDate = ((PickerModel)uiPicker.Model).SelectedComponent;
                    break;
                case CurrentlySelected.Interest:
                    pckInterest = ((PickerModel)uiPicker.Model).SelectedComponent;
                    break;
                case CurrentlySelected.Type:
                    pckType = ((PickerModel)uiPicker.Model).SelectedComponent;
                    break;
            }
        }

        private void SelectFilter(UIButton uIButton)
        {
            uIButton.BackgroundColor = dark;
            uIButton.SetTitleColor(bright,UIControlState.Normal);
        }

        private void DeselectFilter(UIButton uIButton)
        {
            uIButton.BackgroundColor = bright;
            uIButton.SetTitleColor(dark, UIControlState.Normal);
        }

        partial void BtnInterest_TouchUpInside(UIButton sender)
        {
            model.Source = ConnectionManager.GetInterests();
            currentlySelected = CurrentlySelected.Interest;
            uiPicker.Model = model;
            uiPicker.Select(pckInterest, 0,true);
            SelectFilter(btnInterest);
            DeselectFilter(btnYear);
            DeselectFilter(btnType);
        }

        /*In dieser Methode wird das Jahr gewechselt*/
        partial void BtnYear_TouchUpInside(UIButton sender)
        {
            model.Source = ConnectionManager.GetDates();
            currentlySelected = CurrentlySelected.Date;
            uiPicker.Model = model;
            uiPicker.Select(pckDate, 0, true);
            SelectFilter(btnYear);
            DeselectFilter(btnInterest);
            DeselectFilter(btnType);
        }

        partial void BtnType_TouchUpInside(UIButton sender)
        {
            model.Source = ConnectionManager.GetType();
            currentlySelected = CurrentlySelected.Type;
            uiPicker.Model = model;
            uiPicker.Select(pckType, 0, true);
            SelectFilter(btnType);
            DeselectFilter(btnInterest);
            DeselectFilter(btnYear);
        }

        partial void BtnFilter_TouchUpInside(UIButton sender)
        {
            if (pckDate != 0 || pckInterest != 0 || pckType != 0)
            {
                data = ConnectionManager.GetFiles(ConnectionManager.GetDates()[pckDate], 
                    ConnectionManager.GetInterests()[pckInterest], ConnectionManager.GetType()[pckType]);
                filesTableView.Source = new FileTVS(data, this);
                filesTableView.RowHeight = 80;
                filesTableView.ReloadData();
            }
            else
            {
                data = ConnectionManager.GetFiles();
                filesTableView.Source = new FileTVS(data, this);
                filesTableView.RowHeight = 80;
                filesTableView.ReloadData();
            }
        }
    }
}