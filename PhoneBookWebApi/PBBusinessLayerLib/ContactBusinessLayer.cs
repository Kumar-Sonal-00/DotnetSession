using PBEntitiesLib;
using PBRepositoryLayerLib;

namespace PBBusinessLayerLib
{
    public class ContactBusinessLayer : IContactBusinessLayer
    {
        private readonly IContactRepository _contactRepository;
        public ContactBusinessLayer(IContactRepository contactRepository)
        {
            this._contactRepository = contactRepository;
        }
        public void AddContact(Contact contact)
        {
            _contactRepository.AddContact(contact);
        }

        public List<Contact> GetAllContacts()
        {
            return _contactRepository.GetAllContacts();
        }

        public Contact GetContact(int id)
        {
            return _contactRepository.GetContact(id);
        }

        public void RemoveContact(int id)
        {
           _contactRepository.RemoveContact(id);
        }

        public void UpdateContact(Contact contact)
        {
            _contactRepository.UpdateContact(contact);
        }
    }
}
