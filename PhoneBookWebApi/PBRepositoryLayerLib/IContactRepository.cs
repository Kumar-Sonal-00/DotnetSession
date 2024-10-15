using PBEntitiesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBRepositoryLayerLib
{
    public interface IContactRepository
    {
        void AddContact(Contact contact);
        void RemoveContact(int id);
        void UpdateContact(Contact contact);
        List<Contact> GetAllContacts();
        Contact GetContact(int id);
    }
}
