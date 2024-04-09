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

        ToDoList presettodolist;


        public DetailToDoListPage(ToDoList todolist)
        {
            DAOToDoList = new DAO_ToDoList();
            DAOtask = new DAO_task();

            InitializeComponent();

            DAOToDoList = new DAO_ToDoList();

            if (todolist != null)
            {
                presettodolist = todolist;
            }

            var AllTaskOfToDoList = DAOtask.GetTaskByToDoList(presettodolist.Id);
            DG_Task.ItemsSource = AllTaskOfToDoList;
        }

        private void BTN_SupprTASKTODOLIST_Click(object sender, RoutedEventArgs e)  
        {
            // Récupérer le bouton qui a été cliqué
            Button button = sender as Button;
            if (button != null)
            {
                // Récupérer le contact associé à la ligne du bouton
                Tache task = button.DataContext as Tache;
                if (task != null)
                {
                    DAOtask.DeleteTask(task.Id);
                    DG_Task.ItemsSource = DAOtask.GetTaskByToDoList(presettodolist.Id);
                }
            }
        }


        
    }

    
}
