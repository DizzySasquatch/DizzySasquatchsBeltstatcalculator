using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DE = DizzySasquatchsBeltstatcalculator.Properties.ResourceDE;
using EN = DizzySasquatchsBeltstatcalculator.Properties.ResourceEN;

namespace DizzySasquatchsBeltstatcalculator
{
    public enum Language { None = 0, DE = 1, EN = 2 }
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
                string error = Language == Language.DE ? DE.UI_Error : EN.UI_Error;
                MessageBox.Show( $"{error}: {e.Message}", e.Source, MessageBoxButton.OK, MessageBoxImage.Error );
                return "";
            }
        }

    }
}
