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
    class InterrestTVS : UITableViewSource
    {
        List<Interrests> files;
        UIViewController owner;
       

        public InterrestTVS(List<Interrests> files, InteresstsController interesstsController)
        {
            this.files = files;
            this.owner = interesstsController;
        }

        public List<bool> SelectedInteressts()
        {
            List<bool> data = new List<bool>();

            foreach (var f in files)
            {
                data.Add(f.IsSelected);
            }
            return data;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (InteresstsCustomCell)tableView.DequeueReusableCell("InteresstsCustomCell", indexPath);
            var file = files[indexPath.Row];
            cell.setInteresst(file);
            return cell;
        }

        private void UpdateCell(UITableView tableView, NSIndexPath indexPath,Interrests file)
        {
            var cell = (InteresstsCustomCell)tableView.DequeueReusableCell("InteresstsCustomCell", indexPath);

            cell.UpdateInteresst(file);
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return files.Count;
        }

        /*In dieser Methode wird die TableView mit Dokumenten und Videos gefüllt*/
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            //UpdateCell(tableView, indexPath, files[indexPath.Row]);
            /*if (files[indexPath.Row].IsSelected)
            {
                files[indexPath.Row].Image = new UIImage("uncheck.png");
            }
            else
            {
                files[indexPath.Row].Image = new UIImage("check.png");
            }
            files[indexPath.Row].IsSelected = !files[indexPath.Row].IsSelected;*/
            //files = null;
        }
    }
}