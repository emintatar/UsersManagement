using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UsersManagement.API.Fake;
using UsersManagement.API.Models;

namespace UsersManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private List<User> _users = FakeData.GetUsers(100);

        [HttpGet]
        public List<User> Get()
        {
            return _users;
        }

        [HttpGet("{id}")]
        public User Get(int id) 
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public User Post([FromBody]User user)
        {
            _users.Add(user);
            return user;
        }

        [HttpPut]
        public User Put([FromBody]User user)
        {
            var editedUser = _users.FirstOrDefault(x => x.Id == user.Id);
            editedUser.FirstName = user.FirstName;
            editedUser.LastName = user.LastName;
            editedUser.Address = user.Address;
            return user;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deletedUser = _users.FirstOrDefault(x => x.Id == id);
            _users.Remove(deletedUser);
        }
    }
}
