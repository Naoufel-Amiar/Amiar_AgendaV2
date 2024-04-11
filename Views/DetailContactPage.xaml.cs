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

            var AllReseauOfcontact = DAOreseau.GetReseaukByContact(presetcontact.Id);
            DG_Reseau.ItemsSource = AllReseauOfcontact;

        }

        private void BTN_SupprTASKTODOLIST_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
