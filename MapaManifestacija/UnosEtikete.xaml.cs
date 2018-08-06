using MapaManifestacija.Help;
using MapaManifestacija.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Xceed.Wpf.Toolkit;

namespace MapaManifestacija
{
    /// <summary>
    /// Interaction logic for UnosEtikete.xaml
    /// </summary>
    public partial class UnosEtikete : Window
    {

        /* ----------- PODACI ----------- */
        private Etiketa novaEtiketa;
        private Etiketa staraEtiketa;
        private Manifestacija novaManifestacija;

        public static string staraEtiketaOznaka; //vazno kod validacije kod izmene etikete, da bi mogla da se sacuva etiketa sa istim imenom

        private ObservableCollection<Xceed.Wpf.Toolkit.ColorItem> ColorList;

        /* ----------- KONSTRUKTOR KOJI SE KORISTI KAD SE KREIRA ETIKETA IZ GLAVNOG PROZORA ----------- */
        public UnosEtikete()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;


            novaEtiketa = new Etiketa();
            ColorList = new ObservableCollection<Xceed.Wpf.Toolkit.ColorItem>();

            popunjavanjeListe();

            InitializeComponent();

            this.DataContext = novaEtiketa;

            //popunjavanje color picker-a bojama
            ClrPcker.AvailableColors = ColorList;
            ClrPcker.StandardColors = ColorList;

            //fokus je na prvom polju za popunjavanje
            oznTxtBox.Focus();
            Keyboard.Focus(oznTxtBox);
        }

        /* ----------- KONSTRUKTOR KOJI SE KORISTI KAD SE KREIRA ETIKETA KOD UNOSA MANIFESTACIJE ----------- */
        public UnosEtikete(Manifestacija m)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen; //centriranje prozora

            novaEtiketa = new Etiketa();
            ColorList = new ObservableCollection<Xceed.Wpf.Toolkit.ColorItem>();

            popunjavanjeListe();

            InitializeComponent();

            this.DataContext = novaEtiketa;

            novaManifestacija = m; //manifestacija u koju se dodaje etiketa

            //popunjavanje color picker-a bojama
            ClrPcker.AvailableColors = ColorList;
            ClrPcker.StandardColors = ColorList;

            //fokus je na prvom polju za popunjavanje
            oznTxtBox.Focus();
            Keyboard.Focus(oznTxtBox);
        }

        /* ----------- KONSTRUKTOR KOJI SE KORISTI KOD IZMENE ETIKETE ----------- */
        public UnosEtikete(Etiketa staraE)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen; //centriranje prozora

            staraEtiketa = staraE;
            staraEtiketaOznaka = staraE.Oznaka;
            novaEtiketa = new Etiketa(staraEtiketa);
            ColorList = new ObservableCollection<Xceed.Wpf.Toolkit.ColorItem>();

            popunjavanjeListe();

            InitializeComponent();

            this.DataContext = novaEtiketa;

            nastavak.Visibility = Visibility.Collapsed;

            //popunjavanje color picker-a bojama
            ClrPcker.AvailableColors = ColorList;
            ClrPcker.StandardColors = ColorList;

            //fokus je na prvom polju za popunjavanje
            oznTxtBox.Focus();
            Keyboard.Focus(oznTxtBox);
        }

        /* ----------- POTVRDA I DODAVANJE ETIKETE ----------- */
        private void PotvrdiClick(object sender, RoutedEventArgs e)
        {
            if (novaManifestacija != null) //ako se etiketa kreira kod kreiranja manifestacije, dodaje se i u listu etiketa manifestacije
            {
                novaManifestacija.addEtiketa(novaEtiketa);
            }

            if (staraEtiketa == null)
            {
                ((MainWindow)Application.Current.Windows[0]).addEtiketa(novaEtiketa); //kreiranje i dodavanje u listu svih etiketa
            }
            else //izmena iz liste svih etiketa i liste etiketa manifestacije koja je sadrzi
            {
                int ind1 = ((MainWindow)Application.Current.Windows[0]).Etikete.IndexOf(staraEtiketa);
                ((MainWindow)Application.Current.Windows[0]).Etikete.RemoveAt(ind1);
                ((MainWindow)Application.Current.Windows[0]).Etikete.Insert(ind1, novaEtiketa);

                foreach(Manifestacija m in ((MainWindow)Application.Current.Windows[0]).Manifestacije)
                {
                    if (m.ListaEtiketa.Contains(staraEtiketa))
                    {
                        int ind2 = m.ListaEtiketa.IndexOf(staraEtiketa);
                        m.ListaEtiketa.RemoveAt(ind2);
                        m.ListaEtiketa.Insert(ind2, novaEtiketa);
                    }
                }
            }

            if (((Button)sender).Name.Equals("nastavak"))
            {
                novaEtiketa = new Etiketa();

                this.DataContext = novaEtiketa;

                oznTxtBox.Focus();
                Keyboard.Focus(oznTxtBox);
            }
            else
            {
                this.Close();
            }
        }

        /* ----------- ODUSTAJANJE OD UNOSA I ZATVARANJE DIJALOGA ----------- */
        private void OdustaniClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /* ----------- POPUNJAVANJE LISTE ODABRANIM BOJAMA ----------- */
        private void popunjavanjeListe()
        {
            ColorList.Add(new ColorItem(Colors.Red, "Red"));
            ColorList.Add(new ColorItem(Colors.Black, "Black"));
            ColorList.Add(new ColorItem(Colors.Blue, "Blue"));
            ColorList.Add(new ColorItem(Colors.Magenta, "Magenta"));
            ColorList.Add(new ColorItem(Colors.Green, "Green"));
            ColorList.Add(new ColorItem(Colors.Purple, "Purple"));
            ColorList.Add(new ColorItem(Colors.Yellow, "Yellow"));
            ColorList.Add(new ColorItem(Colors.Brown, "Brown"));
            ColorList.Add(new ColorItem(Colors.Orange, "Orange"));
            ColorList.Add(new ColorItem(Colors.Turquoise, "Turquoise"));
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ((Control)sender).GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }

        public Etiketa NovaEtiketa
        {
            get { return novaEtiketa; }
        }

        #region help

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl;
            if(Application.Current.Windows[1] is UnosManifestacija){
                focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[2]);
            }
            else{
                focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[1]);
            }

            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp(str, this);
            }
            else
            {
                HelpProvider.ShowHelp("unosEtikete.html", this);
            }
        }

        #endregion
    }
}
