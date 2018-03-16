using Microsoft.Win32;
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
    /// Logique d'interaction pour Modifier.xaml
    /// </summary>
    public partial class Modifier : UserControl
    {
        public Modifier()
        {
            InitializeComponent();
        }
        public string image;

        private void radButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                etudiant etud = new etudiant();
                etud = radform.CurrentItem as etudiant;

                var x = (from c in ListerFiliers.cl.etudiant where c.cne == etud.cne select c).Single();
                x.nom = etud.nom;
                x.prenom = etud.prenom;
                x.adresse = etud.adresse;
                x.date_naiss = etud.date_naiss;
                x.sexe = etud.sexe;
                x.telephone = etud.telephone;
                x.Filiere.Nom_filiere = etud.Filiere.Nom_filiere;
                if (image != "" && image != null) x.image = image;
                ListerFiliers.cl.SubmitChanges();
                MessageBox.Show("validated!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("une erreu est survenue");
            }
        }

        private void uploadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

            /*    DataFormDataField field = new DataFormDataField();
                field = radform.TryFindResource("image") as DataFormDataField;*/

            if (op.ShowDialog() == true)
            {
                image = op.FileName;
            }
        }

        private void uploadButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            gridMain.Children.Clear();
            gridMain.Children.Add(new Etudiants());
        }


   
          /*  etudiant etud = new etudiant();
            DataFormDataField field = new DataFormDataField();
            field = (DataFormDataField)radform.FindName("cne");
            etud.cne = field.
                
          Lister.lister.Add(new etudiant {
                                     cne = etud.cne ,
                                     nom = etud.nom ,
                                     prenom = etud.prenom ,
                                     adresse = etud.adresse ,
                                     telephone = etud.telephone ,
                                     date_naiss = etud.date_naiss ,
                                     sexe = etud.sexe ,
                                     id_fil = etud.Filiere.Id_filiere ,
                                     image = image 
                              });

            MainWindow.cl.SubmitChanges();*/
    }
}
