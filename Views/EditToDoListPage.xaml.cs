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
    /// Logique d'interaction pour EditToDoListPage.xaml
    /// </summary>
    public partial class EditToDoListPage : UserControl
    {
        public DAO_ToDoList DAOToDoList;
        ToDoList presettodolist;

        public EditToDoListPage(ToDoList todolist)
        {
            InitializeComponent();

            DAOToDoList = new DAO_ToDoList();

            // Initialisation de votre page avec les informations du contact
            if (todolist != null)
            {
                presettodolist = todolist;

                TB_Titre.Text = todolist.Titre;
                TB_Titre.Text = todolist.Description;

                Pick_Start_Date.Text = todolist.Date.ToString();
                Pick_End_Date.Text = todolist.EndDate.ToString();
            }
        }

        private void BP_EDIT_Contact_Click(object sender, RoutedEventArgs e)
        {
            presettodolist.Titre = TB_Titre.Text;
            presettodolist.Description = TB_Desc.Text;

            if (Pick_Start_Date.SelectedDate.HasValue)
            {
                DateTime selectedDateTime = Pick_Start_Date.SelectedDate.Value.Date;
                DateOnly selectedDate = new DateOnly(selectedDateTime.Year, selectedDateTime.Month, selectedDateTime.Day);

                presettodolist.Date = selectedDate;
            }
            DAOToDoList.ModifyToDoList(presettodolist);
        }
    }
}
