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
    /// Logique d'interaction pour admin_ajoutSupp.xaml
    /// </summary>
    public partial class admin_ajoutSupp : Window
    {

        public admin_ajoutSupp()
        {
            InitializeComponent();
        }

        private void btnRechercher_Click(object sender, RoutedEventArgs e)
        {
            String nomMedecin = txtNom.Text.Trim().ToLower();
            String prenomMedecin = txtPrenom.Text.Trim().ToLower();

            var medecins_recherche =
             from m in accueil.ma_bdo.Medecins
             // En cas d'erreur sur le nom ou prénom le || permet de retourner tous les médecins ayant le même prénom ou même nom
             where ((m.nomMedecin.Trim().ToLower() == nomMedecin) || (m.prenomMedecin.Trim().ToLower() == prenomMedecin))
             select m;
            List<Medecin> la_liste = new List<Medecin>();
            la_liste = medecins_recherche.ToList();

            int nb_medecin = la_liste.Count();

            if (nb_medecin == 0)
            {
                txtAide.Text = "Aucun médecin ne correspond à la recherche";
                txtNom.Focus();
                txtNom.SelectAll();
            }
            else
            {
                dtgMedecins.DataContext = la_liste;
                txtAide.Text = "Il y a " + nb_medecin + " médecin(s) qui correspond(ent) à la recherche";
            }

        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            Medecin le_medecin = dtgMedecins.SelectedItem as Medecin;

            // Cas où l'administrateur n'a pas sélectionné de médecin
            if (le_medecin == null)
            {
                MessageBox.Show("Aucun médecin n'est sélectionné", "Supprimer un médecin", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            /* Si l'on veut supprimer un médecin il faut le retirer des admissions où il figure.
             Sinon ce ne sera pas possible en raison de la clé étrangère entre admissions et médecins (contrainte d'intégrité violée).
            Il faut donc rechercher les admissions où figure le_medecin et définir le médecin à null */
            else
            {
                var requete_admissions_du_medecin =
                    from a in accueil.ma_bdo.admissions
                    join m in accueil.ma_bdo.Medecins
                    on a.idMedecin equals m.idMedecin
                    where (m.idMedecin == le_medecin.idMedecin)
                    select a;
                List<admission> la_liste = new List<admission>();

                la_liste = requete_admissions_du_medecin.ToList();

                // Cas où le médecin a des admissions
                if (la_liste.Count() != 0)
                {
                    foreach (admission a in la_liste)
                    {
                        a.idMedecin = null;

                    }
                }

                // On peut maintenant supprimer le médecin 
                accueil.ma_bdo.Medecins.Remove(le_medecin);

                try
                {
                    accueil.ma_bdo.SaveChanges();
                    MessageBox.Show("Médecin supprimé avec succès", "Supprimer un médecin", MessageBoxButton.OK, MessageBoxImage.Information);
                    dtgMedecins.DataContext = null;
                    txtAide.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

           
            

        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            int compteur = 0;
            int compt = 0;
            String nomMedecin = txtNom.Text.Trim().ToLower();
            String prenomMedecin = txtPrenom.Text.Trim().ToLower();

            // Il faut remplir les deux champs
            if(!String.IsNullOrEmpty(nomMedecin) && !String.IsNullOrEmpty(prenomMedecin))
            {
                // On vérifie si le médecin existe déjà
                foreach (Medecin m in accueil.ma_bdo.Medecins)
                {
                    if ((m.nomMedecin.Trim().ToLower() == nomMedecin) && (m.prenomMedecin.Trim().ToLower() == txtPrenom.Text))
                    {
                        compteur = 1;
                    }
                }
                if (compteur > 0)
                {
                    txtAide.Text = "Le médecin est déjà enregistré";
                }
                else
                {
                    Medecin nouveau_medecin = new Medecin();
                    nouveau_medecin.nomMedecin = nomMedecin;
                    nouveau_medecin.prenomMedecin = prenomMedecin;

                    // Définition du numéro identifiant
                    Medecin medecin_precedent = accueil.ma_bdo.Medecins.OrderByDescending(item => item.idMedecin).FirstOrDefault();
                    ++compt;
                    if (medecin_precedent == null)
                    {
                        nouveau_medecin.idMedecin = compt.ToString();
                    }
                    else
                    {
                        nouveau_medecin.idMedecin = medecin_precedent.idMedecin + compt.ToString();
                    }

                    // Ajout du nouvel objet dans la bdo entity Framework
                    accueil.ma_bdo.Medecins.Add(nouveau_medecin);

                    // Sauvegarde de la bdd
                    try
                    {
                        accueil.ma_bdo.SaveChanges();
                        MessageBox.Show("Médecin ajouté avec succès", "Ajouter un médecin", MessageBoxButton.OK, MessageBoxImage.Information);
                        dtgMedecins.DataContext = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            else
            {
                MessageBox.Show("Vous devez remplir tous les champs", "Ajouter un médecin", MessageBoxButton.OK, MessageBoxImage.Information);
            }
             
            
        }

        private void btnQuitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
