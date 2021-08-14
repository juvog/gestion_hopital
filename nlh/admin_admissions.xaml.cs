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

namespace nlh
{
    /// <summary>
    /// Logique d'interaction pour admin_admissions.xaml
    /// </summary>
    public partial class admin_admissions : Window
    {
        public admin_admissions()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var requete_admissions =
                from a in accueil.ma_bdo.admissions
                join p in accueil.ma_bdo.Patients on a.nss equals p.nss

                select new
                {
                    idAdmission = a.idAdmission,
                    nss = a.nss,
                    prenom = p.prenom,
                    nom = p.nom,
                    dateAdmission = a.dateAdmission,
                    noLit = a.noLit,
                    chirurgieProg = a.chirurgieProg,
                    dateChirurgie=  a.dateChirurgie,
                    televiseur=  a.televiseur,
                    telephone= a.telephone,
                    dateConge=  a.dateConge
                };

            dtgAdmissions.DataContext = requete_admissions.ToList();

        }

        private void btnQuitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
