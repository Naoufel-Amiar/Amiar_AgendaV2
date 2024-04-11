using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Amiar_Agenda.AgendaDB;
using Microsoft.EntityFrameworkCore;


namespace Amiar_Agenda.Service.DAO
{
    public class DAO_contact
    {
        AgendaContext Context;

        public DAO_contact()
        {
        }

        //importer donnée
        public IEnumerable<Contact> GetAllContacts()
        {
            using (Context = new AgendaContext())
            {
                var Allcontacts = Context.Contacts.ToList();
                return Allcontacts;
            }
        }


        //chercher donner par ID
        public Contact GetContactByID(int id)
        {
            using (Context = new AgendaContext())
            {
                Contact contact = Context.Contacts.Single(x => x.Id == id);
                return contact;
            }
        }
        //recherche par nom
        public List<Contact> GetContactByName(string name)
        {
            using (Context = new AgendaContext())
            {
                var contacts = Context.Contacts.Where(a => a.Nom == name).ToList();
                return contacts;
            }
        }

        //recherche par nom qui commence par un caractere
        public IEnumerable<Contact> GetContactStartByName(string name)
        {
            using (Context = new AgendaContext())
            {
                var ListContact = Context.Contacts.Where(a => a.Nom.StartsWith(name)).ToList();
                return ListContact;
            }
        }



        //ajouter contact
        public string AddContact(Contact contacts)
        {
            using (Context = new AgendaContext())
            {
                Context.Contacts.Add(contacts);

                Context.SaveChanges();
            }
            return "Contact Ajouté";
        }

        //edit contact
        public string ModifyContact(Contact contacts)
        {
            using (Context = new AgendaContext())
            { 
                Context.Contacts.Update(contacts);
                Context.SaveChanges();
                return "Le contact a été modifié";
            }
        }

        //supprimer contact par ID
        public string DeleteContactByID(int ID)
        {
            var itemToRemove = Context.Contacts.SingleOrDefault(x => x.Id == ID);
            if (itemToRemove != null)
            {
                Context.Contacts.Remove(itemToRemove);
                Context.SaveChanges();
            }
            return "Contacts par ID retirer";
        }

        //supprimer contact
        public string SupprContact(Contact contacts)
        {
            using (Context = new AgendaContext())
            {
                using (Context = new AgendaContext())
                {
                    Context.Contacts.Remove(contacts);

                    Context.SaveChanges();
                }
            }
            return "Contacts retirer";

        }

        

    }
}
