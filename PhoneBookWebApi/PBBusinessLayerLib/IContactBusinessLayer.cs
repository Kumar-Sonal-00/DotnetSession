using PBEntitiesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBBusinessLayerLib
{
    public interface IContactBusinessLayer
    {
        void AddContact(Contact contact);
        void RemoveContact(int id);
        void UpdateContact(Contact contact);
        List<Contact> GetAllContacts();
        Contact GetContact(int id);
        //other logical or utility methods methods 
    }
}
