using Amiar_Agenda.AgendaDB;
using Amiar_Agenda.Service;
using Amiar_Agenda.Service.DAO;

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Amiar_Agenda.Views
{
    /// <summary>
    /// Logique d'interaction pour DetailContactPage.xaml
    /// </summary>
    public partial class DetailContactPage : UserControl
    {

        public DAO_Reseau DAOreseau;
        public DAO_contact DAOcontact;

        Contact presetcontact;


        public DetailContactPage(Contact contact)
        {
            InitializeComponent();
            AgendaContext context = new AgendaContext();
            DAOreseau = new DAO_Reseau();
            DAOcontact = new DAO_contact();

            if (contact != null)
            {
                presetcontact = contact;
            }

            var AllReseauOfcontact = DAOreseau.GetReseauByContact(presetcontact.Id);
            DG_Reseau.ItemsSource = AllReseauOfcontact;

        }

        private void BTN_SupprRESEAUCONTACT_Click(object sender, RoutedEventArgs e)
        {
            
            // Récupérer le bouton qui a été cliqué
            Button button = sender as Button;
            if (button != null)
            {
            // Récupérer le contact associé à la ligne du bouton
            SocialMedium socialmedium  = button.DataContext as SocialMedium;
                if (socialmedium != null)
                {
                    DAOreseau.DeleteReseau(socialmedium.Id);
                    DG_Reseau.ItemsSource = DAOreseau.GetReseauByContact(socialmedium.Id);
                }
            }  
        }

        private void BTN_EditRESEAUCONTACT_Click(object sender, RoutedEventArgs e)
        {

        }

        public void ChargerReseaux()
        {
            var allReseaux = DAOreseau.GetReseauByContact(presetcontact.Id);
            DG_Reseau.ItemsSource = allReseaux;
        }


    }
}
