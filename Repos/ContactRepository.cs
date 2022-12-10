using contact_list.Data;
using contact_list.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace contact_list.Repos
{
    public class ContactRepository : IContactRepository
    {
        private readonly DatabaseContext _databaseContext;
        public ContactRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public ContactModel ListById(int id)
        {
            return _databaseContext.Contacts.FirstOrDefault(x => x.Id == id);
        }
        public List<ContactModel> FindAll()
        {
            return _databaseContext.Contacts.ToList();
        }
        public ContactModel Add(ContactModel contact)
        {
            //save in database
            _databaseContext.Contacts.Add(contact);
            _databaseContext.SaveChanges();
            return contact;
        }

        public ContactModel Update(ContactModel contact)
        {
            ContactModel contactDb = ListById(contact.Id);

            if (contact == null) throw new Exception("attempt to change information was not sucessfull");

            contactDb.Name = contact.Name;
            contactDb.Email = contact.Email;
            contactDb.Phone = contact.Phone;

            _databaseContext.Update(contactDb);
            _databaseContext.SaveChanges();
            return contactDb;

        }

        public bool Delete(int id)
        {
            ContactModel contactDb = ListById(id);

            if (contactDb == null) throw new Exception("attempt to delete contact was not sucessfull");

            _databaseContext.Remove(contactDb);
            _databaseContext.SaveChanges();
            return true;

        }
    }
}
