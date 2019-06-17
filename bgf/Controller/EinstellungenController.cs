using bgf.Model;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace bgf
{
    public partial class EinstellungenController : UITableViewController
    {
        List<Einstellungen> files;

        public EinstellungenController(IntPtr handle) : base(handle)
        {
            files = new List<Einstellungen>();
            Einstellungen passwort = new Einstellungen("Passwort ändern", EinstellungenType.Passwort);
            Einstellungen interesse = new Einstellungen("Interesse ändern", EinstellungenType.Interesse);
            Einstellungen abmelden = new Einstellungen("Einmalige Anmeldung", EinstellungenType.Abmeldung);
            files.Add(passwort);
            files.Add(interesse);
            files.Add(abmelden);
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (EinstellungenViewsCell)tableView.DequeueReusableCell("EinstellungenViewsCell", indexPath);
            //var cell = tableView.DequeueReusableCell("FilesViewCell") as FilesViewCell;
            var file = files[indexPath.Row];
            cell.setFile(file);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return files.Count;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            switch (files[indexPath.Row].Type)
            {
                case EinstellungenType.Passwort:
                    PasswortController passwortController = this.Storyboard.InstantiateViewController("PasswortController") as PasswortController;

                    if (passwortController != null)
                    {
                        this.NavigationController.PushViewController(passwortController, true);
                    }
                    break;
                case EinstellungenType.Interesse:
                    InteresstsController interesstsController = this.Storyboard.InstantiateViewController("InteresstsController") as InteresstsController;

                    if (interesstsController != null)
                    {
                        this.NavigationController.PushViewController(interesstsController, true);
                    }
                    break;
                case EinstellungenType.Abmeldung:
                    bgf.Helpers.Settings.Clear();
                    new UIAlertView("Abmeldung", "Einmalige Anmeldung ist deaktiviert.", null, "OK", null).Show();

                    break;
            }
        }
    }
}