using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet1
{
    public class OperationStatistique
    {
        DataClasses1DataContext dcd = new DataClasses1DataContext();

        public OperationStatistique()
        {
            this.UsersList = new ObservableCollection<statistique>();
            var x = from f in dcd.Filiere
                    join e in dcd.etudiant
                    on f.Id_filiere equals e.id_fil
                    group new { e, f } by new { f.Nom_filiere } into g
                    select new { nomFil = g.Key.Nom_filiere, nbrEtu = g.Count() };

            var y = from f in dcd.Filiere
                    join e in dcd.etudiant
                    on f.Id_filiere equals e.id_fil into outerJoin
                    from j in outerJoin.DefaultIfEmpty()
                    where j.id_fil == null
                    select new { nomFil = f.Nom_filiere };

            foreach (var i in x)
            {
                statistique f = new statistique();
                f.NombreEtudiant = i.nbrEtu;
                f.NomFiliere = i.nomFil;
                UsersList.Add(f);
            }

            foreach (var i in y)
            {
                statistique f = new statistique();
                f.NombreEtudiant = 0;
                f.NomFiliere = i.nomFil;
                UsersList.Add(f);
            }


        }

        public ObservableCollection<statistique> UsersList
        {
            get; set;
        }

        public class statistique : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            private int nbrEtudiant;
            private String nomFiliere;

            public int NombreEtudiant
            {
                get
                {
                    return this.nbrEtudiant;
                }
                set
                {
                    nbrEtudiant = value;
                    NotifyPropertyChanged("NombreEtudiant");
                }
            }

            public string NomFiliere
            {
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
}
