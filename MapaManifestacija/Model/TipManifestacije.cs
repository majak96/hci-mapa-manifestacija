using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MapaManifestacija.Model
{
    [DataContract(IsReference = true, Name = "Customer", Namespace = "http://www.contoso.com")]
    public class TipManifestacije : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        [DataMember()]
        public ObservableCollection<Manifestacija> ListaManifestacija
        {
            get; set;
        }

        public TipManifestacije()
        {
            ListaManifestacija = new ObservableCollection<Manifestacija>();
            //ikonica = new BitmapImage(new Uri("C:\\Users\\Marijana Kolosnjaji\\Documents\\Visual Studio 2015\\Projects\\MapaManifestacija\\gray.jpg", UriKind.Absolute));
            ikonica = null; //"C:\\Users\\Marijana Kolosnjaji\\Documents\\Visual Studio 2015\\Projects\\MapaManifestacija\\gray.jpg";
        }

        public TipManifestacije(TipManifestacije t)
        {
            this.oznaka = t.oznaka;
            this.naziv = t.naziv;
            this.opis = t.opis;
            this.ikonica = t.ikonica;
            this.ListaManifestacija = t.ListaManifestacija;
        }

        private string oznaka;
        private string naziv;
        //[NonSerialized] private ImageSource ikonica;
        private string opis;
        private string ikonica;

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

        /*   public ImageSource Ikonica
           {
               get { return ikonica; }
               set
               {
                   if (!ikonica.Equals(value))
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

        public override string ToString()
        {
            return naziv;
        }

    }
}
