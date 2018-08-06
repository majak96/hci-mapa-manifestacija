using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Runtime.Serialization;

namespace MapaManifestacija.Model
{
    [DataContract(IsReference = true, Name = "Customer", Namespace = "http://www.contoso.com")]
    public class Etiketa : INotifyPropertyChanged
    {


        private string oznaka;
        private string boja;
        private string opis;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public Etiketa()
        {
            boja = null;
        }

        public Etiketa(Etiketa e)
        {
            this.oznaka = e.Oznaka;
            this.boja = e.Boja;
            this.opis = e.Opis;
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
        public string Boja
        {
            get { return boja; }
            set
            {
                if (boja != value)
                {
                    boja = value;
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

        public override string ToString()
        {
            return oznaka;
        }
    }
}
