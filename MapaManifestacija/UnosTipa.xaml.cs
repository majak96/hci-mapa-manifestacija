using MapaManifestacija.Help;
using MapaManifestacija.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MapaManifestacija
{
    /// <summary>
    /// Interaction logic for UnosTipa.xaml
    /// </summary>
    public partial class UnosTipa : Window
    {

        /* ----------- PODACI ----------- */
        private TipManifestacije noviTip;
        private TipManifestacije stariTip;
        public static string stariTipOznaka;

        /* ----------- KONSTRUKTOR KOJI SE KORISTI KAD SE KREIRA TIP MANIFESTACIJE IZ GLAVNOG PROZORA ----------- */
        public UnosTipa()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen; //centriranje prozora

            noviTip = new TipManifestacije();

            InitializeComponent();

            this.DataContext = noviTip;

            //fokus je na prvom polju za popunjavanje
            oznTxtBox.Focus();
            Keyboard.Focus(oznTxtBox);
        }

        /* ----------- KONSTRUKTOR KOJI SE KORISTI KOD IZMENE TIPA MANIFESTACIJE ----------- */
        public UnosTipa(TipManifestacije stariT)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen; //centriranje prozora

            stariTip = stariT;
            stariTipOznaka = stariT.Oznaka;
            noviTip = new TipManifestacije(stariTip);

            InitializeComponent();

            this.DataContext = noviTip;

            nastavak.Visibility = Visibility.Collapsed;

            //fokus je na prvom polju za popunjavanje
            oznTxtBox.Focus();
            Keyboard.Focus(oznTxtBox);
        }

        /* ----------- DODAVANJE SLIKE TIPA MANIFESTACIJE ----------- */
        private void DodajSlikuClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                noviTip.Ikonica = openFileDialog.FileName;
                ikonica.Source = new BitmapImage(new Uri(noviTip.Ikonica, UriKind.Absolute));
            }
        }

        /* ----------- POTVRDA I DODAVANJE/IZMENA TIPA MANIFESTACIJE ----------- */
        private void PotvrdiClick(object sender, RoutedEventArgs e)
        {
            if (stariTip == null)
            {
                ((MainWindow)Application.Current.Windows[0]).addTip(noviTip); //kreiranje i dodavanje u listu svih tipova
            }
            else //izmena iz liste svih tipova i manifestacija koje su tog tipa
            {
                int ind1 = ((MainWindow)Application.Current.Windows[0]).TipoviManifestacija.IndexOf(stariTip);
                ((MainWindow)Application.Current.Windows[0]).TipoviManifestacija.RemoveAt(ind1);
                ((MainWindow)Application.Current.Windows[0]).TipoviManifestacija.Insert(ind1, noviTip);

                foreach (Manifestacija m in noviTip.ListaManifestacija)
                {
                    m.Tip = noviTip;
                    m.TipString = NoviTip.ToString();
                }
            }

            if (((Button)sender).Name.Equals("nastavak"))
            {
                noviTip = new TipManifestacije();

                this.DataContext = noviTip;

                oznTxtBox.Focus();
                Keyboard.Focus(oznTxtBox);
            }
            else
            {
                this.Close();
            }
        }

        /* ----------- ODUSTAJANJE OD UNOSA/IZMENE I ZATVARANJE DIJALOGA ----------- */
        private void OdustaniClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ((Control)sender).GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }

        public TipManifestacije NoviTip
        {
            get { return noviTip; }
        }

        #region help

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[1]);
            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp(str, this);
            }
            else
            {
                HelpProvider.ShowHelp("unosTipa.html", this);
            }
        }

        #endregion

    }
}
