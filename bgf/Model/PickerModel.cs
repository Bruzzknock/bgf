using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
/*In dieser Klasse wird die Picker implementiert. Es wird verwendet um den Filter umzusetzen*/
namespace bgf.Model
{
    public class PickerModel : UIPickerViewModel
    {
        public string[] Source { get; set; }
        private nint selectedComponent;
        public nint SelectedComponent { get { return selectedComponent; } }

        public delegate void SelectionChanged();

        public event SelectionChanged DidSelectionChange;

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return Source.Length;
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            return Source[row];
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            //personLabel.Text = $"This person is: {names[pickerView.SelectedRowInComponent(0)]},\n they are number {pickerView.SelectedRowInComponent(1)}";
            selectedComponent = pickerView.SelectedRowInComponent(0);
            DidSelectionChange();
        }

        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override nfloat GetComponentWidth(UIPickerView picker, nint component)
        {
            return 240f;
        }

        public override nfloat GetRowHeight(UIPickerView picker, nint component)
        {
            return 40f;
        }
    }
}