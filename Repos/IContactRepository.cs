using contact_list.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace contact_list.Repos
{
    public interface IContactRepository
    {
        ContactModel ListById(int id);
        List<ContactModel> FindAll();
        ContactModel Add(ContactModel contact);
        ContactModel Update(ContactModel contact);
        bool Delete(int id);
    }
}
