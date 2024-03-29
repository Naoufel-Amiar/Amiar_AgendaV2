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
    /// Logique d'interaction pour AddContact.xaml
    /// </summary>
    public partial class AddContactPage : UserControl
    {
        public DAO_contact DAOcontact;
        public AddContactPage()
        {
            InitializeComponent();

            RemplirCBSex();
            RemplirCBStatus();

            DAOcontact = new DAO_contact();

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

        private void BP_ADD_Contact_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact();

            contact.Prenom = TB_Prenom.Text;
            contact.Nom = TB_Nom.Text;
            contact.Adress = TB_Adresse.Text;
            contact.Tel = TB_Phone.Text;
            contact.Sex = CB_Sex.Text;
            contact.Status = CB_Status.Text;

            if (Pick_Birth.SelectedDate.HasValue)
            {
                DateTime selectedDateTime = Pick_Birth.SelectedDate.Value.Date;
                DateOnly selectedDate = new DateOnly(selectedDateTime.Year, selectedDateTime.Month, selectedDateTime.Day);

                contact.Birth = selectedDate;

            }

            DAOcontact.AddContact(contact);
        }
    }
    
}
