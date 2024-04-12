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

        public IEnumerable<SocialMedium> GetReseauByContact(int ID)
        {
            using (var db = new AgendaContext())
            {
                return db.SocialMedia.Where(t => t.ContactId == ID).ToList();
            }
        }

        //ajouter reseau
        public string CreateReseauAsignContact(SocialMedium socialmedia, int contactId)
        {
            using (var db = new AgendaContext())
            {
                // Vérifier si la liste associée à la tâche existe dans la base de données
                var existingContact = db.Contacts.FirstOrDefault(l => l.Id == contactId);

                if (existingContact != null)
                {
                    // Associer la tâche à la liste existante
                    socialmedia.ContactId = contactId;

                    // Ajouter la tâche à la base de données
                    db.SocialMedia.Add(socialmedia);
                    db.SaveChanges();

                    return "Tâche ajoutée avec succès à la liste " + existingContact.Nom;
                }
                else
                {
                    return "La liste associée n'existe pas.";
                }
            }
        }

        //supprimer reseau
        public void DeleteReseau(int reseauId)
        {
            using (var db = new AgendaContext())
            {
                var ReseauToDelete = db.SocialMedia.FirstOrDefault(t => t.Id == reseauId);
                if (ReseauToDelete != null)
                {
                    db.SocialMedia.Remove(ReseauToDelete);
                    db.SaveChanges();
                }
            }
        }

        //modifier reseau
        public string ModifyTask(SocialMedium socialmedium)
        {
            using (Context = new AgendaContext())
            {
                Context.SocialMedia.Update(socialmedium);
                Context.SaveChanges();
                return "La tache a été modifié";
            }
        }


    }
}
