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
    /// Logique d'interaction pour AddTaskPage.xaml
    /// </summary>
    public partial class AddTaskPage : UserControl
    {
        public DAO_task DAOTask;
        public DAO_ToDoList DAOToDoList;
        public AddTaskPage()
        {
            InitializeComponent();
            DAOTask = new DAO_task();
            DAOToDoList = new DAO_ToDoList();

            RemplirCBState();

        }

        private void RemplirCBState()
        {
            string CheminListeState = "Ressource/Liste/ListeState.txt";
            string[] ListState = File.ReadAllLines(CheminListeState);

            foreach (string State in ListState)
            {
                CB_State.Items.Add(State);
            }
        }

        //private void RemplirCBNameList()
        //{
        //    string[] ListState = (DAOToDoList.GetAllToDoList()).ToString();  //CA MARCHE PAS

        //    foreach (string State in ListState)
        //    {
        //        CB_State.Items.Add(State);
        //    }
        //}


        private void BTN_ADD_TASK_Click(object sender, RoutedEventArgs e)
        {
            Tache tache = new Tache();

            tache.Name = TB_Titre.Text;
            tache.Etat = CB_State.Text;
            //tache.ToDoList = CB_ChoiceList.Text;

             DAOTask.CreateTask(tache);

           
        }

    }
}
