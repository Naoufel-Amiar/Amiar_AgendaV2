using Amiar_Agenda.AgendaDB;
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
    /// Logique d'interaction pour SeeContacts.xaml
    /// </summary>

    public partial class ContactPage : UserControl
    {
        public DAO_contact DAOcontact;

        public ContactPage()
        {
            InitializeComponent();

            DAOcontact = new DAO_contact();

            // Récupérer tous les contacts
            var allContacts = DAOcontact.GetAllContacts();

            DG_Contact.ItemsSource = allContacts;
         
        }



        private void BTN_SupprContact_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer le bouton qui a été cliqué
            Button button = sender as Button;
            if (button != null)
            {
                // Récupérer le contact associé à la ligne du bouton
                Contact contact = button.DataContext as Contact;
                if (contact != null)
                {
                    // Supprimer le contact de la base de données
                    DAOcontact.SupprContact(contact);

                    // Mettre à jour l'affichage dans le DataGrid en récupérant les contacts mis à jour
                    DG_Contact.ItemsSource = DAOcontact.GetAllContacts();
                }
            }

        }



        private void BP_Add_Contact_FromViewContact_Click(object sender, RoutedEventArgs e)
        {
            GRD_ContactContainer.Children.Clear();
            AddContactPage addContactPage = new AddContactPage();
            GRD_ContactContainer.Children.Add(addContactPage);
        }

        private void BTN_ModifContact_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var dc = btn.DataContext;
            Contact contact = dc as Contact;
          //  Contact contact = DG_Contact.SelectedItem as Contact;

            if (contact != null)
            {
                // Passer les informations à la vue EditContactPage
                EditContactPage editContactPage = new EditContactPage(contact);
                // Afficher la vue EditContactPage
                GRD_ContactContainer.Children.Add(editContactPage);
            }

        }
    }
}
