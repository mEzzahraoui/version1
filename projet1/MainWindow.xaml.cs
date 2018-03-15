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

namespace projet1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int i;
        public MainWindow()
        {
            InitializeComponent();
            i = 0;
        }

        //Si on click sur le button Power "Pour fermer L'application "
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //Si on click sur le button Login
        //On verifie si l' UserName=admin && password==12345
        // si oui ==> On passe à WindowPrincipale(La fenetre WPF qui Contient le traitement)
        // Si Non on affiche un message d'erreur et apres 3 essai L'application sera fermée
        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {

            if (UserName.Text.ToString().Equals("admin") && Pwd.Password.ToString().Equals("12345"))
            {
                WindowPrincipale windows = new WindowPrincipale();
                windows.Show();
                this.Close();
            }
            else
            {
                i++;
                if (i < 3)
                {
                    MsgError.Text = "Login or Password is incorrect , Il vous reste "+(3-i)+" essaies";
                }
                else
                {
                    MessageBox.Show("Vous avez fait 3 essaies l'application va s'arreter WARNING !!!");
                    Application.Current.Shutdown();
                }
            }

        }
    }
}
