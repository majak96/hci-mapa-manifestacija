using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MapaManifestacija.Model
{
    [DataContract(IsReference = true, Name = "Customer", Namespace = "http://www.contoso.com")]
    public class Data : IExtensibleDataObject
    {
        [DataMember()]
        public ObservableCollection<Manifestacija> Manifestacije
        {
            get; set;
        }

        [DataMember()]
        public ObservableCollection<TipManifestacije> TipoviManifestacija
        {
            get; set;
        }

        [DataMember()]
        public ObservableCollection<Etiketa> Etikete
        {
            get; set;
        }

        [DataMember()]
        public ObservableCollection<Manifestacija> ManifestacijeNaMapi
        {
            get; set;
        }

        [DataMember()]
        public string Name { get; set; }

        private ExtensionDataObject extensionData_Value;

        public ExtensionDataObject ExtensionData
        {
            get
            {
                return extensionData_Value;
            }
            set
            {
                extensionData_Value = value;
            }
        }

        public Data()
        {
            Manifestacije = new ObservableCollection<Manifestacija>();
            TipoviManifestacija = new ObservableCollection<TipManifestacije>();
            Etikete = new ObservableCollection<Etiketa>();
            ManifestacijeNaMapi = new ObservableCollection<Manifestacija>();

            /*
            //podaci

            //ImageSource iconMusic = new BitmapImage(new Uri("C:\\Users\\Marijana Kolosnjaji\\Documents\\Visual Studio 2015\\Projects\\MapaManifestacija\\rsz_iconmusic.png"));
            //ImageSource iconMovie = new BitmapImage(new Uri("C:\\Users\\Marijana Kolosnjaji\\Documents\\Visual Studio 2015\\Projects\\MapaManifestacija\\rsz_iconmovie.png"));
            //ImageSource iconChildren = new BitmapImage(new Uri("C:\\Users\\Marijana Kolosnjaji\\Documents\\Visual Studio 2015\\Projects\\MapaManifestacija\\rsz_iconchildren.png"));
            String iconMusic = "C:\\Users\\Marijana Kolosnjaji\\Documents\\Visual Studio 2015\\Projects\\MapaManifestacija\\rsz_iconmusic.png";
            String iconMovie = "C:\\Users\\Marijana Kolosnjaji\\Documents\\Visual Studio 2015\\Projects\\MapaManifestacija\\rsz_iconmovie.png";
            String iconChildren = "C:\\Users\\Marijana Kolosnjaji\\Documents\\Visual Studio 2015\\Projects\\MapaManifestacija\\rsz_iconchildren.png";

            TipManifestacije t1 = new TipManifestacije() { Ikonica = iconMusic, Oznaka = "1001", Naziv = "Muzički festival", Opis="Prvi opis"};
            TipManifestacije t2 = new TipManifestacije() { Ikonica = iconMovie, Oznaka = "1002", Naziv = "Filmski festival", Opis="Drugi opis"};
            TipManifestacije t3 = new TipManifestacije() { Ikonica = iconChildren, Oznaka = "1003", Naziv = "Dečji festival", Opis="Treci opis"};

            TipoviManifestacija.Add(t1);
            TipoviManifestacija.Add(t2);
            TipoviManifestacija.Add(t3);

            Etiketa e1 = new Model.Etiketa() { Boja = "Red", Oznaka = "Etiketa11", Opis = "Prvi opis"};
            Etiketa e2 = new Model.Etiketa() { Boja = "Green", Oznaka = "Etiketa21", Opis = "Drugi opis" };
            Etiketa e3 = new Model.Etiketa() { Boja = "Blue", Oznaka = "Etiketa12", Opis = "Treci opis" };
            Etiketa e4 = new Model.Etiketa() { Boja = "Brown", Oznaka = "Etiketa22", Opis = "Cetvrti opis" };
            Etiketa e5 = new Model.Etiketa() { Boja = "Pink", Oznaka = "Etiketa13", Opis = "Peti opis" };
            Etiketa e6 = new Model.Etiketa() { Boja = "Purple", Oznaka = "Etiketa23", Opis = "Sesti opis" };


            ObservableCollection<Etiketa> l1 = new ObservableCollection<Etiketa>();
            l1.Add(e1);
            l1.Add(e2);

            ObservableCollection<Etiketa> l2 = new ObservableCollection<Etiketa>();
            l2.Add(e3);
            l2.Add(e4);

            ObservableCollection<Etiketa> l3 = new ObservableCollection<Etiketa>();
            l3.Add(e5);
            l3.Add(e6);

            Etikete.Add(e1); Etikete.Add(e2); Etikete.Add(e3); Etikete.Add(e4); Etikete.Add(e5); Etikete.Add(e6);

            ObservableCollection<Manifestacija> m1 = new ObservableCollection<Manifestacija>();
            ObservableCollection<Manifestacija> m2 = new ObservableCollection<Manifestacija>();
            ObservableCollection<Manifestacija> m3 = new ObservableCollection<Manifestacija>();

            Manifestacija man1 = new Manifestacija()
            {
                Ikonica = iconMusic,
                Oznaka = "0001",
                Naziv = "Exit Festival",
                DatumOdrzavanja = new DateTime(2018, 7, 10),
                Tip = t1,
                TipString = t1.ToString(),
                Opis = "Višestruko nagrađivani muzički festival koji se održava jednom godišnje na Petrovaradinskoj tvrđavi",
                StatusAlkohol = TipAlkohol.MOZE_KUPITI,
                AlkoholString = "Može se kupiti",
                DostupnostZaHendikepirane = false,
                DozvoljenoPusenje = true,
                OcekivanaPublika = "",
                MestoOdrzavanja = TipMesto.NAPOLJU,
                MestoString = "Napolju",
                KategorijaCena = TipCena.VISOKE_CENE,
                CenaString = "Visoke cene",
                ListaEtiketa = l1
            };

            Manifestacija man2 = new Manifestacija()
            {
                Ikonica = iconMovie,
                Oznaka = "0002",
                Naziv = "Cinema City",
                DatumOdrzavanja = new DateTime(2018, 9, 5),
                Tip = t2,
                TipString = t2.ToString(),
                Opis = "Međunarodni festival filma koji se svake godine u junu održava u Novom Sadu",
                StatusAlkohol = TipAlkohol.MOZE_KUPITI,
                AlkoholString = "Može se kupiti",
                DostupnostZaHendikepirane = true,
                DozvoljenoPusenje = true,
                OcekivanaPublika = "",
                MestoOdrzavanja = TipMesto.NAPOLJU,
                MestoString = "Napolju",
                KategorijaCena = TipCena.SREDNJE_CENE,
                CenaString = "Srednje cene",
                ListaEtiketa = l2
            };

            Manifestacija man3 = new Manifestacija()
            {
                Ikonica = iconChildren,
                Oznaka = "0003",
                Naziv = "Zmajeve dečje igre",
                DatumOdrzavanja = new DateTime(2018, 5, 25),
                Tip = t3,
                TipString = t3.ToString(),
                Opis = "Jedan od najvećih festivala za decu u Novom Sadu, nazvan po Jovanu Jovanoviću Zmaju",
                StatusAlkohol = TipAlkohol.NEMA,
                AlkoholString = "Nema alkohola",
                DostupnostZaHendikepirane = true,
                DozvoljenoPusenje = false,
                OcekivanaPublika = "Deca i roditelji",
                MestoOdrzavanja = TipMesto.NAPOLJU,
                MestoString = "Napolju",
                KategorijaCena = TipCena.BESPLATNO,
                CenaString = "Besplatno",
                ListaEtiketa = l3
            };

            m1.Add(man1);
            m2.Add(man2);
            m3.Add(man3);

            Manifestacije.Add(man1);
            Manifestacije.Add(man2);
            Manifestacije.Add(man3);

            t1.ListaManifestacija = m1;
            t2.ListaManifestacija = m2;
            t3.ListaManifestacija = m3;
            */
        }


    }
}
