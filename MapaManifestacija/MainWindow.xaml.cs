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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MapaManifestacija.Model;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using Microsoft.Win32;
using System.ComponentModel;
using MapaManifestacija.Help;

namespace MapaManifestacija
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<String> listaMesta = new List<String>() { "Napolju", "Unutra" };
        public List<String> listaCena = new List<String>() { "Besplatno", "Niske cene", "Srednje cene", "Visoke cene" };
        public List<String> listaAlkohol = new List<String>() { "Nema alkohola", "Može se doneti", "Može se kupiti" };

        private Point startPoint = new Point();
        private Boolean isDragging = false;

        /* ----------- PODACI ----------- */
        public Data podaci;

        public ObservableCollection<Manifestacija> Manifestacije
        {
            get; set;
        }
        public ObservableCollection<Manifestacija> ManifestacijeNaMapi
        {
            get; set;
        }

        public ObservableCollection<TipManifestacije> TipoviManifestacija
        {
            get; set;
        }

        public ObservableCollection<Etiketa> Etikete
        {
            get; set;
        }

        /* ----------- KREIRANJE PROZORA ----------- */
        public MainWindow()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen; //centriranje prozora

            InitializeComponent();

            if (Application.Current.MainWindow == null)
            {
                Application.Current.MainWindow = this;
            }

            podaci = new Data();
            podaci.Name = "Manifestacije";

            //SaveToFile("MapaManifestacijaPodaciTry.xml");
            //ReadFromFile("MapaManifestacijaPodaciTry.xml");

            ManifestacijeNaMapi = podaci.ManifestacijeNaMapi;
            Manifestacije = podaci.Manifestacije;
            TipoviManifestacija = podaci.TipoviManifestacija;
            Etikete = podaci.Etikete;

            Mapa.ItemsSource = ManifestacijeNaMapi;
            stablo.ItemsSource = TipoviManifestacija;

            tabela.ItemsSource = Manifestacije;
            tabelaTip.ItemsSource = TipoviManifestacija;
            tabelaEtiketa.ItemsSource = Etikete;

            //na pocetku je vidljiva samo mapa sa manifestacijama, tabela se ne vidi
            taboviTabela.Visibility = Visibility.Collapsed;
            borderTabela.Visibility = Visibility.Collapsed;
 
        }

        /* ----------- DODAVANJE U LISTE U MAINFRAME-U ----------- */
        public void addManifestacija(Manifestacija m)
        {
            Manifestacije.Add(m);
        }

        public void addTip(TipManifestacije t)
        {
            TipoviManifestacija.Add(t);
        }

        public void addEtiketa(Etiketa e)
        {
            Etikete.Add(e);
        }

        /* ----------- FORMA ZA DODAVANJE NOVE MANIFESTACIJE ----------- */
        private void DodavanjeManifestacijeClick(object sender, RoutedEventArgs e)
        {
            if (TipoviManifestacija.Count() == 0)
            {
                MessageBox.Show("Nije moguće dodati manifestaciju ukoliko ne postoji nijedan tip manifestacije!", "Mapa manifestacija", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                UnosManifestacija unosM = new UnosManifestacija();
                unosM.ShowDialog();
            }
        }

        /* ----------- FORMA ZA DODAVANJE NOVOG TIPA MANIFESTACIJE ----------- */
        private void DodavanjeTipaManifestacijeClick(object sender, RoutedEventArgs e)
        {
            UnosTipa unosT = new UnosTipa();
            unosT.ShowDialog();
        }

        /* ----------- FORMA ZA DODAVANJE NOVE ETIKETE ----------- */
        private void DodavanjeEtiketeClick(object sender, RoutedEventArgs e)
        {
            UnosEtikete unosE = new UnosEtikete(); //poziva se konstruktor bez parametara kad se etiketa kreira iz MainWindow-a
            unosE.ShowDialog();
        }

        /* ----------- IZMENA IZABRANOG TIPA/MANIFESTACIJE/ETIKETE ----------- */
        private void IzmenaClick(object sender, RoutedEventArgs e)
        {
            if (tabovi.IsVisible == false) //za sada ne moze da se brise ako nije u tabelarnom prikazu
            {
                MessageBox.Show("Izmena tipa manifestacije/manifestacije/etikete je omogućena samo iz tabelarnog prikaza.", "Mapa manifestacija", MessageBoxButton.OK, MessageBoxImage.Asterisk);

            }
            else if (tabela.SelectedItem == null && tabovi.SelectedIndex == 0) //tab za manifestacije
            {
                MessageBox.Show("Morate označiti manifestaciju u tabelarnom prikazu koju želite da izmenite.", "Mapa manifestacija", MessageBoxButton.OK, MessageBoxImage.Asterisk);

            }
            else if (tabelaTip.SelectedItem == null && tabovi.SelectedIndex == 1) //tab za tipove manifestacija
            {
                MessageBox.Show("Morate označiti tip manifestacije u tabelarnom prikazu koji želite da izmenite.", "Mapa manifestacija", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else if (tabelaEtiketa.SelectedItem == null && tabovi.SelectedIndex == 2) //tab za etikete
            {
                MessageBox.Show("Morate označiti etiketu u tabelarnom prikazu koju želite da izmenite.", "Mapa manifestacija", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else if (tabelaEtiketa.SelectedItem is Etiketa && tabovi.SelectedIndex == 2)
            {
                Etiketa selectedEt = (Etiketa)tabelaEtiketa.SelectedItem;

                UnosEtikete unosE = new UnosEtikete(selectedEt); //poziva se konstruktor sa starom etiketom kod izmene
                unosE.ShowDialog();
            }
            else if (tabelaTip.SelectedItem is TipManifestacije && tabovi.SelectedIndex == 1)
            {
                TipManifestacije selectedTip = (TipManifestacije)tabelaTip.SelectedItem;

                UnosTipa unosT = new UnosTipa(selectedTip); //poziva se konstruktor sa starim tipom kod izmene
                unosT.ShowDialog();
            }
            else if (tabela.SelectedItem is Manifestacija && tabovi.SelectedIndex == 0)
            {
                Manifestacija selectedMan = (Manifestacija)tabela.SelectedItem;

                UnosManifestacija unosM = new UnosManifestacija(selectedMan); //poziva se konstruktor sa starom manifestacijom kod izmene
                unosM.ShowDialog();
            }
        }

        /* ----------- BRISANJE IZABRANOG TIPA/MANIFESTACIJE/ETIKETE ----------- */
        private void BrisanjeClick(object sender, RoutedEventArgs e)
        {
            //ako odlucim da lokalizujem message box-ove v
            /*Xceed.Wpf.Toolkit.MessageBox mbox = new Xceed.Wpf.Toolkit.MessageBox();
                mbox.OkButtonContent = "U redu";
                mbox.Caption = "Mapa manifestacija";
                mbox.Text = "Morate označiti manifestaciju koju želite da obrišete.";
                mbox.ShowDialog(); */

            if(tabovi.IsVisible == false) //za sada ne moze da se brise ako nije u tabelarnom prikazu
            {
                MessageBox.Show("Brisanje tipa manifestacije/manifestacije/etikete je omogućeno samo iz tabelarnog prikaza.", "Mapa manifestacija", MessageBoxButton.OK, MessageBoxImage.Asterisk);

            }
            else if (tabela.SelectedItem == null && tabovi.SelectedIndex == 0) //tab za manifestacije
            {
                MessageBox.Show("Morate označiti manifestaciju u tabelarnom prikazu koju želite da obrišete.", "Mapa manifestacija", MessageBoxButton.OK, MessageBoxImage.Asterisk);

            }
            else if (tabelaTip.SelectedItem == null && tabovi.SelectedIndex == 1) //tab za tipove manifestacija
            {
                MessageBox.Show("Morate označiti tip manifestacije u tabelarnom prikazu koji želite da obrišete.", "Mapa manifestacija", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else if (tabelaEtiketa.SelectedItem == null && tabovi.SelectedIndex == 2) //tab za etikete
            {
                MessageBox.Show("Morate označiti etiketu u tabelarnom prikazu koju želite da obrišete.", "Mapa manifestacija", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else if (tabela.SelectedItem is Manifestacija && tabovi.SelectedIndex == 0) //tab za manifestacije
            {
                Manifestacija selectedMan = (Manifestacija)tabela.SelectedItem;
                TipManifestacije selectedManTip = ((Manifestacija)tabela.SelectedItem).Tip;

                Manifestacije.Remove(selectedMan); //brise se iz liste manifestacija
                ManifestacijeNaMapi.Remove(selectedMan);
                selectedManTip.ListaManifestacija.Remove(selectedMan); //brise se iz tipa kome pripada

            }
            else if (tabelaTip.SelectedItem is TipManifestacije && tabovi.SelectedIndex == 1) //tab za tipove
            {
                MessageBoxResult dialogResult = MessageBox.Show("Brisanjem tipa manifestacije brišu se i sve manifestacija tog tipa. Da li ste sigurni da želite da nastavite sa brisanjem?", "Mapa manifestacija", MessageBoxButton.YesNo);

                if (dialogResult == MessageBoxResult.Yes)
                {
                    TipManifestacije selectedTip = (TipManifestacije)tabelaTip.SelectedItem;

                    foreach (Manifestacija m in selectedTip.ListaManifestacija) //brisu se manifestacije koje pripadaju tipu
                    {
                        Manifestacije.Remove(m);
                        ManifestacijeNaMapi.Remove(m);
                    }
                    TipoviManifestacija.Remove(selectedTip); //brise se iz liste tipova
                }
                else if (dialogResult == MessageBoxResult.No)
                {
                    //do nothing for now
                }
            }
            else if (tabelaEtiketa.SelectedItem is Etiketa && tabovi.SelectedIndex == 2) //tab za etikete
            {
                Etiketa selectedEt = (Etiketa)tabelaEtiketa.SelectedItem;

                foreach (Manifestacija m in Manifestacije) //brise se etiketa iz svih manifestacija kojim pripada
                {
                    m.ListaEtiketa.Remove(selectedEt);
                }
                Etikete.Remove(selectedEt); //brise se iz liste etiketa
            }
        }

        /* ----------- PROMENA NACINA PRIKAZA PODATAKA ----------- */
        private void PromenaPrikazaClick(object sender, RoutedEventArgs e)
        {
            if (Mapa.Visibility == Visibility.Visible) //slika -> tabela
            {
                Mapa.Visibility = Visibility.Collapsed;
                borderSlika.Visibility = Visibility.Collapsed;

                taboviTabela.Visibility = Visibility.Visible;
                borderTabela.Visibility = Visibility.Visible;

                PrikazButtonTxt.Text = "Grafički prikaz";
                //PrikazButtonImg.Source = new BitmapImage(new Uri("C:\\Users\\Marijana Kolosnjaji\\Documents\\Visual Studio 2015\\Projects\\MapaManifestacija\\map.png"));
                PrikazButton.ToolTip = "Prikaz mape unetih manifestacija";
            }
            else if (Mapa.Visibility == Visibility.Collapsed) //tabela -> slika
            {
                taboviTabela.Visibility = Visibility.Collapsed;
                borderTabela.Visibility = Visibility.Collapsed;

                Mapa.Visibility = Visibility.Visible;
               borderSlika.Visibility = Visibility.Visible;

                PrikazButtonTxt.Text = "Tabelarni prikaz";
                //PrikazButtonImg.Source = new BitmapImage(new Uri("C:\\Users\\Marijana Kolosnjaji\\Documents\\Visual Studio 2015\\Projects\\MapaManifestacija\\statistics.png"));
                PrikazButton.ToolTip = "Tabelarni prikaz unetih manifestacija";
            }
        }

        #region drag&drop
        private void Tree_Map_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e){
            startPoint = e.GetPosition(null);
        }

        private void TreeViewItem_OnItemSelected(object sender, RoutedEventArgs e)
        {
            stablo.Tag = e.OriginalSource;
        }

        private void Tree_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && !isDragging)
            {
                Point position = e.GetPosition(null);
                if (Math.Abs(position.X - startPoint.X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(position.Y - startPoint.Y) > SystemParameters.MinimumVerticalDragDistance)
                {
                    StartDrag(e);
                }
            }
        }

        private void StartDrag(MouseEventArgs e)
        {
            if (stablo.SelectedItem is Manifestacija) //da ne bi moglo nesto drugo da se drag-uje
            {
                isDragging = true;

                Manifestacija selectedMan= (Manifestacija)stablo.SelectedItem;
                TreeViewItem tvi = stablo.Tag as TreeViewItem;

                DataObject dragData = new DataObject("manifestacijaDrag", selectedMan);
                if (isDragging == true)
                {
                    DragDrop.DoDragDrop(tvi, dragData, DragDropEffects.Move);
                }

                isDragging = false;
            }
        }

        private void ManifestacijeNaMapi_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("manifestacijaDrag"))
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void ManifestacijeNaMapi_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("manifestacijaDrag"))
            {
                Manifestacija man = e.Data.GetData("manifestacijaDrag") as Manifestacija;
                man.Tacka = e.GetPosition(Mapa);
                if (!ManifestacijeNaMapi.Contains(man))
                {
                    ManifestacijeNaMapi.Add(man);
                }
                //man.Tip.ListaManifestacija.Remove(man);
                isDragging = false;
            } 
        }

        private void ManifestacijeNaMapi_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && !isDragging)
            {
                Point position = e.GetPosition(null);
                if (Math.Abs(position.X - startPoint.X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(position.Y - startPoint.Y) > SystemParameters.MinimumVerticalDragDistance)
                {
                    StartDragMapa(e);
                }
            }
        }

        private void StartDragMapa(MouseEventArgs e)
        {
            if (Mapa.SelectedItem is Manifestacija) //zbog null, ako je neko krenuo da vuce po mapi bezveze
            {
                isDragging = true;
                Manifestacija selectedItem = (Manifestacija)Mapa.SelectedItem;
                ListBoxItem lwi = (ListBoxItem)Mapa.ItemContainerGenerator.ContainerFromItem(selectedItem);
                // Initialize the drag & drop operation
                DataObject dragData = new DataObject("manifestacijaDrag", selectedItem);
                if (isDragging == true)
                    DragDrop.DoDragDrop(lwi, dragData, DragDropEffects.Move);
                isDragging = false;
            }
        }

        private void Tree_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("manifestacijaDrag"))
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void Tree_DragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("manifestacijaDrag"))
            {
                e.Effects = DragDropEffects.None;
                e.Handled = true;
            }
            else //ova komplikacija je da se lokali ne mogu uzeti iz drveta i vratiti u drvo, jer je glupo
            {
                Manifestacija man = e.Data.GetData("manifestacijaDrag") as Manifestacija;
                if (man.Tacka.X == -1)
                {
                    e.Effects = DragDropEffects.None;
                    e.Handled = true;
                }
            }
        }

        private void Tree_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("manifestacijaDrag"))
            {
                Manifestacija man = e.Data.GetData("manifestacijaDrag") as Manifestacija;

                if (man.Tacka.X != -1)
                {
                    ManifestacijeNaMapi.Remove(man);
                    man.Tacka = new Point(-1, -1);
                    //man.Tip.ListaManifestacija.Add(man);
                }
                isDragging = false;
            }
        }
        #endregion

        #region search
        /* METODA ZA PRETRAŽIVANJE TABELE MANIFESTACIJA */
        private void searchManifestacijeTextEntered(object sender, RoutedEventArgs e)
        {
            string filter = searchManifestacijeTxt.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(tabela.ItemsSource);
            if (filter == "")
            {
                cv.Filter = null;
            }
            else
            {
                cv.Filter = o =>
                {
                    Manifestacija m = o as Manifestacija;
                    String format = "dd.MM.yyyy";
                    return (m.Naziv.ToLower().Contains(filter.ToLower()) || m.Oznaka.ToLower().Contains(filter.ToLower()) || 
                            m.TipString.ToString().ToLower().Contains(filter.ToLower()) || m.Opis.ToLower().Contains(filter.ToLower()) || 
                            m.DatumOdrzavanja.ToString(format).ToLower().Contains(filter.ToLower()) || m.AlkoholString.ToLower().Contains(filter.ToLower()) ||
                            m.CenaString.ToLower().Contains(filter.ToLower()) || m.MestoString.ToLower().Contains(filter.ToLower()) ||
                            m.OcekivanaPublika.ToLower().Contains(filter.ToLower()));
                };
            }
        }

        /* METODA ZA PONIŠTAVANJE PRETRAGE TABELE MANIFESTACIJA */
        private void searchManifestacijeTextCleared(object sender, RoutedEventArgs e)
        {
            searchManifestacijeTxt.Clear();
            ICollectionView cv = CollectionViewSource.GetDefaultView(tabela.ItemsSource);
            cv.Filter = null;
        }

        /* METODA ZA PRETRAŽIVANJE TABELE TIPOVA MANIFESTACIJA */
        private void searchTipoviTextEntered(object sender, RoutedEventArgs e)
        {
            string filter = searchTipoviTxt.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(tabelaTip.ItemsSource);
            if (filter == "")
            {
                cv.Filter = null;
            }
            else
            {
                cv.Filter = o =>
                {
                    TipManifestacije t = o as TipManifestacije;
                    return (t.Naziv.ToLower().Contains(filter.ToLower()) || t.Opis.ToLower().Contains(filter.ToLower()) || t.Oznaka.ToLower().Contains(filter.ToLower()));
                };
            }
        }

        /* METODA ZA PONIŠTAVANJE PRETRAGE TABELE TIPOVA MANIFESTACIJA */
        private void searchTipoviTextCleared(object sender, RoutedEventArgs e)
        {
            searchTipoviTxt.Clear();
            ICollectionView cv = CollectionViewSource.GetDefaultView(tabelaTip.ItemsSource);
            cv.Filter = null;
        }

        /* METODA ZA PRETRAŽIVANJE TABELE ETIKETA */
        private void searchEtiketeTextEntered(object sender, RoutedEventArgs e)
        {
            string filter = searchEtiketeTxt.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(tabelaEtiketa.ItemsSource);
            if (filter == "")
            {
                cv.Filter = null;
            }
            else
            {
                cv.Filter = o =>
                {
                    Etiketa et = o as Etiketa;
                    return (et.Opis.ToLower().Contains(filter.ToLower()) || et.Oznaka.ToLower().Contains(filter.ToLower()));
                };
            }
        }

        /* METODA ZA PONIŠTAVANJE PRETRAGE TABELE ETIKETA */
        private void searchEtiketeTextCleared(object sender, RoutedEventArgs e)
        {
            searchEtiketeTxt.Clear();
            ICollectionView cv = CollectionViewSource.GetDefaultView(tabelaEtiketa.ItemsSource);
            cv.Filter = null;
        }
        #endregion

        #region serijalizacija
        /* ----------- UCITAVANJE PODATAKA IZ .XML FAJLA ----------- */
        private void UcitavanjeClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml";
            if (openFileDialog.ShowDialog() == true)
            {
                ReadFromFile(openFileDialog.FileName);

                Manifestacije = podaci.Manifestacije;
                TipoviManifestacija = podaci.TipoviManifestacija;
                Etikete = podaci.Etikete;
                ManifestacijeNaMapi = podaci.ManifestacijeNaMapi;

                //moraju tabele i stablo i mapa ponovo da se popune
                stablo.ItemsSource = TipoviManifestacija;
                Mapa.ItemsSource = ManifestacijeNaMapi;

                tabela.ItemsSource = Manifestacije;
                tabelaTip.ItemsSource = TipoviManifestacija;
                tabelaEtiketa.ItemsSource = Etikete;
            }
        }

        /* ----------- CUVANJE PODATAKA U .XML FAJL ----------- */
        private void CuvanjeClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML file (*.xml)|*.xml";
            saveFileDialog.AddExtension = true;
            if (saveFileDialog.ShowDialog() == true)
            {
                SaveToFile(saveFileDialog.FileName);
            }
        }

        /* ----------- SERIJALIZACIJA U .XML FAJL ----------- */
        public void SaveToFile(String filename)
        {
            FileStream writer = new FileStream(filename, FileMode.Create);
            try
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(Data));
                ser.WriteObject(writer, podaci);
            }
            catch
            {
                MessageBox.Show("Došlo je do greške prilikom čuvanja podataka!", "Mapa manifestacija", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            finally
            {
                writer.Close();
            }
        }

        /* ----------- CITANJE IZ .XML FAJLA ----------- */
        public void ReadFromFile(String filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            try
            {
                
                XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                DataContractSerializer ser2 = new DataContractSerializer(typeof(Data));
                podaci = (Data)ser2.ReadObject(reader, true);
                reader.Close();
                
            }
            catch
            {
                MessageBox.Show("Došlo je do greške prilikom učitavanja podataka!", "Mapa manifestacija", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            finally
            {
                fs.Close();
            }
        }
        #endregion

        #region help

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp(str, this);
            }
            else
            {
                HelpProvider.ShowHelp("index.html", this);
            }
        }

        #endregion
    }

}
