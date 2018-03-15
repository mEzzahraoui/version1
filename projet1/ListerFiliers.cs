using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet1
{
    public class ListerFiliers
    {
        public static ObservableCollection<etudiant> MyItems { get; set; }
        public static ObservableCollection<Filiere> ListeFilieres { get; set; }

        public static DataClasses1DataContext cl;

        static ListerFiliers()
        {
            cl = new DataClasses1DataContext();
            MyItems = new ObservableCollection<etudiant>(cl.etudiant.ToList());
            ListeFilieres = new ObservableCollection<Filiere>(cl.Filiere.ToList());
        }
    }
}
