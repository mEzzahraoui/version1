using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet1
{
    public class ListerFiliers
    {
       // public static ObservableCollection<etudiant> MyItems { get; set; }
        public static ObservableCollection<OperationFiliere> ListeFilieres { get; set; }
        public static ObservableCollection<etudiant> MyItems { get; set; }
        public static ObservableCollection<etudiant> lister { get; set; }

        public static DataClasses1DataContext cl;

        public ListerFiliers()
        {
            cl = new DataClasses1DataContext();
            MyItems = new ObservableCollection<etudiant>(cl.etudiant.ToList());
            ListeFilieres = new ObservableCollection<OperationFiliere>(getAllFiliere());
        }

        public List<OperationFiliere> getAllFiliere() {
            List<OperationFiliere> l = new List<OperationFiliere>();
            var x = from fil in cl.Filiere
                    select fil;

            foreach(var i in x)
            {
                OperationFiliere f = new OperationFiliere();
                f.Id = i.Id_filiere;
                f.NomFiliere = i.Nom_filiere;
                f.Responsable = i.responsable;
                l.Add(f);
            }

            return l;
        }

        public String AjouterFiliere(String nomFil, String resp)
        {
            try
            {
                var x = (from fil in cl.Filiere
                         where fil.Nom_filiere == nomFil
                         select fil).SingleOrDefault();
                // si dans la base de donnée Nom filiere n'est pas définie unique
                if (x == null)
                {
                    Filiere nouveauFiliere = new Filiere();
                    nouveauFiliere.Nom_filiere = nomFil;
                    nouveauFiliere.responsable = resp;
                    cl.Filiere.InsertOnSubmit(nouveauFiliere);
                    cl.SubmitChanges();
                    var y = (from fil in cl.Filiere
                             where fil.Nom_filiere == nomFil
                             select fil.Id_filiere).SingleOrDefault();
                    OperationFiliere f = new OperationFiliere();
                    f.Id= (int)y;
                    f.NomFiliere = nouveauFiliere.Nom_filiere;
                    f.Responsable = nouveauFiliere.responsable;
                    ListeFilieres.Add(f);
                    return "Ajouté avec succès";
                }
                else
                    return "Filière " + nomFil + " existe deja";


            }
            catch
            {
                return "Filière " + nomFil + " existe deja";
            }
        }

        public String ModifierFiliere(Filiere f, String nomFil, String resp)
        {
            try
            {

                int id_fil = f.Id_filiere;
                var x = (from fil in cl.Filiere
                         where fil.Id_filiere == id_fil
                         select fil).SingleOrDefault();

                var y = (from fil in cl.Filiere
                         where fil.Nom_filiere == nomFil
                         select new { nom = fil.Nom_filiere, id = fil.Id_filiere }).SingleOrDefault();
                // si dans la base de donnée Nom filiere n'est pas définie unique
                if (y != null && y.id!=id_fil )
                {
                    return "Filière " + nomFil + " existe deja";
                }
                else
                {
                    x.Nom_filiere = nomFil;
                    x.responsable = resp;
                    cl.SubmitChanges();
                    return "Modification effectuée avec succès";
                }
                    
                
            }
            catch
            {
                return "Une erreur est survenu lors d'enregistremen des changements ";
            }

        }

        public String SupprimerFiliere(Filiere f)
        {
            try
            {
                OperationFiliere fil = new OperationFiliere();
                fil.Id = f.Id_filiere;
                fil.NomFiliere = f.Nom_filiere;
                fil.Responsable = f.responsable;
                ListeFilieres.Remove(fil);
                var x = (from filier in cl.Filiere
                         where filier.Id_filiere == f.Id_filiere
                         select filier).SingleOrDefault();
                cl.Filiere.DeleteOnSubmit(x);
                cl.SubmitChanges();
                return "La filiere " + f.Nom_filiere + " est supprimée de la base de donnée";
            }
            catch
            {
                return "Une erreur est survenu lors de la suppression de la filiere Veiller ressayer plus tard";
            }
        }


    }

    public class OperationFiliere : INotifyPropertyChanged
    {
        private int id;
        private String nomFiliere;
        private String responsable;



        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                id = value;
                NotifyPropertyChanged("Id");
            }
        }
        public string NomFiliere {
            get
            {
                return this.nomFiliere;
            }
            set
            {
                nomFiliere = value;
                NotifyPropertyChanged("NomFiliere");
            }
        }
        public string Responsable {
            get
            {
                return this.responsable;
            }
            set
            {
                responsable = value;
                NotifyPropertyChanged("Responsable");
            }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler Handler = PropertyChanged;
            if (Handler != null)
            {
                Handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
