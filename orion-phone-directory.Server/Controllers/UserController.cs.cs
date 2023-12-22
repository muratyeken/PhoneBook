using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrionPhoneDirectory.Domain.Entities;
using OrionPhoneDirectory.Service.Abstract;

namespace orion_phone_directory.Server.Controllers
{
    [Route("api/[controller]/action")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGenericService<User> _service;
        public UserController(IGenericService<User> service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult GetAllUsers()
        {
            //return Ok("Basarili");
            return Ok(_service.GetAll());

        }

        //[HttpGet]
        //public ActionResult GetActiveUsers()
        //{
        //    //return Ok("Basarili");
        //    return Ok(_service.GetActive());

        //}

        [HttpGet("{id}")]
        public ActionResult GetUserByID(int id)
        {
            //return Ok("Basarili");
            return Ok(_service.GetByID(id));

        }

        [HttpPost]
        public ActionResult AddUser(User user)
        {
            _service.Add(user);
            //return Ok(Succesfull);
            return CreatedAtAction("GetUserByID", new
            {
                id = user.ID,
                user
            });
        }

        [HttpPut("id")]
        public IActionResult UpdateUser(int id, User user)
        {
            if (id != user.ID)
                return BadRequest();
            try
            {
                _service.Update(user);
                return Ok(user);
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!IsUserThere(id))
                    return NotFound();
            }
            return NoContent();
        }
        private bool IsUserThere(int id)
        {
            return _service.Any(usr => usr.ID == id);
        }

        [HttpDelete("id")]
        public IActionResult DeleteUser(int id)
        {
            var user = _service.GetByID(id);
            if (user == null)
                return NotFound();
            try
            {
                _service.Remove(user);
                return Ok("User Silindi");

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet("id")]
        public IActionResult ActivateUser(int id)
        {
            var category = _service.GetByID(id);
            if (category == null)
                return NotFound();
            try
            {
                _service.Activate(id);
                //return Ok("User Aktiflesti");
                return Ok(_service.GetByID(id));


            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //[HttpGet]
        //public IActionResult Login(string email, string password)
        //{
        //    if (_service.Any(user => user.Email == email && user.Password == password))
        //    {
        //        User loggedUser = _service.GetByDefault(user => user.Email == email && user.Password == password);
        //        return Ok(loggedUser);
        //    }
        //    return NotFound();
        //}
    }
}
