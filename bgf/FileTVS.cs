using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AVFoundation;
using AVKit;
using bgf.Model;
using Foundation;
using UIKit;

namespace bgf
{
    class FileTVS : UITableViewSource
    {
        List<File> files;
        UIViewController owner;
       

        public FileTVS(List<File> files, tvFilesController tvFilesController)
        {
            this.files = files;
            this.owner = tvFilesController;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (FilesViewCell)tableView.DequeueReusableCell("CustomFileCell", indexPath);
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
            //OVO JE RESENJE SAMO NEKA PUSHUJE NAVIGATION CONTROLLER
            /*UIAlertController okAlertController = UIAlertController.Create("Row Selected", tableItems[indexPath.Row], UIAlertControllerStyle.Alert);
            okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
            owner.PresentViewController(okAlertController, true, null);
            tableView.DeselectRow(indexPath, true);
            */

            if (files[indexPath.Row].isMagazine)
            {
                MagazineController magazineController = owner.Storyboard.InstantiateViewController("MagazineController") as MagazineController;

                if (magazineController != null)
                {
                    magazineController.MagazineURL = files[indexPath.Row].URL;
                    owner.NavigationController.PushViewController(magazineController, true);
                }
            }
            else
            {
                //NSUrl url = new NSUrl("Aktive Pausengestaltung.mp4", false)
                //"https://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4"));
                AVPlayer player = new AVPlayer(new NSUrl("https://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4"));//files[indexPath.Row].URL));
                AVPlayerViewController aVPlayerView = new AVPlayerViewController();
                aVPlayerView.Player = player;

                owner.PresentViewController(aVPlayerView, true, null);
              
            }
        }
    }
}