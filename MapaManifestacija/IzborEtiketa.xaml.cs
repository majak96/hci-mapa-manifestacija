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

namespace MapaManifestacija
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class IzborEtiketa : Window
    {

        /* ----------- PODACI ----------- */
        private Manifestacija em;

        public ObservableCollection<Etiketa> SveEtikete
        {
            get; set;
        }

        public ObservableCollection<Etiketa> IzabraneEtikete
        {
            get; set;
        }

        /* ----------- KONSTRUKTOR KOJI SE KORISTI KAD SE DODAJE ETIKETA KOD UNOSA MANIFESTACIJE ----------- */
        public IzborEtiketa(Manifestacija m)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen; //centriranje prozora

            SveEtikete = new ObservableCollection<Etiketa>(); //etikete koje mogu da se dodaju manifestaciji
            IzabraneEtikete = new ObservableCollection<Etiketa>(); //izabrane etikete za dodavanje manifestaciji

            foreach (Etiketa e in ((MainWindow)Application.Current.Windows[0]).Etikete)
            {
                if (!m.ListaEtiketa.Contains(e))
                {
                    SveEtikete.Add(e);
                }
            }

            em = m;

            InitializeComponent();

            listbox1.ItemsSource = SveEtikete;
            listbox2.ItemsSource = IzabraneEtikete;
        }

        /* ----------- DODAVANJE ETIKETE U DESNU LISTU IZABRANIH ETIKETA ----------- */
        private void DodajEtiketu(object sender, RoutedEventArgs e)
        {
            if (listbox1.SelectedItem != null) //da ne bi dodao prazan red u listbox
            {
                IzabraneEtikete.Add((Etiketa)listbox1.SelectedItem);
                SveEtikete.Remove((Etiketa)listbox1.SelectedItem);
            }
        }

        /* ----------- VRACANJE ETIKETE U LEVU LISTU PREOSTALIH ETIKETA ----------- */
        private void VratiEtiketu(object sender, RoutedEventArgs e)
        {
            if(listbox2.SelectedItem != null) //da ne bi dodao prazan red u listbox
            {
                SveEtikete.Add((Etiketa)listbox2.SelectedItem);
                IzabraneEtikete.Remove((Etiketa)listbox2.SelectedItem);
            }
        }

        /* ----------- POTVRDA I DODAVANJE IZABRANIH ETIKETA MANIFESTACIJI ----------- */
        private void PotvrdiClick(object sender, RoutedEventArgs e)
        {
            foreach (Etiketa et in IzabraneEtikete)
            {
                em.addEtiketa(et);
            }
            this.Close();
        }

        /* ----------- ODUSTAJANJE OD DODAVANJA POSTOJECIH ETIKETA MANIFESTACIJI ----------- */
        private void OdustaniClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #region help

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[2]);
            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp(str, this);
            }
            else
            {
                HelpProvider.ShowHelp("izborEtikete.html", this);
            }
        }

        #endregion
    }
}
