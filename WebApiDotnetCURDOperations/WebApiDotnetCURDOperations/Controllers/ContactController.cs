using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDotnetCURDOperations.Models;

namespace WebApiDotnetCURDOperations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        public static List<Contact> Contacts = new List<Contact> {
        new Contact{ Id=1,Name="rushabh", DOB="17 march"},
        new Contact{ Id=2,Name="suvijay", DOB="14 Octomber" },
        new Contact{ Id=3,Name="prathmesh", DOB="11 july"},
        new Contact{ Id=4,Name="Abhijeet", DOB="23 November"}


        };

        [HttpGet]
        public ActionResult<List<Contact>> GetContacts()
        {
            return Ok(Contacts);
        }

        [HttpGet("{id}")]
        public ActionResult<Contact> Getcontact(int id)
        {
            var contact = Contacts.Find(x => x.Id == id);
            if (contact == null)
            {
                return NotFound("notfound");
            }
            else
            {
                return Ok(contact);
            }
        }

        [HttpPost]
        public ActionResult<List<Contact>> CreateContact(Contact contact)
        {
            Contacts.Add(contact);
            return Ok(Contacts);

        }

        [HttpPut]
        public ActionResult<List<Contact>> Update(Contact updatedcontact)
        {
            var foundcontact = Contacts.Find(x => x.Id == updatedcontact.Id);
            if(updatedcontact==null)
            {
                return NotFound("not found contact");
            }
            

            foundcontact.Name = updatedcontact.Name;
        foundcontact.Id= updatedcontact.Id;        
            foundcontact.DOB= updatedcontact.DOB;
            return Ok(foundcontact);

        }

        [HttpDelete("{id}")]
        public ActionResult<List<Contact>> Delete(int id) {

            var contact=Contacts.Find(x => x.Id == id);
            if(contact==null)
            {
                return NotFound("not found");
            }
            Contacts.Remove(contact);

            return Ok(Contacts);
        }
    }



}
