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

        public IEnumerable<Tache> GetTaskByToDoList(int ID)
        {
            using (var db = new AgendaContext())
            {
                return db.Taches.Where(t => t.ToDoListId == ID).ToList();
            }
        }

    }
}
