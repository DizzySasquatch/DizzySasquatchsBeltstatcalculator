using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DE = DizzySasquatchsBeltstatcalculator.Properties.ResourceDE;
using EN = DizzySasquatchsBeltstatcalculator.Properties.ResourceEN;
using FR = DizzySasquatchsBeltstatcalculator.Properties.ResourceFR;

namespace DizzySasquatchsBeltstatcalculator
{
    public enum Language { None = 0, DE = 1, EN = 2, FR = 3 }
    public class ResourceReader
    {
        public readonly Language Language = 0;

        public ResourceReader(Language language)
        {
            Language = language;
        }

        public string GetString(string name)
        {
            try
            {
                ResourceManager rm = new ResourceManager( $"DizzySasquatchsBeltstatcalculator.Properties.Resource{Language}", GetType().Assembly );
                return rm.GetString( name );
            } catch (Exception e)
            {
                var error = "";
                switch (Language)
                {
                    case Language.None:
                        error = "No language resource found";
                        break;
                    case Language.DE:
                        error = DE.UI_Error;
                        break;
                    case Language.EN:
                        error = EN.UI_Error;
                        break;
                    case Language.FR:
                        error = FR.UI_Error;
                        break;
                }

                MessageBox.Show( $"{error}: {e.Message}", e.Source, MessageBoxButton.OK, MessageBoxImage.Error );
                return "";
            }
        }

    }
}
