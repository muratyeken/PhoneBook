using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OrionPhoneDirectory.Domain.Entities;
using OrionPhoneDirectory.Domain.Enums;
using OrionPhoneDirectory.Service.Abstract;

namespace orion_phone_directory.Server.Controllers
{
    [Route("api/[controller]/action")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IGenericService<User> _userService;
        private readonly IGenericService<Contact> _contactService;

        public ContactController(IGenericService<User> userService, IGenericService<Contact> contactService)
        {
            _userService = userService;
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult GetAllContacts()
        {
            return Ok(_contactService.GetAll());
        }

        //[HttpGet]
        //public IActionResult GetActiveContacts()
        //{
        //    return Ok(_contactService.GetActive());
        //}

        [HttpGet("{id}")]
        public IActionResult GetContactByID(int id)
        {
            return Ok(_contactService.GetByID(id));
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            _contactService.Add(contact);
            return CreatedAtAction("GetContactByID", new
            {
                id = contact.ID,
                contact
            });
        }

        [HttpDelete("id")]
        public IActionResult DeleteContact(int id)
        {
            var contact = _contactService.GetByID(id);
            if (contact != null)
                return NotFound();
            try
            {
                _contactService.Remove(contact);
                return Ok("Contact Silindi");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("id")]
        public IActionResult UpdateContact(int id, Contact contact)
        {
            if (id != contact.ID)
                return BadRequest();
            try
            {
                _contactService.Update(contact);
                return Ok(contact);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (IsContactThere(id))
                    return NotFound();
            }
            return NoContent();
        }
        private bool IsContactThere(int id)
        {
            return _contactService.Any(ct => ct.ID == id);
        }



    }

}
