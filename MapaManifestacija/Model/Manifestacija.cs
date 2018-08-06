using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Data;
using System.Globalization;
using System.Runtime.Serialization;
using System.Windows;

namespace MapaManifestacija.Model
{
    public enum TipAlkohol { NEMA, MOZE_DONETI, MOZE_KUPITI };
    public enum TipMesto { NAPOLJU, UNUTRA };
    public enum TipCena { BESPLATNO, NISKE_CENE, SREDNJE_CENE, VISOKE_CENE }

    [DataContract(IsReference = true, Name = "Customer", Namespace = "http://www.contoso.com")]
    public class Manifestacija : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private string oznaka;
        private string naziv;
        private string opis;
        private TipManifestacije tip;
        private TipAlkohol statusAlkohol;
        //private ImageSource ikonica;
        private string ikonica;
        private bool dostupnostZaHendikepirane;
        private bool dozvoljenoPusenje;
        private TipMesto mestoOdrzavanja;
        private TipCena kategorijaCena;
        private string ocekivanaPublika;
        private DateTime datumOdrzavanja;
        private string tipString;
        private string mestoString;
        private string cenaString;
        private string alkoholString;
        private Point tacka;

        [DataMember()]
        public ObservableCollection<Etiketa> ListaEtiketa
        {
            get; set;
        }


        public Manifestacija()
        {
            Point tacka = new Point(-1,-1);
            ListaEtiketa = new ObservableCollection<Etiketa>();
            tip = null;
            //ikonica = new BitmapImage(new Uri("C:\\Users\\Marijana Kolosnjaji\\Documents\\Visual Studio 2015\\Projects\\MapaManifestacija\\gray.jpg", UriKind.Absolute));
            ikonica = null; //"C:\\Users\\Marijana Kolosnjaji\\Documents\\Visual Studio 2015\\Projects\\MapaManifestacija\\gray.jpg";
           // mestoOdrzavanja = null;
           // kategorijaCena = null;
           // statusAlkohol = null;
        }

        public Manifestacija(Manifestacija m)
        {
            this.oznaka = m.oznaka;
            this.naziv = m.naziv;
            this.opis = m.opis;
            this.tip = m.tip;
            this.statusAlkohol = m.statusAlkohol;
            this.ikonica = m.ikonica;
            this.dostupnostZaHendikepirane = m.dostupnostZaHendikepirane;
            this.dozvoljenoPusenje = m.dozvoljenoPusenje;
            this.mestoOdrzavanja = m.mestoOdrzavanja;
            this.kategorijaCena = m.kategorijaCena;
            this.ocekivanaPublika = m.ocekivanaPublika;
            this.datumOdrzavanja = m.datumOdrzavanja;
            this.tipString = m.TipString;
            this.ListaEtiketa = m.ListaEtiketa;
            this.mestoString = m.mestoString;
            this.cenaString = m.cenaString;
            this.alkoholString = m.alkoholString;
            this.tacka = m.tacka;
        }

        [DataMember()]
        public string Oznaka
        {
            get { return oznaka; }
            set
            {
                if (oznaka != value)
                {
                    oznaka = value;
                    OnPropertyChanged("oznaka");
                }
            }
        }

        [DataMember()]
        public string Naziv
        {
            get { return naziv; }
            set
            {
                if (naziv != value)
                {
                    naziv = value;
                    OnPropertyChanged("naziv");
                }
            }
        }

        [DataMember()]
        public string Opis
        {
            get { return opis; }
            set
            {
                if (opis != value)
                {
                    opis = value;
                    OnPropertyChanged("opis");
                }
            }
        }

        [DataMember()]
        public string TipString
        {
            get { return tipString; }
            set
            {
                if (tipString != value)
                {
                    tipString = value;
                    OnPropertyChanged("tipString");
                }
            }
        }

        [DataMember()]
        public string CenaString
        {
            get { return cenaString; }
            set
            {
                if (cenaString != value)
                {
                    cenaString = value;
                    OnPropertyChanged("cipString");
                }
            }
        }

        [DataMember()]
        public string AlkoholString
        {
            get { return alkoholString; }
            set
            {
                if (alkoholString != value)
                {
                    alkoholString = value;
                    OnPropertyChanged("alkoholString");
                }
            }
        }

        [DataMember()]
        public string MestoString
        {
            get { return mestoString; }
            set
            {
                if (mestoString != value)
                {
                    mestoString = value;
                    OnPropertyChanged("mestoString");
                }
            }
        }

        [DataMember()]
        public TipManifestacije Tip
        {
            get { return tip; }
            set
            {
                if (tip != value)
                {
                    tip = value;
                    OnPropertyChanged("tip");
                }
            }
        }

        [DataMember()]
        public TipAlkohol StatusAlkohol
        {
            get { return statusAlkohol; }
            set
            {
                if (statusAlkohol != value)
                {
                    statusAlkohol = value;
                    OnPropertyChanged("statusAlkohol");
                }
            }
        }

        [DataMember()]
        public Point Tacka
        {
            get { return tacka; }
            set
            {
                if(tacka != value)
                {
                    tacka = value;
                    OnPropertyChanged("tacka");
                }
            }
        }

        /*   public ImageSource Ikonica
           {
               get { return ikonica; }
               set
               {
                   if(!ikonica.Equals(value))
                   {
                       ikonica = value;
                   }
               }
           } */

        [DataMember()]
        public string Ikonica
        {
            get { return ikonica; }
            set
            {
                if (ikonica != value)
                {
                    ikonica = value;
                    OnPropertyChanged("ikonica");
                }
            }
        }

        [DataMember()]
        public bool DostupnostZaHendikepirane
        {
            get { return dostupnostZaHendikepirane; }
            set
            {
                if (dostupnostZaHendikepirane != value)
                {
                    dostupnostZaHendikepirane = value;
                    OnPropertyChanged("dostupnostZaHendikepirane");
                }
            }
        }

        [DataMember()]
        public bool DozvoljenoPusenje
        {
            get { return dozvoljenoPusenje; }
            set
            {
                if (dozvoljenoPusenje != value)
                {
                    dozvoljenoPusenje = value;
                    OnPropertyChanged("dozvoljenoPusenje");
                }
            }
        }

        [DataMember()]
        public TipMesto MestoOdrzavanja
        {
            get { return mestoOdrzavanja; }
            set
            {
                if (mestoOdrzavanja != value)
                {
                    mestoOdrzavanja = value;
                    OnPropertyChanged("mestoOdrzavanja");
                }
            }
        }

        [DataMember()]
        public TipCena KategorijaCena
        {
            get { return kategorijaCena; }
            set
            {
                {
                    if (kategorijaCena != value)
                    {
                        kategorijaCena = value;
                        OnPropertyChanged("kategorijaCena");
                    }
                }
            }
        }

        [DataMember()]
        public string OcekivanaPublika
        {
            get { return ocekivanaPublika; }
            set
            {
                if (ocekivanaPublika != value)
                {
                    ocekivanaPublika = value;
                    OnPropertyChanged("ocekivanaPublika");
                }
            }
        }

        [DataMember()]
        public DateTime DatumOdrzavanja
        {
            get { return datumOdrzavanja; }
            set
            {
                if (datumOdrzavanja != value)
                {
                    datumOdrzavanja = value;
                    OnPropertyChanged("datumOdrzavanja");
                }
            }
        }


        public override string ToString()
        {
            return naziv;
        }

        public void addEtiketa(Etiketa e)
        {
            ListaEtiketa.Add(e);
        }

        public void removeEtiketa(Etiketa e)
        {
            ListaEtiketa.Remove(e);
        }

    }
}
