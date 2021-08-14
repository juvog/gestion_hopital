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
    /// Logique d'interaction pour medecin.xaml
    /// </summary>
    public partial class medecin : Window
    {

        Patient le_patient = new Patient();
        public medecin()
        {
            InitializeComponent();
        }

        private void btnRechercher_Click(object sender, RoutedEventArgs e)
        {
            int numeroSS = int.Parse(txtNSS.Text);

            if (!String.IsNullOrEmpty(txtNSS.Text))
            {
                // On veut récupérer le nom et le prénom du patient
                var requete_patient =
                    from p in accueil.ma_bdo.Patients
                    where (p.nss == numeroSS)
                    select p;
                 
                le_patient = requete_patient.FirstOrDefault();

                if (le_patient == null)
                {
                    MessageBox.Show("Il n'y a pas de patient avec ce NSS", "Chercher patient", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    this.DataContext = le_patient;
                }
  

            }
            else
            {
                MessageBox.Show("Veuillez rentrer un NSS", "Chercher patient", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    



        private void btnQuitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnDonnerConge_Click(object sender, RoutedEventArgs e)
        {
            admission l_admission;
            int numeroSS = int.Parse(txtNSS.Text);
            if (!String.IsNullOrEmpty(txtNSS.Text))
            {
                // On veut récupérer l'admission pour laquelle le patient n'a pas encore eu de congé
                var requete_admission_patient =
                    from a in accueil.ma_bdo.admissions
                    join p in accueil.ma_bdo.Patients
                    on a.nss equals p.nss
                    where (p.nss == numeroSS && a.dateConge == null)
                    select a;

                List<admission> les_admissions = new List<admission>();
                les_admissions = requete_admission_patient.ToList();
                int nb_admissions = les_admissions.Count();
                

                if (nb_admissions == 0)
                {
                    MessageBox.Show("Le patient n'a pas d'admission en cours ou un congé lui a déjà été donné", "Chercher NSS", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    // il faut libérer le lit que le patient occupait 
                    l_admission = les_admissions.FirstOrDefault();

                    Lit le_lit = accueil.ma_bdo.Lits.Where(l => l.noLit == l_admission.noLit).FirstOrDefault();
                    le_lit.occupe = false;


                    // On définit la date du congé à la date actuelle.

                    DateTime la_date_conge = new DateTime();
                    la_date_conge = DateTime.Now.Date;
                    l_admission.dateConge = la_date_conge;

                    // On peut maintenant mettre à jour la base de données

                    try
                    {
                        accueil.ma_bdo.SaveChanges();
                        MessageBox.Show("Congé donné avec succès le : " + la_date_conge.ToString(), "Donner congé", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

            }
            else
            {
                MessageBox.Show("Veuillez remplir le NSS", "Chercher NSS", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
