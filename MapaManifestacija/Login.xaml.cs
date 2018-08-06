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
using System.Windows.Shapes;

namespace MapaManifestacija
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen; //centriranje

            InitializeComponent();

            UsernameTextBox.Focus();
            Keyboard.Focus(UsernameTextBox);

            if (Application.Current.MainWindow == this)
            {
                Application.Current.MainWindow = null;
            }
        }

        private void LogInClick(object sender, RoutedEventArgs e)
        {
            if (PasswordTextBox.Password.Equals("admin") && UsernameTextBox.Text.Equals("admin"))
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Pogrešno korisničko ime i/ili lozinka! Pokušajte ponovo.", "Mapa manifestacija", MessageBoxButton.OK, MessageBoxImage.Asterisk);

            }
        }
    }
}
