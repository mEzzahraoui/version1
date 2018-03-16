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
using Telerik.Windows.Data;

namespace projet1
{
    /// <summary>
    /// Logique d'interaction pour Etudiants.xaml
    /// </summary>
    public partial class Etudiants : UserControl
    {
        public Etudiants()
        {
            InitializeComponent();
        }

        public static int id=0;
        FilterDescriptor filter = new FilterDescriptor();

        private void GridData_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            etudiant etudiant = (etudiant)GridData.SelectedItem;
            id = Convert.ToInt32(etudiant.cne);
        }

        private void GridData_TouchDown(object sender, TouchEventArgs e)
        {
            this.GridData.FilterDescriptors.Remove(filter);
        }

        private void search_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            etudiant filiere = (etudiant)search.SelectedItem;
            string datecre = filiere.Filiere.date_creation.ToString();
            DateTime date = Convert.ToDateTime(datecre);
            infosup.Content = filiere.Filiere.Nom_filiere + "\n responsable : " + filiere.Filiere.responsable + "\n date de création : " + date.ToShortDateString();

            //trier datagridview
            ListerFiliers.MyItems = new ObservableCollection<etudiant>((from c in ListerFiliers.cl.etudiant where c.Filiere.Nom_filiere == filiere.Filiere.Nom_filiere select c).ToList());

            filter.Operator = FilterOperator.Contains;
            filter.Value = filiere.Filiere.Nom_filiere;
            filter.Member = "Filiere.Nom_Filiere";
            this.GridData.FilterDescriptors.Add(filter);
        }

        private void radButton_Click(object sender, RoutedEventArgs e)
        {
            if (id != 0)
            {
                ListerFiliers.cl = new DataClasses1DataContext();
                ListerFiliers.lister = new ObservableCollection<etudiant>((from c in ListerFiliers.cl.etudiant
                                                             orderby c.cne == id descending
                                                             select c).ToList());
            }
            gridMain.Children.Clear();
            gridMain.Children.Add(new Modifier());
        }

        private void radButton1_Click(object sender, RoutedEventArgs e)
        {
            this.GridData.FilterDescriptors.Remove(filter);
            titre.Content = "";
            infosup.Content = "";
            search.Text = "";
        }
    }
}
