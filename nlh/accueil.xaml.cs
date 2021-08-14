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
    /// Logique d'interaction pour accueil.xaml
    /// </summary>
    public partial class accueil : Window
    {
        public static nlhEntities ma_bdo;
        public accueil()
        {
            InitializeComponent();
            ma_bdo = new nlhEntities();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUtilisateur.Text) && !String.IsNullOrEmpty(txtUtilisateur.Text))
            {
                if ((txtUtilisateur.Text == "prep") && (txtMdp.Password == "prep"))
                {
                    prepose fenetre_prepose = new prepose();
                    fenetre_prepose.ShowDialog();
                }
                else if ((txtUtilisateur.Text == "admin") && (txtMdp.Password == "admin"))
                {
                    administrateur fenetre_admin = new administrateur();
                    fenetre_admin.ShowDialog();
                }
                else if ((txtUtilisateur.Text == "med") && (txtMdp.Password == "med"))
                {
                    medecin fenetre_medecin = new medecin();
                    fenetre_medecin.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Les informations saisies sont incorrectes", "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
                 }
            }

            else
            {
                MessageBox.Show("Vous devez rentrer un nom d'utilisateur et un mot de passe", "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void btnQuitter_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult reponse = MessageBox.Show("Désirez-vous réellement quitter cette application ? ",
               "Attention", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (reponse == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
