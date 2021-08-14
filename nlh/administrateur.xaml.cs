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
    /// Logique d'interaction pour administrateur.xaml
    /// </summary>
    public partial class administrateur : Window
    {
        public administrateur()
        {
            InitializeComponent();
        }

        private void btnAdmission_Click(object sender, RoutedEventArgs e)
        {
            admin_admissions nouv_adminAd = new admin_admissions();
            nouv_adminAd.ShowDialog();
        }

        private void btnAjoutSupp_Click(object sender, RoutedEventArgs e)
        {
            admin_ajoutSupp nouv_ajoutSupp = new admin_ajoutSupp();
            nouv_ajoutSupp.ShowDialog();
        }

        private void btnQuitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
