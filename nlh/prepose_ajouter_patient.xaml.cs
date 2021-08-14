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
    /// Logique d'interaction pour prepose_ajouter_patient.xaml
    /// </summary>
    public partial class prepose_ajouter_patient : Window
    {
        public prepose_ajouter_patient()
        {
            InitializeComponent();
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {

            // Création et enregistrement de l'objet patient dans la base de données
            Patient nouveau_patient = new Patient();
            nouveau_patient.nss = int.Parse(txtNumeroSS.Text);
            nouveau_patient.dateN = dateNaissance.SelectedDate.Value;
            nouveau_patient.nom = txtNom.Text;
            nouveau_patient.prenom = txtPrenom.Text;
            nouveau_patient.adresse = txtAdresse.Text;
            nouveau_patient.ville = txtAdresse.Text;
            nouveau_patient.codeP = txtCodeP.Text;
            nouveau_patient.telephone = txtTelephone.Text;
            nouveau_patient.nssParent = int.Parse(txtNSSparent.Text);
            if (cboAssurance.SelectedIndex == -1)
            {
                nouveau_patient.idAssurance = null;
            }
            else
            {
                nouveau_patient.idAssurance = (cboAssurance.SelectedItem as Assurance).idassurance;
            }
           

            accueil.ma_bdo.Patients.Add(nouveau_patient);

            try
            {
                accueil.ma_bdo.SaveChanges();
                MessageBox.Show("Patient ajoutée avec succes!", "Attention", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


            // Fermeture de la fenêtre et ouverture d'une fenêtre prepose avec les infos du nouvel enregistrement.
            this.Close();

            prepose prep = new prepose();

            int le_numero = nouveau_patient.nss;
            var requete =
            from p in accueil.ma_bdo.Patients
            where p.nss == le_numero
            select p;
            
            prep.DataContext = requete.ToList();
            prep.ShowDialog();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboAssurance.DataContext = accueil.ma_bdo.Assurances.ToList();
        }
    }
}
