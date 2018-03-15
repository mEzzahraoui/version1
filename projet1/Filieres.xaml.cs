using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour Filieres.xaml
    /// </summary>
    public partial class Filieres : UserControl
    {
        private ListerFiliers listF = new ListerFiliers();
        public Filieres()
        {
            InitializeComponent();
        }

        private void ButtonAjouterfil_Click(object sender, RoutedEventArgs e)
        {
            String nom_fil = TextNomFiliere.Text;
            String res = TextResponsableFiliere.Text;
            MsgErrorFiliere.Text = listF.AjouterFiliere(nom_fil, res);

            TextNomFiliere.Text = "";
            TextIDFiliere.Text = "";
            TextResponsableFiliere.Text = "";
        }

        private void ButtonModifierFil_Click(object sender, RoutedEventArgs e)
        {
            Filiere f = (Filiere)radfil.SelectedItem;
            MsgErrorFiliere.Text = listF.ModifierFiliere(f, TextNomFiliere.Text, TextResponsableFiliere.Text);
            TextNomFiliere.Text = "";
            TextIDFiliere.Text = "";
            TextResponsableFiliere.Text = "";

        }

        private void buttonSupprimerFil_Click(object sender, RoutedEventArgs e)
        {
            String nom_fil = TextNomFiliere.Text;
            int id_fil = Convert.ToInt32(TextIDFiliere.Text);
            MessageBoxResult op = MessageBox.Show("Voulez vous supprimer la filière " + nom_fil + " ?", "confirmation de suppression", MessageBoxButton.YesNo);
            if (op == MessageBoxResult.Yes)
            {
                MessageBox.Show(listF.SupprimerFiliere((Filiere)radfil.SelectedItem));
            }
            TextNomFiliere.Text = "";
            TextIDFiliere.Text = "";
            TextResponsableFiliere.Text = "";
        }
    }
}
