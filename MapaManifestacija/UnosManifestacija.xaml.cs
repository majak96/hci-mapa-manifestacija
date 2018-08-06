using MapaManifestacija;
using MapaManifestacija.Help;
using MapaManifestacija.Model;
using Microsoft.Win32;
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

namespace MapaManifestacija
{
    /// <summary>
    /// Interaction logic for UnosManifestacija.xaml
    /// </summary>
    public partial class UnosManifestacija : Window
    {
        
        /* ----------- PODACI ----------- */
        private Manifestacija novaManifestacija;
        private Manifestacija staraManifestacija;
        public static string staraManifestacijaOznaka;

        private bool dodataIkonica = false; //sluzi da znamo da li je korisnik izabrao ikonicu, ili treba staviti default ikonicu tipa

        public List<String> listaMesta = new List<String>() { "Napolju", "Unutra" };
        public List<String> listaCena = new List<String>() { "Besplatno", "Niske cene", "Srednje cene", "Visoke cene"};
        public List<String> listaAlkohol = new List<String>() { "Nema alkohola", "Može se doneti", "Može se kupiti" };


        /* ----------- KONSTRUKTOR KOJI SE KORISTI KAD SE KREIRA MANIFESTACIJA IZ GLAVNOG PROZORA ----------- */
        public UnosManifestacija()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen; //centriranje prozora

            novaManifestacija = new Manifestacija() { DatumOdrzavanja = DateTime.Now }; //postavi datum na trenutni

            InitializeComponent();

            tipCmbBox.ItemsSource = ((MainWindow)Application.Current.Windows[0]).TipoviManifestacija;
            //tipCmbBox.SelectedIndex = 0;

            listbox.ItemsSource = novaManifestacija.ListaEtiketa;
            this.DataContext = novaManifestacija;

            mestoCmbBox.ItemsSource = listaMesta;
            alkCmbBox.ItemsSource = listaAlkohol;
            cenaCmbBox.ItemsSource = listaCena;

            //fokus je na prvom polju za popunjavanje
            oznTxtBox.Focus();
            Keyboard.Focus(oznTxtBox);
        }

        /* ----------- KONSTRUKTOR KOJI SE KORISTI KOD IZMENE MANIFESTACIJE ----------- */
        public UnosManifestacija(Manifestacija staraM)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen; //centriranje prozora

            staraManifestacija = staraM;
            staraManifestacijaOznaka = staraM.Oznaka;
            novaManifestacija = new Manifestacija(staraM);

            InitializeComponent();

            tipCmbBox.ItemsSource = ((MainWindow)Application.Current.Windows[0]).TipoviManifestacija;
            //tipCmbBox.SelectedIndex = 0;
            mestoCmbBox.ItemsSource = Enum.GetValues(typeof(TipMesto));
            alkCmbBox.ItemsSource = Enum.GetValues(typeof(TipAlkohol));
            cenaCmbBox.ItemsSource = Enum.GetValues(typeof(TipCena));

            listbox.ItemsSource = novaManifestacija.ListaEtiketa;
            this.DataContext = novaManifestacija;

            nastavak.Visibility = Visibility.Collapsed;

            mestoCmbBox.ItemsSource = listaMesta;
            alkCmbBox.ItemsSource = listaAlkohol;
            cenaCmbBox.ItemsSource = listaCena;

            //fokus je na prvom polju za popunjavanje
            oznTxtBox.Focus();
            Keyboard.Focus(oznTxtBox);

        }

        /* ----------- FORMA ZA DODAVANJE NOVE ETIKETE ----------- */
        private void KreiranjeEtikete(object sender, RoutedEventArgs e)
        {
            UnosEtikete unosE = new UnosEtikete(novaManifestacija);
            unosE.ShowDialog();
        }

        /* ----------- FORMA ZA DODAVANJE POSTOJECE ETIKETE ----------- */
        private void DodavanjeEtikete(object sender, RoutedEventArgs e)
        {
            IzborEtiketa izborE = new IzborEtiketa(novaManifestacija);
            izborE.ShowDialog();
        }

        /* ----------- IZBACIVANJE SELEKTOVANE ETIKETE ----------- */
        private void IzbacivanjeEtikete(object sender, RoutedEventArgs e)
        {
            if (listbox.SelectedItem == null) //ako se nista ne selektuje
            {
                MessageBox.Show("Morate označiti etiketu koju želite da izbacite.", "Mapa manifestacija", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                novaManifestacija.removeEtiketa((Etiketa)listbox.SelectedItem);
            }
        }

        /* ----------- DODAVANJE SLIKE MANIFESTACIJE ----------- */
        private void DodajSlikuClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                novaManifestacija.Ikonica = openFileDialog.FileName;
                ikonica.Source = new BitmapImage(new Uri(novaManifestacija.Ikonica, UriKind.Absolute));

                dodataIkonica = true; //ako je ikonica dodata, ne treba dodati ikonicu tipa pri kreiranju
            }
        }

        /* ----------- POTVRDA I DODAVANJE/IZMENA MANIFESTACIJE ----------- */
        private void PotvrdiClick(object sender, RoutedEventArgs e)
        {
            if(staraManifestacija == null) 
            {
                if (!dodataIkonica) //uzima se ikonica tipa kao default ikonica, ako korisnik nije izabrao svoju
                {
                    novaManifestacija.Ikonica = ((TipManifestacije)tipCmbBox.SelectedItem).Ikonica;
                }

                ((MainWindow)Application.Current.Windows[0]).addManifestacija(novaManifestacija); //kreiranje i dodavanje u listu svih manifestacija
                ((TipManifestacije)tipCmbBox.SelectedItem).ListaManifestacija.Add(novaManifestacija); //dodavanje u listu manifestacija izabranog tipa
            }
            else
            {   //izmena iz liste svih manifestacija 
                int ind1 = ((MainWindow)Application.Current.Windows[0]).Manifestacije.IndexOf(staraManifestacija);
                ((MainWindow)Application.Current.Windows[0]).Manifestacije.RemoveAt(ind1);
                ((MainWindow)Application.Current.Windows[0]).Manifestacije.Insert(ind1, novaManifestacija);

                int ind2 = staraManifestacija.Tip.ListaManifestacija.IndexOf(staraManifestacija);
                staraManifestacija.Tip.ListaManifestacija.RemoveAt(ind2);

                if(staraManifestacija.Tip.Oznaka.Equals(novaManifestacija.Tip.Oznaka)) //ako ostaje u istom tipu manifestacije
                {
                    staraManifestacija.Tip.ListaManifestacija.Insert(ind2, novaManifestacija);
                }
                else   //ako menja tip manifestacije
                {
                    novaManifestacija.Tip.ListaManifestacija.Add(novaManifestacija);
                }

                if (((MainWindow)Application.Current.Windows[0]).ManifestacijeNaMapi.Contains(staraManifestacija)) //ako se nalazi na mapi
                {
                    int ind3 = ((MainWindow)Application.Current.Windows[0]).ManifestacijeNaMapi.IndexOf(staraManifestacija);
                    ((MainWindow)Application.Current.Windows[0]).ManifestacijeNaMapi.RemoveAt(ind3);
                    ((MainWindow)Application.Current.Windows[0]).ManifestacijeNaMapi.Insert(ind3, novaManifestacija);
                }

            }
            if (((Button)sender).Name.Equals("nastavak"))
            {
                novaManifestacija = new Manifestacija() { DatumOdrzavanja = DateTime.Now };
                listbox.ItemsSource = novaManifestacija.ListaEtiketa;
                this.DataContext = novaManifestacija;

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

        private void ComboBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ((Control)sender).GetBindingExpression(ComboBox.SelectedItemProperty).UpdateSource();
        }

        public Manifestacija NovaManifestacija
        {
            get { return novaManifestacija; }
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
                HelpProvider.ShowHelp("unosManifestacije.html", this);
            }
        }

        #endregion
    }
}
