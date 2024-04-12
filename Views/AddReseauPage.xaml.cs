using Amiar_Agenda.AgendaDB;
using Amiar_Agenda.Service.DAO;
using System.IO;

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
    /// Logique d'interaction pour AddReseauPage.xaml
    /// </summary>
    public partial class AddReseauPage : UserControl
    {
        public DAO_Reseau DAOreseau;
        public DAO_contact DAOcontact;

        public AddReseauPage()
        {
            InitializeComponent();
            DAOcontact = new DAO_contact();
            DAOreseau = new DAO_Reseau();
            RemplirCBReseau();
            RemplirCBNameContact(); 
        }

        private void RemplirCBReseau()
        {
            string CheminListeReseau = "Ressource/Liste/ListReseau.txt";
            string[] ListReseau = File.ReadAllLines(CheminListeReseau);

            foreach (string Reseau in ListReseau)
            {
                CB_ChoiceReseau.Items.Add(Reseau);
            }
        }

        private void RemplirCBNameContact()
        {
            try
            {
                // Récupérer tous les contacts depuis la base de données
                IEnumerable<Contact> allContacts = DAOcontact.GetAllContacts();

                // Vider le ComboBox avant de le remplir
                CB_ChoiceContact.Items.Clear();

                // Parcourir tous les contacts et ajouter leur nom dans le ComboBox
                foreach (Contact contact in allContacts)
                {
                    CB_ChoiceContact.Items.Add(contact.Nom);
                }
            }
            catch (Exception ex)
            {
                // Gérer toute exception survenue lors du chargement des données
                MessageBox.Show("Erreur lors du chargement des données : " + ex.Message);
            }
        }



        private void BTN_ADD_TASK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SocialMedium socialmedia = new SocialMedium();

                socialmedia.Url = TB_Link.Text;
                socialmedia.UserName = TB_Username.Text;
                socialmedia.Name = CB_ChoiceReseau.Text;

                string selectedContactName = CB_ChoiceContact.Text;

                // Récupérer toutes les ToDoLists depuis la base de données
                IEnumerable<Contact> allContacts = DAOcontact.GetAllContacts();

                // Parcourir toutes les ToDoLists pour trouver celle correspondant au nom sélectionné
                foreach (Contact contact in allContacts)
                {
                    if (contact.Nom == selectedContactName)
                    {
                        // Créer la tâche et l'associer à la liste correspondante
                        string result = DAOreseau.CreateReseauAsignContact(socialmedia, contact.Id);
                        MessageBox.Show(result);
                        return;
                    }
                }

                // Si la liste sélectionnée n'est pas trouvée
                MessageBox.Show("La liste sélectionnée n'existe pas.");
            }
            catch (Exception ex)
            {
                // Gérer toute exception survenue lors de l'ajout de la tâche
                MessageBox.Show("Erreur lors de l'ajout de la tâche : " + ex.Message);
            }
            
        }
    }
}
