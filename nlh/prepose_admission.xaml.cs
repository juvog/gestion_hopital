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
    /// Logique d'interaction pour prepose_admission.xaml
    /// </summary>
    public partial class prepose_admission : Window
    {
        static int noAdmission;
        int compteur = 0;
        Patient p;
        int age;
        // Variable qui permet de définir à quelle type de facturation le patien a droit
        String facturation = "";
        bool tarifReduit = false;


        public prepose_admission(Patient le_patient)
        {
            InitializeComponent();

            p = le_patient;

            // Le Datacontext de cette fenêtre est l'objet Patient passé en paramètre depuis la fenêtre prepose.
            this.DataContext = p;

            // Définition des Datacontext des combobox au chargement de la fenêtre.

                //Admission. Listes de tous les départements
            var requete_dept =
                 from dept in accueil.ma_bdo.Departements
                 select dept;
                 cboDpartement.DataContext = requete_dept.ToList();

            //Admission. Listes de tous les médecins
            var requete_med =
                 from med in accueil.ma_bdo.Medecins
                 select med;
            cboMedecin.DataContext = requete_med.ToList();

                //Lit. Types de lit
            var requete_lit =
                from t in accueil.ma_bdo.TypeLits
                select t;
            cboLit.DataContext = requete_lit.ToList();


            //Calcul de l'âge du patient 
            var today = DateTime.Today;
            var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            var b = (p.dateN.Year * 100 + p.dateN.Month) * 100 + p.dateN.Day;
            age = (a - b) / 10000;

            

            //Les patients de moins de 16 ans sont automatiquement admis en pédiatrie au chargement
            if (age < 16)
            {
                cboDpartement.SelectedIndex = 3;
                //Par défaut, il n'est pas possible pour un mineur d'aller dans un autre département que pédiatrie.
                cboDpartement.IsEnabled = false;
            }

            // Définition du numéro d'admission 
            admission admission_precedente = accueil.ma_bdo.admissions.OrderByDescending(item => item.idAdmission).FirstOrDefault();
            ++compteur;
            if (admission_precedente == null)
            {
                noAdmission = compteur;
            }
            else
            {
                noAdmission = admission_precedente.idAdmission + compteur;
            }
            
            txtNoAdmission.Text = noAdmission.ToString();

            //Nb de lits 
            List<Lit> litsDisponibles = new List<Lit>();
            litsDisponibles =accueil.ma_bdo.Lits.Where(item => item.occupe == false).ToList();
            int nbLits = litsDisponibles.Count();
            if (nbLits == 0)
            {
                MessageBox.Show("Plus aucun lit n\'est disponible, veuillez chercher un autre hôpital ! ", "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
            }

       


        }

        private void cboLit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboLit.SelectedIndex ==-1)
            {
             // traitement de l'exception lors de la réinitialisation du combobox
            }
            else
            {
               //Récupération du département choisi
                Departement le_departement = cboDpartement.SelectedItem as Departement;

               //Récupération du type de chambre lit choisi :
               TypeLit le_type = cboLit.SelectedItem as TypeLit;

                // Type de facturation en fonction du type de lit choisi
                if (le_type.idType == "PRI" && facturation == "prive_standard")
                {
                    tarifReduit = true;
                }
                else if (le_type.idType == "DPRI" && facturation == "sprive_standard")
                {
                    tarifReduit = true;
                }

                
                //Lits disponibles dans le département choisi et pour le type choisi
                var requete_no_lit =
                      from l2 in accueil.ma_bdo.Lits
                      join d2 in accueil.ma_bdo.Departements on l2.idDepartement equals d2.idDepartement
                      join t2 in accueil.ma_bdo.TypeLits on l2.idType equals t2.idType
                      where (t2.idType == le_type.idType && d2.idDepartement == le_departement.idDepartement && l2.occupe == false)
                      select l2;
                    cboNoLit.DataContext = requete_no_lit.ToList();
                    cboNoLit.SelectedIndex = -1; //les choix ne sont pas visibles
            }
            

        }

   

        private void chkChirurgie_Click(object sender, RoutedEventArgs e)
        {
            // patient ayant moins de 16 ans et n'ayant pas de chirurgie ( cas où l'on décoche le checkBox chkChirurgie)
            if (age < 16 && chkChirurgie.IsChecked == false)
            {
                cboDpartement.IsEnabled = false; // pediatrie = seul choix possible
                cboDpartement.SelectedIndex = 3; // pediatrie
                
            }
            // Patient ayant moins de 16 ans et ayant une chirurgie 
            else if (age < 16 && chkChirurgie.IsChecked == true)
            {
                cboDpartement.IsEnabled = false; // chirurgie = seul choix possible
                cboDpartement.SelectedIndex = 0; // chirurgie
    
            }
           
           
            // Patient ayant plus de 16 ans et ayant une chirurgie 
            else if (age > 16 && chkChirurgie.IsChecked == true)
            {
                cboDpartement.IsEnabled = false; // chirurgie = seul choix possible
                cboDpartement.SelectedIndex = 0; // chirurgie
                
            }

            // patient ayant plus de 16 ans et n'ayant pas de chirurgie ( cas hypothétique où l'on décoche le checkBox chkChirurgie)
            else
            {
                // Choix de département à faire
                cboDpartement.SelectedIndex = -1; // les choix ne sont pas visibles
                txtNbLits.Text = "";
                cboDpartement.IsEnabled = true; // choix pas bloqués
                                               
                cboLit.DataContext = null;
                cboLit.SelectedIndex = -1; 
                cboNoLit.DataContext = null;
                cboNoLit.SelectedIndex = -1;

            }
            
        }

        private void cboDpartement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            // Attention dans le cas où selectIdex == -1
            if (cboDpartement.SelectedIndex == -1)
            {
                cboDpartement.IsEnabled = true;
            }
            else
            {
                // Récupération du département sélectionné :
                Departement le_departement = cboDpartement.SelectedItem as Departement;               

                //Nb de lits Standard
                var requete_nb_lit_stan =
                   from l in accueil.ma_bdo.Lits
                   join d in accueil.ma_bdo.Departements
                   on l.idDepartement equals d.idDepartement
                   where (d.idDepartement == le_departement.idDepartement && (l.occupe == false && l.idType =="STAN"))
                   select l;
                int nb_lit_stan = requete_nb_lit_stan.Count();

                //Nb de lits privés
                var requete_nb_lit_pri =
                   from l in accueil.ma_bdo.Lits
                   join d in accueil.ma_bdo.Departements
                   on l.idDepartement equals d.idDepartement
                   where (d.idDepartement == le_departement.idDepartement && (l.occupe == false && l.idType == "PRI"))
                   select l;
                int nb_lit_pri = requete_nb_lit_pri.Count();

                //Nb de lits semi-privés
                var requete_nb_lit_spri =
                   from l in accueil.ma_bdo.Lits
                   join d in accueil.ma_bdo.Departements
                   on l.idDepartement equals d.idDepartement
                   where (d.idDepartement == le_departement.idDepartement && (l.occupe == false && l.idType == "DPRI"))
                   select l;
                int nb_lit_spri = requete_nb_lit_spri.Count();

                // Nb de lits disponibles 
                int nb_lit = nb_lit_pri + nb_lit_spri + nb_lit_stan;


                //Type de lits disponibles dans le département sélectionné :
                var requete_type_lit =
                   from t1 in accueil.ma_bdo.TypeLits
                   join l1 in accueil.ma_bdo.Lits on t1.idType equals l1.idType
                   join d1 in accueil.ma_bdo.Departements on l1.idDepartement equals d1.idDepartement
                   where (d1.nomDepartement == le_departement.nomDepartement && l1.occupe == false)
                   select t1;
                List<TypeLit> type_lits = new List<TypeLit>();
                type_lits = requete_type_lit.ToList();

                // Définition du datacontext du combobox cboLit affichant les types différents de lits disponibles
                cboLit.IsEnabled = true;   
                cboLit.DataContext = type_lits;
                cboLit.SelectedIndex = -1; // les choix ne sont pas visibles

                // Si les valeurs possibles de CboLit changent alors le datacontext de cboNoLit n'est plus le même. Il faut le réinitialiser à null :
                cboNoLit.IsEnabled = true;
                cboNoLit.DataContext = null;
                cboNoLit.SelectedIndex = -1;


                //  Message concenant le nombre et le type de lits disponibles  

                // Patient avec assurance privée
                if(p.idAssurance != null)
                {
                    if (nb_lit == 0)
                    {
                        txtNbLits.Text = "Plus de lits disponibles.\nChoisissez un autre département SVP.";
                        cboDpartement.IsEnabled = true; // possibilité de modifier le département si attribué par défaut
                        cboLit.IsEnabled = false;
                        cboNoLit.IsEnabled = false;
                    }
                    else
                    {
                        txtNbLits.Text = "Il y a " + nb_lit + " lit(s) disponible(s).";
                    }
                }

                // Patient sans assurance privée
               
                else
                {
                    if (nb_lit_stan == 0)
                    {
                        if(nb_lit_spri == 0)
                        {
                            if (nb_lit_pri ==0)
                            {
                                txtNbLits.Text = "Plus de lits disponibles.\nChoisissez un autre département SVP.";
                                cboDpartement.IsEnabled = true; // possibilité de modifier le département si attribué par défaut
                                cboLit.IsEnabled = false;
                                cboNoLit.IsEnabled = false;
                            }
                            else
                            {
                                txtNbLits.Text = "Patient sans assurance." +
                                                  "\nChambres privées sans frais supplémentaires ";
                                facturation = "prive_standard";
                            }                             
                        }
                        else
                        {
                            txtNbLits.Text = "Patient sans assurance." +
                                                "\nSeules les chambres semi-privées sont sans frais supplémentaires ";
                            facturation = "sprive_standard";

                        }
                    }
                    else
                    {
                        txtNbLits.Text = "Patient sans assurance." +
                                               "\nSeules les chambres standards sont sans frais supplémentaires";
                      
                    }
                }


            }


        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            admission nouvelle_admission = new admission();

            if (!String.IsNullOrEmpty(dateAdmission.SelectedDate.ToString())&&
             !String.IsNullOrEmpty(cboDpartement.Text) && !String.IsNullOrEmpty(cboLit.Text) && !String.IsNullOrEmpty(cboNoLit.Text) 
             && ((chkChirurgie.IsChecked == true && dateChirurgie.SelectedDate != null)|| (chkChirurgie.IsChecked ==false)))
            {
                                   
                // Cas de la chirurgie programmée
                if (chkChirurgie.IsChecked == true)
                {
                    nouvelle_admission.chirurgieProg = true;
                    nouvelle_admission.dateChirurgie = dateChirurgie.SelectedDate.Value.Date ;
                }
                else
                {
                    nouvelle_admission.chirurgieProg = false;
                }

                
                nouvelle_admission.idAdmission = int.Parse(txtNoAdmission.Text);
                nouvelle_admission.dateAdmission = dateAdmission.SelectedDate.Value.Date;
                nouvelle_admission.dateConge = null; // congé donné par le médecin seulement
                nouvelle_admission.nss = int.Parse(txtNSS.Text);
                nouvelle_admission.noLit = int.Parse(cboNoLit.Text);

                // Location d'un téléviseur
                if (chkTeleviseur.IsChecked == true)
                {
                    nouvelle_admission.televiseur = true;
                }
                else
                {
                    nouvelle_admission.televiseur = false;
                }


                //Location d'un téléphone 
                if (chkTelephone.IsChecked == true)
                {
                    nouvelle_admission.telephone = true;
                }
                else
                {
                    nouvelle_admission.telephone = false;
                }

                // Tarif réduit
                if (tarifReduit == true)
                {
                    nouvelle_admission.prixReduit = true;
                }
                else
                {
                    nouvelle_admission.prixReduit = false;
                }

                // Création de l'objet admission
                accueil.ma_bdo.admissions.Add(nouvelle_admission);

                // Le lit choisi est maintenant occupé 
                Lit le_lit = accueil.ma_bdo.Lits.Where(l => l.noLit == nouvelle_admission.noLit).FirstOrDefault();
                le_lit.occupe = true;


                try
                {
                    accueil.ma_bdo.SaveChanges();
                    MessageBox.Show("Admission ajoutée avec succes!", "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
                    prepose prepose = new prepose();
                    this.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Vous devez saisir tous les champs obligatoires", "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
            }

           

        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            prepose prep = new prepose();
            
            prep.DataContext = p;
            prep.ShowDialog();
        }
    }

 
}
