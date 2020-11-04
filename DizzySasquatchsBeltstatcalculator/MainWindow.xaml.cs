using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace DizzySasquatchsBeltstatcalculator
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string VERSION = "v2.3";

        private Belt _belt = new Belt();
        private Language _lang = DizzySasquatchsBeltstatcalculator.Language.DE;

        public MainWindow()
        {
            InitializeComponent();
            Startup();
            Update();
            UpdateLanguage(DizzySasquatchsBeltstatcalculator.Language.DE);
        }

        private void Startup()
        {
            Rbt_LangDE.Checked += (sender, e) => UpdateLanguage(DizzySasquatchsBeltstatcalculator.Language.DE);
            Rbt_LangEN.Checked += (sender, e) => UpdateLanguage(DizzySasquatchsBeltstatcalculator.Language.EN);
            Rbt_LangFR.Checked += (sender, e) => UpdateLanguage(DizzySasquatchsBeltstatcalculator.Language.FR);
            CBx_BeltEnhancement.SelectionChanged += (sender, e) =>
            {
                Update();
            };

            ResourceReader res = new ResourceReader(_lang);

            foreach (ComboBox cbx in MainGrid.Children.OfType<ComboBox>())
            {
                cbx.SelectionChanged += (sender, e) => Update();

                if (cbx.Tag?.ToString() == "Petlist")
                {
                    foreach (CreatureType type in (CreatureType[])Enum.GetValues(typeof(CreatureType)))
                    {
                        string cName = res.GetString(type.ToString());
                        ComboBoxItem cbxi = new ComboBoxItem() { Content = cName, Tag = type };
                        cbx.Items.Add(cbxi);
                    }
                    cbx.SelectedIndex = 0;
                }
            }
        }

        private void UpdateLanguage(Language lang = 0)
        {
            if (lang == 0)
            {
                string langeName = MainGrid.Children.OfType<RadioButton>()
                    .Where(r => r.GroupName == "Language")
                    .First(r => r.IsChecked.Value).Name;
                if (Enum.TryParse(langeName, out Language language))
                {
                    lang = language;
                }
                else
                {
                    ResourceReader enRes = new ResourceReader(DizzySasquatchsBeltstatcalculator.Language.EN);
                    MessageBox.Show(enRes.GetString("UI_LanguageParseError"), enRes.GetString("UI_Error"), MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            _lang = lang;

            ResourceReader res = new ResourceReader(_lang);
            foreach (Label label in MainGrid.Children.OfType<Label>())
            {
                if (label.Tag?.ToString() == "IgnoreLang")
                {
                    continue;
                }
                string prefix = "UI_";
                string name = label.Name;
                if (label.Name.StartsWith("Stat_"))
                {
                    prefix = "";
                    name = name.Replace("Stat_", "");
                }
                label.Content = res.GetString($"{prefix}{name}");
            }

            foreach (ComboBox cbx in MainGrid.Children.OfType<ComboBox>())
            {
                if (cbx.Tag?.ToString() == "Petlist")
                {
                    int cbxSelectedIdx = cbx.SelectedIndex;
                    cbx.Items.Clear();
                    foreach (CreatureType type in (CreatureType[])Enum.GetValues(typeof(CreatureType)))
                    {
                        string cName = res.GetString(type.ToString());
                        ComboBoxItem cbxi = new ComboBoxItem() { Content = cName, Tag = type };
                        cbx.Items.Add(cbxi);
                    }
                    cbx.SelectedIndex = cbxSelectedIdx;
                }
            }

            Btn_Reset.Content = res.GetString("UI_Reset");
            Btn_About.Content = res.GetString("UI_About");
        }

        private void Update()
        {
            int beltEnhance;
            string beltSelected = CBx_BeltEnhancement.SelectedItem.ToString().Split(' ')[1];
            switch (beltSelected)
            {
                case "< +20":
                    beltEnhance = 0;
                    break;
                case string s when s.StartsWith("+"):
                    beltEnhance = int.Parse(beltSelected.Trim('+'));
                    break;
                default:
                    beltEnhance = 0;
                    break;
            }
            Lbl_BeltLimit.Content = Belt.BeltCreatureLimit[beltEnhance];
            _belt.BeltEnhancement = beltEnhance;

            for (int i = 6; i-- > 0;)
            {
                object selectedItem = MainGrid.Children.OfType<ComboBox>().First(c => c.Name == $"CBx_Pet{i}").SelectedItem;
                if (selectedItem is null)
                {
                    continue;
                }
                if (selectedItem is ComboBoxItem cbxi && cbxi.Tag is CreatureType type)
                {
                    int stage = int.Parse(MainGrid.Children.OfType<ComboBox>().First(c => c.Name == $"Cbx_Stage{i}").SelectedItem?.ToString().Split(' ')[1]);
                    Creature creature = new Creature(type, stage);
                    _belt[i] = creature;
                }
            }

            foreach (Label label in MainGrid.Children.OfType<Label>().Where(l => l.Name.StartsWith("Stat_") && l.Name.EndsWith("Value")))
            {
                string sStat = label.Name.Replace("Stat_", "").Replace("Value", "");
                if (Enum.TryParse(sStat, out StatType type))
                {
                    label.Content = $"{_belt.GetStatValue(type)}%";

                    float beltMax = Belt.BeltCreatureLimit[_belt.BeltEnhancement];
                    float overflown = _belt.GetStatHiddenValue(type);
                    if (overflown >= beltMax)
                    {
                        label.FontWeight = FontWeights.Bold;
                        if (overflown > beltMax)
                        {
                            label.Foreground = Brushes.Red;
                        }
                        else
                        {
                            label.Foreground = Brushes.Black;
                        }
                    }
                    else
                    {
                        label.FontWeight = FontWeights.Normal;
                        label.Foreground = Brushes.Black;
                    }
                }
            }
        }

        private void Btn_Reset_Click(object sender, RoutedEventArgs e)
        {
            foreach (ComboBox cbx in MainGrid.Children.OfType<ComboBox>())
            {
                if (cbx.Tag?.ToString() == "Petlist" || cbx.Name.StartsWith("Cbx_Stage") || cbx.Name == "CBx_BeltEnhancement")
                {
                    cbx.SelectedIndex = 0;
                }
            }
            Update();
        }

        private void Btn_About_Click(object sender, RoutedEventArgs e)
        {
            ResourceReader res = new ResourceReader(_lang);
            MessageBox.Show(res.GetString("UI_AboutText").Replace("$n", "\n").Replace("$t", "\t").Replace("$version", VERSION), res.GetString("UI_AboutTitle"), MessageBoxButton.OK);
        }

        private void hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
        }
    }
}
