using DemoProject.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace DemoProject.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly AppDbContext _db;
        public UserController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAllUser()
        {
            return new ObjectResult(_db.Users.ToArray());
        }

        [HttpGet("{id}", Name ="GetUserById")]
        public IActionResult GetUserById(int id)
        {
            var user = _db.Users.SingleOrDefault(u => u.Id == id);
            if(user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }
        [HttpPost]
        public IActionResult AddNewUser([FromBody] User _user)
        {
            if (_user == null)
            {
                return BadRequest();
            }
            _db.Users.Add(_user);
            _db.SaveChanges();

            return CreatedAtRoute("GetUserById", new { id = _user.Id }, _user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User _user)
        {
            if(_user == null || _user.Id == id)
            {
                return BadRequest();
            }

            var user = _db.Users.SingleOrDefault(u => u.Id == id);
            if(user == null)
            {
                return NotFound();
            }
            user.Name = _user.Name;
            user.Age = _user.Age;
            user.PhoneNo = _user.PhoneNo;

            _db.Users.Update(user);
            _db.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == id);
            if(user == null)
            {
                return NotFound();
            }

            _db.Users.Remove(user);
            _db.SaveChanges();
            return new NoContentResult();
        }

    }
}
