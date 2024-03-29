using Amiar_Agenda.AgendaDB;
using System.IO;
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
    /// Logique d'interaction pour EditContactPage.xaml
    /// </summary>
    public partial class EditContactPage : UserControl
    {
        public DAO_contact DAOcontact;
        Contact presetcontact;

        public EditContactPage(Contact contact)
        {
            InitializeComponent();
            RemplirCBSex();
            RemplirCBStatus();

            DAOcontact = new DAO_contact();

            // Initialisation de votre page avec les informations du contact
            if (contact != null)
            {
                presetcontact = contact;
                // Utilisez les informations du contact pour remplir les champs correspondants
                TB_Nom.Text = contact.Nom;
                TB_Prenom.Text = contact.Prenom;
                TB_Adresse.Text = contact.Adress;
                TB_Phone.Text = contact.Tel;

                TB_Sex_Actuel.Text = contact.Sex;
                TB_Status_Actuel.Text = contact.Status;

                Pick_Birth.Text = contact.Birth.ToString();
            }
        }

        private void RemplirCBSex()
        {
            string PathFileSex = "C:Ressource/Liste/ListSex.txt";
            string[] ListSex = File.ReadAllLines(PathFileSex);

            foreach (string Sex in ListSex)
            {
                CB_Sex.Items.Add(Sex);
            }
        }

        private void RemplirCBStatus()
        {
            string PathFileStatus = "Ressource/Liste/ListeStatus.txt";
            string[] ListStatus = File.ReadAllLines(PathFileStatus);

            foreach (string status in ListStatus)
            {
                CB_Status.Items.Add(status);
            }
        }

        private void BP_EDIT_Contact_Click(object sender, RoutedEventArgs e)
        {
            presetcontact.Prenom = TB_Prenom.Text;
            presetcontact.Nom = TB_Nom.Text;
            presetcontact.Adress = TB_Adresse.Text;
            presetcontact.Tel = TB_Phone.Text;
            presetcontact.Sex = CB_Sex.Text;
            presetcontact.Status = CB_Status.Text;

            if (Pick_Birth.SelectedDate.HasValue)
            {
                DateTime selectedDateTime = Pick_Birth.SelectedDate.Value.Date;
                DateOnly selectedDate = new DateOnly(selectedDateTime.Year, selectedDateTime.Month, selectedDateTime.Day);

                presetcontact.Birth = selectedDate;

            }

            DAOcontact.ModifyContact(presetcontact);
        }
    }
}
