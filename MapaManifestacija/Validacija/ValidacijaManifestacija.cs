using MapaManifestacija.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MapaManifestacija.Validacija
{
    public class ValidacijaOznakeManifestacije : ValidationRule
    {

        private ObservableCollection<Manifestacija> listaMan = new ObservableCollection<Manifestacija>();

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {

            try
            {
                if (string.IsNullOrEmpty((String)value))
                {
                    return new ValidationResult(false, "Polje je obavezno za popunjavanje.");
                }

                listaMan = ((MainWindow)Application.Current.Windows[0]).Manifestacije;

                foreach (Manifestacija m in listaMan)
                {
                    if (UnosManifestacija.staraManifestacijaOznaka != null && value.Equals(UnosManifestacija.staraManifestacijaOznaka))
                    {
                        return new ValidationResult(true, "Polje je ispravno popunjeno.");
                    }
                    if (m.Oznaka.Equals(value))
                    {
                        return new ValidationResult(false, "Manifestacija sa tom oznakom već postoji.");
                    }
                }

                return new ValidationResult(true, "Polje je ispravno popunjeno.");
            }
            catch
            {
                return new ValidationResult(false, "Nepoznata greška.");
            }
        }

    }

    public class ValidacijaImenaManifestacije : ValidationRule
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
                    return new ValidationResult(true, "Polje je ispravno popunjeno.");
                }
            }
            catch
            {
                return new ValidationResult(false, "Nepoznata greška.");
            }
        }

    }

    public class ValidacijaTipaManifestacije : ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
         {

            try
            {
                if (String.IsNullOrEmpty((String)value))
                {
                    return new ValidationResult(false, "Polje je obavezno za popunjavanje.");
                }
                else
                {
                    return new ValidationResult(true, "Polje je ispravno popunjeno.");
                }
            }
            catch
            {
                return new ValidationResult(false, "Nepoznata greška.");
            }
        }

    }

    public class ValidacijaIkoniceManifestacije : ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {

            try
            {
                if (value == null)
                {
                    return new ValidationResult(false, "Polje je obavezno za popunjavanje.");
                }
                else
                {
                    return new ValidationResult(true, "Polje je ispravno popunjeno.");
                }
            }
            catch
            {
                return new ValidationResult(false, "Nepoznata greška.");
            }
        }

    }
}
