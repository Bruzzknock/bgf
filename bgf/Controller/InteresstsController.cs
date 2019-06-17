using bgf.Model;
using bgf.Static_Resources;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace bgf
{
    public partial class InteresstsController : UIViewController
    {
        public List<Interrests> data;
        InterrestTVS source;

        public InteresstsController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            data = LoadInterests();
            source = new InterrestTVS(data, this);

            tbvInteressts.Source = source;
            tbvInteressts.RowHeight = 80;
            tbvInteressts.ReloadData();
        }

        private List<Interrests> LoadInterests()
        {
            List<int> ids = ConnectionManager.GetInterestsFromUser();
            ids.Sort();
            List<Interrests> data = new List<Interrests>();

            if (Interests.ID == null)
                ConnectionManager.GetInterests();

            for(int i= 1; i< Interests.ID.Length;i++)
            {
                bool updated = false;

                for (int v = 0; v < ids.Count; v++)
                {          
                    if (Interests.ID[i] == ids[v]+1)
                    {
                        Interrests inter = new Interrests();
                        inter.ID = i;
                        inter.IsSelected = true;
                        inter.Image = new UIImage("check.png");
                        inter.Title = Interests.Interest_Desc[i];

                        data.Add(inter);

                        updated = true;
                        break;
                    }
                }
                if (!updated)
                {
                    Interrests inter = new Interrests();
                    inter.ID = Interests.ID[i];
                    inter.IsSelected = false;
                    inter.Image = new UIImage("uncheck.png");
                    inter.Title = Interests.Interest_Desc[i];

                    data.Add(inter);
                }
            }

            return data;
        }

        partial void BtnSave_TouchUpInside(UIButton sender)
        {
            ConnectionManager.UpdateInterests(source.SelectedInteressts());
        }
    }
}