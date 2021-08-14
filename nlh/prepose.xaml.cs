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
    /// Logique d'interaction pour prepose.xaml
    /// </summary>
    /// 

    public partial class prepose : Window
    {

        admission derniere_admission = new admission();
        Patient le_patient;
        public prepose()
        {
            InitializeComponent();
            btnAdmission.IsEnabled = false;
          
        }

        private void btnRechercher_Click(object sender, RoutedEventArgs e)
        {
            

                // Défintion du Datacontext de la fenêtre = objet patient correspondant au NSS
                int le_numero = int.Parse(txtNSS.Text);
                var requete =
                from p in accueil.ma_bdo.Patients
                where p.nss == le_numero
                select p;
                this.DataContext = requete.ToList();
                le_patient = requete.FirstOrDefault();
               

                if(le_patient == null)
                {
                    MessageBox.Show("Aucun patient enregistré ne correspond à ce NSS", "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
                chkDerniereAdmission.IsChecked = false;
                txtMontantDu.Text = "";
                btnAdmission.IsEnabled = false;

                }
                else
                {
                List<admission> les_admissions = new List<admission>();
                les_admissions = accueil.ma_bdo.admissions.Where(a => a.nss == le_patient.nss).ToList();
                derniere_admission = les_admissions.OrderByDescending(item => item.dateAdmission).FirstOrDefault();

                // Si le patient n' a jamais eu d'admission
                if (derniere_admission == null)
                {
                    btnAdmission.IsEnabled = true;
                }
                else
                {
                    // si le patient a eu reçu le congé de la part de son médecin
                    btnAdmission.IsEnabled = true; // il peut être de nouveau admis
                    if (derniere_admission.dateConge != null)
                    {
                        chkDerniereAdmission.IsChecked = true;
                        // Cacul du montant dû 

                        double montant = 0;

                        TimeSpan difference = (derniere_admission.dateAdmission.Value - derniere_admission.dateConge.Value);
                        double nbJours = (double)difference.TotalDays;

                        //calcul du montant en fonction du type de lit
                        var requete_lit =
                            from l in accueil.ma_bdo.Lits
                            join a in accueil.ma_bdo.admissions on l.noLit equals a.noLit
                            where (l.noLit == derniere_admission.noLit)
                            select l;
                        Lit le_lit = new Lit();
                        le_lit = requete_lit.FirstOrDefault();
                        if (le_lit.idType == "STAN")
                        {
                            montant = 0; // si l'on considère que chambre standard est remboursée intégralement par la carte Soleil
                        }

                        else if (le_lit.idType == "PRI")
                        {
                            if (derniere_admission.prixReduit == true)
                            {
                                montant = 0;
                            }
                            else
                            {
                                montant = 571 * nbJours;
                            }
                        }

                        else if (le_lit.idType == "DPRI")
                        {
                            if (derniere_admission.prixReduit == true)
                            {
                                montant = 0;
                            }
                            else
                            {
                                montant = 267 * nbJours;
                            }

                        }

                        // Location d'un téléphone et d'un téléviseur
                        if (derniere_admission.telephone == true)
                        {
                            if (derniere_admission.televiseur == true)
                            {
                                montant += nbJours * (42.5 + 7.5);
                            }
                            else
                            {
                                montant += nbJours * 7.5;
                            }
                        }
                        else
                        {
                            montant += nbJours * 42.5;
                        }

                        txtMontantDu.Text = montant.ToString() + " $.";



                    }

                    // Si le patient n'a pas encore reçu le congé
                    else
                    {
                        btnAdmission.IsEnabled = true; // il ne peut pas être de nouveau admis
                        chkDerniereAdmission.IsChecked = false;
                        txtMontantDu.Text = "";
                    }


                }
            }

                
                
                

            
          
           
           
        }

        private void btnAjouterPatient_Click(object sender, RoutedEventArgs e)
        {
            prepose_ajouter_patient nouvFenetre_patient = new prepose_ajouter_patient();
            this.Close();
            nouvFenetre_patient.ShowDialog();
        }

        private void btnAdmission_Click(object sender, RoutedEventArgs e)
        {
            // On peut faire une admission que si il n'y a jamais eu d'admission ou si le patient a reçu congé de sa dernière admission
           
            if (derniere_admission == null || derniere_admission.dateConge != null)
            {
               
                prepose_admission nouvfenetre_admission = new prepose_admission(le_patient);
                nouvfenetre_admission.ShowDialog();
                btnAdmission.IsEnabled = false;
                
            }
            else
            {
                if (derniere_admission.dateConge == null)
                {
                    MessageBox.Show("Une admission est déjà en cours ! ", "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                
            }
           
            
        }

        private void btnQuitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
      
}
