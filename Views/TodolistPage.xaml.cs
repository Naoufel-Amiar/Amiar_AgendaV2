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
    /// Logique d'interaction pour TodolistPage.xaml
    /// </summary>
    public partial class TodolistPage : UserControl
    {
        public DAO_ToDoList DAOToDoList;

        public TodolistPage()
        {
            InitializeComponent();

            DAOToDoList = new DAO_ToDoList();

            var allTODOLIST = DAOToDoList.GetAllToDoList();

            DG_Contact.ItemsSource = allTODOLIST;
        }


        private void BP_Add_TODOLIST_FromViewContact_Click(object sender, RoutedEventArgs e)
        {
            GRD_ToDoListContainer.Children.Clear();
            AddToDoListPage addtofolistpage = new AddToDoListPage();
            GRD_ToDoListContainer.Children.Add(addtofolistpage);
        }

        private void BTN_ModifTODOLIST_Click(object sender, RoutedEventArgs e)
        {

            var btn = sender as Button;
            var dc = btn.DataContext;
            ToDoList todolist = dc as ToDoList;

            //  Contact contact = DG_Contact.SelectedItem as Contact;
            if (todolist != null)
            {
                // Passer les informations à la vue EditContactPage
                EditToDoListPage editContactPage = new EditToDoListPage(todolist);
                // Afficher la vue EditContactPage
                GRD_ToDoListContainer.Children.Add(editContactPage);
            }
        }

        private void BTN_SupprTODOLIST_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer le bouton qui a été cliqué
            Button button = sender as Button;
            if (button != null)
            {
                // Récupérer le contact associé à la ligne du bouton
                ToDoList todolist= button.DataContext as ToDoList;
                if (todolist != null)
                {
                    // Supprimer le contact de la base de données
                    DAOToDoList.SupprToDoList(todolist);

                    // Mettre à jour l'affichage dans le DataGrid en récupérant les contacts mis à jour
                    DG_Contact.ItemsSource = DAOToDoList.GetAllToDoList();
                }
            }
        }

        private void BTN_DetailTODOLIST_Click(object sender, RoutedEventArgs e)
        {
            GRD_Container_All.Children.Clear(); 
            DetailToDoListPage detailtodolistpage = new DetailToDoListPage();
            GRD_Container_All.Children.Add(detailtodolistpage); 
        }
    }
}