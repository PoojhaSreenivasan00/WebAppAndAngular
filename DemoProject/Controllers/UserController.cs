using DemoProject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections;

namespace DemoProject.Controllers
{
    [Route("api")]
    public class UserController : Controller
    {
        private readonly AppDbContext _db;
        private readonly ILogger<UserController> _logger;
        public UserController(AppDbContext db, ILogger<UserController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet("users")]
        public IActionResult GetAllUser()
        {
            _logger.LogInformation("All user details are logged.");
            return new ObjectResult(_db.Users);
        }


        [HttpGet("user/{id}", Name = "GetUserById")]
        public IActionResult GetUserById(int id)
        {
            var user = _db.Users.SingleOrDefault(u => u.Id == id);
            if (user == null)
            {
                _logger.LogWarning($"The user for id {id} is not found");
                return NotFound();

            }
            _logger.LogInformation($"The user details for id {id} is logged.");
            return new ObjectResult(user);

        }


        [HttpPost("user")]
        public IActionResult AddNewUser([FromBody] User _user)
        {
            if (_user == null)
            {
                _logger.LogWarning("Bad request");
                return BadRequest();

            }
            _db.Users.Add(_user);
            _db.SaveChanges();

            _logger.LogInformation("New User logged.");
            return CreatedAtRoute("GetUserById", new { id = _user.Id }, _user);

        }


        [HttpPut("user/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User _user)
        {
            if (_user == null || _user.Id == id)
            {
                _logger.LogWarning("Bad request");
                return BadRequest();

            }

            var user = _db.Users.Single(u => u.Id == id); //use find instaed of SingeORDefault
            if (user == null)
            {
                _logger.LogWarning($"The user for id {id} is not found");
                return NotFound();

            }
            _db.Entry(user).Property("Name").CurrentValue = _user.Name;
            _db.Entry(user).Property("Age").CurrentValue = _user.Age;
            _db.Entry(user).Property("PhoneNo").CurrentValue = _user.PhoneNo;
            //user.Name = _user.Name;
            //user.Age = _user.Age;
            //user.PhoneNo = _user.PhoneNo;

            _db.Users.Update(user);
            _db.SaveChanges();
            _logger.LogInformation($"User details for id{id} is updated.");
            return new NoContentResult();

        }


        [HttpDelete("user/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                _logger.LogWarning($"The user for id {id} is not found");
                return NotFound();

            }

            _db.Users.Remove(user);
            _db.SaveChanges();
            _logger.LogInformation($"The user {id} is deleted");
            return new NoContentResult();

        }

    }
}
