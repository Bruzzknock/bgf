using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AVFoundation;
using AVKit;
using bgf.Model;
using Foundation;
using UIKit;
/*In dieser Klasse wird die TableView initialisiert und die Files vom ConnectionManager.cs benutzt*/
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

        /*In dieser Methode wird die TableView mit Dokumenten und Videos gefüllt*/
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            

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
                AVPlayer player = new AVPlayer(new NSUrl(files[indexPath.Row].URL));
                AVPlayerViewController aVPlayerView = new AVPlayerViewController();
                aVPlayerView.Player = player;

                owner.PresentViewController(aVPlayerView, true, null);
              
            }
        }
    }
}