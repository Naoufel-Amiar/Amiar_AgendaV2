using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Amiar_Agenda.AgendaDB;
using Microsoft.EntityFrameworkCore;

namespace Amiar_Agenda.Service.DAO
{

    public class DAO_ToDoList
    {
        AgendaContext Context;

        public DAO_ToDoList()
        {

        }

        //importer donnée
        public IEnumerable<ToDoList> GetAllToDoList()
        {
            using (Context = new AgendaContext())
            {
                var AllToDoList = Context.ToDoLists.ToList();
                return AllToDoList;
            }
        }

        //ajouter to do list
        public string AddToDoList(ToDoList todolist)
        {
            using (Context = new AgendaContext())
            {
                Context.ToDoLists.Add(todolist);

                Context.SaveChanges();
            }
            return "To Do List Ajouté";
        }

        //edit to do list
        public string ModifyToDoList(ToDoList todolist)
        {
            using (Context = new AgendaContext())
            {
                Context.ToDoLists.Update(todolist);
                Context.SaveChanges();
                return "La To Do List a été modifié";
            }
        }

        public void SupprToDoList(ToDoList todolist)
        {
            using (var context = new AgendaContext())
            {
                // Supprimer toutes les tâches associées à cette ToDoList
                foreach (var task in context.Taches.Where(t => t.ToDoListId == todolist.Id).ToList())
                {
                    context.Taches.Remove(task);
                }

                // Maintenant que les tâches associées ont été supprimées, supprimer la ToDoList elle-même
                context.ToDoLists.Remove(todolist);

                context.SaveChanges();
            }
        }

    }
}
