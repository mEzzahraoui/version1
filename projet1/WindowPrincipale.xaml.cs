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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace projet1
{
    /// <summary>
    /// Logique d'interaction pour WindowPrincipale.xaml
    /// </summary>
    public partial class WindowPrincipale : Window
    {

        public WindowPrincipale()
        {
            InitializeComponent();
            Filieres usercontrol = new Filieres();
            Principale.Children.Add(usercontrol);
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {

            Application.Current.Shutdown();
        }

        
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonClose2.Visibility = Visibility.Collapsed;
            ButtonClose.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;

        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonClose.Visibility = Visibility.Collapsed;
            ButtonClose2.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void FieldManagmentButton_Click(object sender, RoutedEventArgs e)
        {
            Principale.Children.Clear();
            Filieres usercontrol = new Filieres();
            Principale.Children.Add(usercontrol);
            Storyboard s = (Storyboard)TryFindResource("CloseMenu");
            s.Begin();
            ButtonClose.Visibility = Visibility.Collapsed;
            ButtonClose2.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void StudentManagmentButton_Click(object sender, RoutedEventArgs e)
        {
            Principale.Children.Clear();
            Etudiants usercontrol = new Etudiants();
            Principale.Children.Add(usercontrol);
            Storyboard s = (Storyboard)TryFindResource("CloseMenu");
            s.Begin();
            ButtonClose.Visibility = Visibility.Collapsed;
            ButtonClose2.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void StatisticButton_Click(object sender, RoutedEventArgs e)
        {
            //Principale
            Principale.Children.Clear();
            statistic usercontrol = new statistic();
            Principale.Children.Add(usercontrol);
            Storyboard s = (Storyboard)TryFindResource("CloseMenu");
            s.Begin();
            ButtonClose.Visibility = Visibility.Collapsed;
            ButtonClose2.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }
    }
}
