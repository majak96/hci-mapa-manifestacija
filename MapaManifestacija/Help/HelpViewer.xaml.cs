using System;
using System.Collections.Generic;
using System.IO;
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

namespace MapaManifestacija.Help
{
    /// <summary>
    /// Interaction logic for HelpViewer.xaml
    /// </summary>
    public partial class HelpViewer : Window
    {
        public HelpViewer(string key, MainWindow originator)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen; //centriranje prozora

            InitializeComponent();
            string path = String.Format("{0}\\Help\\{1}", "C:\\Users\\Marijana Kolosnjaji\\Documents\\Visual Studio 2015\\Projects\\MapaManifestacija\\MapaManifestacija", key);
            //if (!File.Exists(path))
            //{
            //    key = "error";
            //}
            Uri u = new Uri(String.Format("{0}\\Help\\{1}", "C:\\Users\\Marijana Kolosnjaji\\Documents\\Visual Studio 2015\\Projects\\MapaManifestacija\\MapaManifestacija", key));
            wbHelp.Navigate(u);

        }

        public HelpViewer(string key, UnosManifestacija originator)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen; //centriranje prozora

            InitializeComponent();
            string path = String.Format("{0}\\Help\\{1}", "C:\\Users\\Marijana Kolosnjaji\\Documents\\Visual Studio 2015\\Projects\\MapaManifestacija\\MapaManifestacija", key);
            //if (!File.Exists(path))
            //{
            //    key = "error";
            //}
            Uri u = new Uri(String.Format("{0}\\Help\\{1}", "C:\\Users\\Marijana Kolosnjaji\\Documents\\Visual Studio 2015\\Projects\\MapaManifestacija\\MapaManifestacija", key));
            wbHelp.Navigate(u);

        }

        public HelpViewer(string key, UnosTipa originator)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen; //centriranje prozora

            InitializeComponent();
            string path = String.Format("{0}\\Help\\{1}", "C:\\Users\\Marijana Kolosnjaji\\Documents\\Visual Studio 2015\\Projects\\MapaManifestacija\\MapaManifestacija", key);
            //if (!File.Exists(path))
            //{
            //    key = "error";
            //}
            Uri u = new Uri(String.Format("{0}\\Help\\{1}", "C:\\Users\\Marijana Kolosnjaji\\Documents\\Visual Studio 2015\\Projects\\MapaManifestacija\\MapaManifestacija", key));
            wbHelp.Navigate(u);

        }

        public HelpViewer(string key, UnosEtikete originator)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen; //centriranje prozora

            InitializeComponent();
            string path = String.Format("{0}\\Help\\{1}", "C:\\Users\\Marijana Kolosnjaji\\Documents\\Visual Studio 2015\\Projects\\MapaManifestacija\\MapaManifestacija", key);
            //if (!File.Exists(path))
            //{
            //    key = "error";
            //}
            Uri u = new Uri(String.Format("{0}\\Help\\{1}", "C:\\Users\\Marijana Kolosnjaji\\Documents\\Visual Studio 2015\\Projects\\MapaManifestacija\\MapaManifestacija", key));
            wbHelp.Navigate(u);
        }

        public HelpViewer(string key, IzborEtiketa originator)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen; //centriranje prozora

            InitializeComponent();
            string path = String.Format("{0}\\Help\\{1}", "C:\\Users\\Marijana Kolosnjaji\\Documents\\Visual Studio 2015\\Projects\\MapaManifestacija\\MapaManifestacija", key);
            //if (!File.Exists(path))
            //{
            //    key = "error";
            //}
            Uri u = new Uri(String.Format("{0}\\Help\\{1}", "C:\\Users\\Marijana Kolosnjaji\\Documents\\Visual Studio 2015\\Projects\\MapaManifestacija\\MapaManifestacija", key));
            wbHelp.Navigate(u);
        }

        private void BrowseBack_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((wbHelp != null) && (wbHelp.CanGoBack));
        }

        private void BrowseBack_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            wbHelp.GoBack();
        }

        private void BrowseForward_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((wbHelp != null) && (wbHelp.CanGoForward));
        }

        private void BrowseForward_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            wbHelp.GoForward();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void wbHelp_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
        }
    }
}
