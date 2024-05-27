using Application.Behaviors;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Domain.Entities;
using Infrastructure.Repositories;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IDbFactory _db;
        private readonly IUserRepository _repository;
        private readonly UserService _service;
        private readonly IConfiguration _configuration;
        private readonly ILogger<PortifolioController> _logger;

        public UserController(IConfiguration configuration, ILogger<PortifolioController> logger)
        {
            _db = new DbFactory(configuration.GetSection("ConnectionStrings").Value);
            _repository = new UserRepository(_db);
            _service = new UserService(_repository);
            _configuration = configuration;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Getting Users...");
            List<User> list;
            try
            {
                list = _service.ListAllUsers();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error to Getting Users: " + ex.Message);
                return BadRequest(ex.Message);
            }
            
            return Ok(list);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> Get(int Id)
        {
            _logger.LogInformation("Getting a specifc User...");
            User user;
            try
            {
                user = _service.GetUser(Id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error to Get User: " + ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> Post(User user)
        {
            _logger.LogInformation("Post new User...");
            try
            {
                _service.AddUser(user);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error to Post User: " + ex.Message);
                return BadRequest(ex.Message);
            }
           
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] User user)
        {
            _logger.LogInformation("Updating User...");
            try
            {
                _service.UpdateUser(id, user);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error to Update User: " + ex.Message);
                return BadRequest(ex.Message);
            }
           
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            _logger.LogInformation("Deleting User...");

            try
            {
                _service.DeleteUser(id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error to Delete User: " + ex.Message);
                return BadRequest(ex.Message);
            }
            
            return Ok();
        }
    }
}
