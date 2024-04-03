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

        //supprimer to do list
        public string SupprToDoList(ToDoList todolist)
        {
            using (Context = new AgendaContext())
            {
                using (Context = new AgendaContext())
                {
                    Context.ToDoLists.Remove(todolist);

                    Context.SaveChanges();
                }
            }
            return "Contacts retirer";

        }

        ////avoir tasks de la to do list
        //public List<ToDoList> GetTaskToDoList()
        //{
        //    using (Context = new AgendaContext())
        //    {
        //        var taskoftodolist = Context.ToDoLists.Include(cnt => cnt.Tasks).ToList();
        //        return taskoftodolist;
        //    }
        //}

        

    }



}
