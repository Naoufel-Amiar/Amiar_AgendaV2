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
    /// Logique d'interaction pour DetailToDoListPage.xaml
    /// </summary>
    public partial class DetailToDoListPage : UserControl
    {
        public DAO_task DAOtask;
        public DAO_ToDoList DAOToDoList;

        //ToDoList presettodolist;

        public DetailToDoListPage()
        {
            DAOToDoList = new DAO_ToDoList();
            DAOtask = new DAO_task();

            ToDoList todolist = new ToDoList();

            InitializeComponent();
            var AllTaskOfToDoList = DAOtask.GetTaskByToDoList(todolist.Id);

            DG_Task.ItemsSource = AllTaskOfToDoList;
        }

        private void BTN_ModifTODOLIST_Click(object sender, RoutedEventArgs e)  
        {

        }

        private void BTN_SupprTODOLIST_Click(object sender, RoutedEventArgs e)  
        {

        }

        private void BTN_DetailTODOLIST_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BP_Add_Task_FromViewTask_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
