using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Amiar_Agenda.AgendaDB;
using Microsoft.EntityFrameworkCore;

namespace Amiar_Agenda.Service.DAO
{
    public class DAO_Reseau
    {
        AgendaContext Context;

        public DAO_Reseau()
        {
        }

        public IEnumerable<SocialMedium> GetReseaukByContact(int ID)
        {
            using (var db = new AgendaContext())
            {
                return db.SocialMedia.Where(t => t.ContactId == ID).ToList();
            }
        }

    }
}
