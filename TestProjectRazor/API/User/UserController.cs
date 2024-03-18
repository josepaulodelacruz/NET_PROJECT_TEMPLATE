using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestProjectRazor.Models;
using TestProjectRazor.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestProjectRazor.API.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;

        public UserController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService;
        }


        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestProjectRazor.Models.User>>> Get()
        {
            IEnumerable users = await _userService.Get(_config);
            return new OkObjectResult(users);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestProjectRazor.Models.User>> Get(int id)
        {
            TestProjectRazor.Models.User user = await _userService.GetById(_config, id);

            if(user.ID == 0)
            {
                return NotFound();
            }

            return new OkObjectResult(user);

        }

        // POST api/<UserController>
        [HttpPost]
        public async void Post(TestProjectRazor.Models.User userParam)
        {
            var result = await _userService.AddUser(_config);



        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
