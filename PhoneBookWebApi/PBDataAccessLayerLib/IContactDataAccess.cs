using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBEntitiesLib; //for Contact entity

namespace PBDataAccessLayerLib
{
    public interface IContactDataAccess
    {
        void AddContact(Contact contact);
        void DeleteContact(int id);
        void UpdateContact(Contact contact);
        List<Contact> GetAllContacts();
        Contact GetContact(int id);
    }
}
