using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Amiar_Agenda.AgendaDB;
using Microsoft.EntityFrameworkCore;

namespace Amiar_Agenda.Service.DAO
{
    public class DAO_task
    {
        AgendaContext Context;

        public DAO_task() 
        { 

        }

        //importer task de to do list
        public IEnumerable<Tache> GetTaskByToDoList(int ID)
        {
            using (var db = new AgendaContext())
            {
                return db.Taches.Where(t => t.ToDoListId == ID).ToList();
            }
        }

        //supprimer task
        public void DeleteTask(int taskId)
        {
            using (var db = new AgendaContext())
            {
                var taskToDelete = db.Taches.FirstOrDefault(t => t.Id == taskId);
                if (taskToDelete != null)
                {
                    db.Taches.Remove(taskToDelete);
                    db.SaveChanges();
                }
            }
        }

        // Méthode pour créer une tâche pour une to do list
        public void CreateTask(Tache task)
        {
            using (var db = new AgendaContext())
            {
                db.Taches.Add(task);
                db.SaveChanges(); //ERREUR SUR LE CREATE
            }
        }

    }
}
