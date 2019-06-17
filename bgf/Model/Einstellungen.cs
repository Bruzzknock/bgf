using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace bgf.Model
{
    public enum EinstellungenType { Passwort, Interesse, Abmeldung};
    public class Einstellungen
    {
        public string Label { get; set; }
        public EinstellungenType Type { get; set; }

        public Einstellungen(string label, EinstellungenType type)
        {
            Label = label;
            Type = type;
        }
    }
}