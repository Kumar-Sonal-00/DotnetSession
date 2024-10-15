using PBDataAccessLayerLib;
using PBEntitiesLib;

namespace PBRepositoryLayerLib
{
    public class ContactRepository : IContactRepository
    {
        private readonly IContactDataAccess contactDataAccess;
        public ContactRepository(IContactDataAccess contactDataAccess)
        {
            this.contactDataAccess = contactDataAccess;
        }


        public void AddContact(Contact contact)
        {
           contactDataAccess.AddContact(contact);
        }

        public List<Contact> GetAllContacts()
        {
            return contactDataAccess.GetAllContacts();            
        }

        public Contact GetContact(int id)
        {
            return contactDataAccess.GetContact(id);
        }

        public void RemoveContact(int id)
        {
            contactDataAccess.DeleteContact(id);
        }

        public void UpdateContact(Contact contact)
        {
            contactDataAccess.UpdateContact(contact);
        }
    }
}
