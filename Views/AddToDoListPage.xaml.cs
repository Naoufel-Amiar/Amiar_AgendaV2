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
    /// Logique d'interaction pour AddToDoListPage.xaml
    /// </summary>
    public partial class AddToDoListPage : UserControl
    {
        public DAO_ToDoList DAOtodolist;

        public AddToDoListPage()
        {
            InitializeComponent();
            DAOtodolist = new DAO_ToDoList();
        }

        private void BP_ADD_TODOLIST_Click(object sender, RoutedEventArgs e)
        {
            ToDoList todolist = new ToDoList();

            todolist.Titre = TB_Titre.Text;
            todolist.Description = TB_Desc.Text;


            if (Pick_Start_Date.SelectedDate.HasValue)
            {
                DateTime selectedDateTime = Pick_Start_Date.SelectedDate.Value.Date;
                DateOnly selectedDate = new DateOnly(selectedDateTime.Year, selectedDateTime.Month, selectedDateTime.Day);
                todolist.Date = selectedDate;
            }

            if (Pick_End_Date.SelectedDate.HasValue)
            {
                DateTime selectedDateTime = Pick_End_Date.SelectedDate.Value.Date;
                DateOnly selectedDate = new DateOnly(selectedDateTime.Year, selectedDateTime.Month, selectedDateTime.Day);
                todolist.EndDate = selectedDate;
            }
            DAOtodolist.AddToDoList(todolist);
        }
    }
}
