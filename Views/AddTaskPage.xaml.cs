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
using static System.Net.Mime.MediaTypeNames;

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
            RemplirCBNameList();

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

        private void RemplirCBNameList()
        {
            try
            {
                // Récupérer toutes les ToDoList depuis la base de données
                IEnumerable<ToDoList> allToDoLists = DAOToDoList.GetAllToDoList();

                // Vider le ComboBox avant de le remplir
                CB_ChoiceList.Items.Clear();

                // Parcourir toutes les ToDoList et ajouter leur nom dans le ComboBox
                foreach (ToDoList toDoList in allToDoLists)
                {
                    CB_ChoiceList.Items.Add(toDoList.Titre);
                }
            }
            catch (Exception ex)
            {
                // Gérer toute exception survenue lors du chargement des données
                MessageBox.Show("Erreur lors du chargement des données : " + ex.Message);
            }
        }


        //private void BTN_ADD_TASK_Click(object sender, RoutedEventArgs e)
        //{
        //    Tache tache = new Tache();

        //    tache.Name = TB_Titre.Text;
        //    tache.Etat = CB_State.Text;
        //    tache.ToDoList = CB_ChoiceList.Text;

        //     DAOTask.CreateTask(tache);


        //}

        private void BTN_ADD_TASK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Tache tache = new Tache();

                tache.Name = TB_Titre.Text;
                tache.Etat = CB_State.Text;

                string selectedListName = CB_ChoiceList.Text;

                // Récupérer toutes les ToDoLists depuis la base de données
                IEnumerable<ToDoList> allToDoLists = DAOToDoList.GetAllToDoList();

                // Parcourir toutes les ToDoLists pour trouver celle correspondant au nom sélectionné
                foreach (ToDoList list in allToDoLists)
                {
                    if (list.Titre == selectedListName)
                    {
                        // Créer la tâche et l'associer à la liste correspondante
                        string result = DAOTask.CreateTaskAndAssignToList(tache, list.Id);
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
