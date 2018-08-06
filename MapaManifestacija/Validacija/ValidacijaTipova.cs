using MapaManifestacija.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MapaManifestacija.Validacija
{
    public class ValidacijaOznakeTipa : ValidationRule
    {

        private ObservableCollection<TipManifestacije> listaTipova = new ObservableCollection<TipManifestacije>();

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try {

                if (string.IsNullOrEmpty((String)value))
                {
                    return new ValidationResult(false, "Polje je obavezno za popunjavanje.");
                }

                listaTipova = ((MainWindow)Application.Current.Windows[0]).TipoviManifestacija;

                    foreach (TipManifestacije tm in listaTipova)
                    {
                        if (UnosTipa.stariTipOznaka != null && value.Equals(UnosTipa.stariTipOznaka))
                        {
                            return new ValidationResult(true, null);
                        }
                        if (tm.Oznaka.Equals(value))
                        {
                            return new ValidationResult(false, "Tip manifestacije sa tom oznakom već postoji.");
                        }
                    }

                    return new ValidationResult(true, null);
            }
            catch
            {
                return new ValidationResult(false, "Nepoznata greška.");
            }
        }

    }

    public class ValidacijaImenaTipa : ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {

            try
            {
                if (string.IsNullOrEmpty((String)value))
                {
                    return new ValidationResult(false, "Polje je obavezno za popunjavanje.");
                }
                else
                {
                    return new ValidationResult(true, null);
                }
            }
            catch
            {
                return new ValidationResult(false, "Nepoznata greška.");
            }
        }

    }

    public class ValidacijaIkoniceTipa : ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {

            try
            {
                if (value == null) {
                    return new ValidationResult(false, "Polje je obavezno za popunjavanje.");
                }
                else
                {
                    return new ValidationResult(true, null);
                }
            }
            catch
            {
                return new ValidationResult(false, "Nepoznata greška.");
            }
        }

    }
}
