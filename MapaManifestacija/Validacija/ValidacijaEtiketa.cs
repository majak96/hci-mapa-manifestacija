using MapaManifestacija.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MapaManifestacija.Validacija
{
    public class ValidacijaOznakeEtikete : ValidationRule
    {

        private ObservableCollection<Etiketa> listaEt = new ObservableCollection<Etiketa>();

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                if (string.IsNullOrEmpty((String)value))
                {
                    return new ValidationResult(false, "Polje je obavezno za popunjavanje.");
                }

                listaEt = ((MainWindow)Application.Current.Windows[0]).Etikete;

                foreach (Etiketa et in listaEt)
                {
                    if (UnosEtikete.staraEtiketaOznaka != null && value.Equals(UnosEtikete.staraEtiketaOznaka))
                    {
                        return new ValidationResult(true, null);
                    }
                    if (et.Oznaka.Equals(value))
                    {
                        return new ValidationResult(false, "Etiketa sa tom oznakom već postoji.");
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

    public class ValidacijaOpisaEtikete : ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {

            try
            {
                if (string.IsNullOrEmpty((String)value))
                {
                    return new ValidationResult(false, "Polje je obavezno za popunjavanje.");
                }

                return new ValidationResult(true, null);
            }
            catch
            {
                return new ValidationResult(false, "Nepoznata greška.");
            }
        }

    }

    public class ValidacijaBojeEtikete : ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {

            try
            {
                if (value == null)
                {
                    return new ValidationResult(false, "Polje je obavezno za popunjavanje.");
                }

                return new ValidationResult(true, null);
            }
            catch
            {
                return new ValidationResult(false, "Nepoznata greška.");
            }
        }

    }
}
