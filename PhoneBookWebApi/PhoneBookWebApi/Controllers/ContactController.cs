using Microsoft.AspNetCore.Mvc;
using PBBusinessLayerLib;
using PBEntitiesLib;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBookWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactBusinessLayer _contactBusinessLayer;
        public ContactController(IContactBusinessLayer contactBusinessLayer)
        {
            this._contactBusinessLayer = contactBusinessLayer; 
        }

        // GET: api/<ContactController>
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return _contactBusinessLayer.GetAllContacts();
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public Contact Get(int id)
        {
            return _contactBusinessLayer.GetContact(id);
        }

        // POST api/<ContactController>
        [HttpPost]
        public void Post([FromBody] Contact contact)
        {
            _contactBusinessLayer.AddContact(contact);
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Contact contact)
        {
            _contactBusinessLayer.UpdateContact(contact);
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _contactBusinessLayer.RemoveContact(id);
        }
    }
}
