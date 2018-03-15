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
        public static ObservableCollection<Filiere> fl;
        public static DataClasses1DataContext db;
        public Filieres()
        {
            InitializeComponent();
            db = new DataClasses1DataContext();
            fl = new ObservableCollection<Filiere>(db.Filiere.ToList());
        }

        private void radfil_Loaded(object sender, RoutedEventArgs e)
        {
            radfil.ItemsSource = fl;
        }

        private void ButtonAjouterfil_Click(object sender, RoutedEventArgs e)
        {
            String nom_fil = TextNomFiliere.Text;
            String res = TextResponsableFiliere.Text;
            var x = (from fil in db.Filiere
                     where fil.Nom_filiere == nom_fil
                     select fil).SingleOrDefault();
            if (x == null)
            {
                int id = fl.Count() + 1;
                Filiere nouveauFiliere = new Filiere();
                nouveauFiliere.Id_filiere = id;
                nouveauFiliere.Nom_filiere = nom_fil;
                nouveauFiliere.responsable = res;
                db.Filiere.InsertOnSubmit(nouveauFiliere);
                db.SubmitChanges();
                fl.Add(nouveauFiliere);
                MsgErrorFiliere.Text = "Ajouté avec succès";
            }
            else
            {
                MsgErrorFiliere.Text = "Filière " + nom_fil + " est déjà existe";
            }
        }

        private void ButtonModifierFil_Click(object sender, RoutedEventArgs e)
        {
            Filiere f = (Filiere)radfil.SelectedItem;
            int id_fil = Convert.ToInt32(TextIDFiliere.Text);
            String res = TextResponsableFiliere.Text;
            var x = (from fil in db.Filiere
                     where fil.Id_filiere == id_fil
                     select fil).SingleOrDefault();
            x.Id_filiere = Convert.ToInt32(TextIDFiliere.Text);
            x.Nom_filiere = TextNomFiliere.Text;
            x.responsable = res;
            db.SubmitChanges();
            MsgErrorFiliere.Text = "Modification effectuée avec succès";
        }

        private void buttonSupprimerFil_Click(object sender, RoutedEventArgs e)
        {
            String nom_fil = TextNomFiliere.Text;
            int id_fil = Convert.ToInt32(TextIDFiliere.Text);
            MessageBoxResult op = MessageBox.Show("Voulez vous supprimer la filière " + nom_fil + " ?", "confirmation de suppression", MessageBoxButton.YesNo);
            if (op == MessageBoxResult.Yes)
            {
                fl.Remove((Filiere)radfil.SelectedItem);
                var x = (from fil in db.Filiere
                         where fil.Id_filiere == id_fil
                         select fil).SingleOrDefault();
                db.Filiere.DeleteOnSubmit(x);
                db.SubmitChanges();
            }
        }
    }
}
