using Application.Behaviors;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortifolioController : ControllerBase
    {
        private readonly IDbFactory _db;
        private readonly IPortifolioRepository _repository;
        private readonly PortifolioService _service;
        private readonly IConfiguration _configuration;
        private readonly ILogger<PortifolioController> _logger;

        public PortifolioController(IConfiguration configuration, ILogger<PortifolioController> logger)
        {
            _db = new DbFactory(configuration.GetSection("ConnectionStrings").Value) ;
            _repository = new PortifolioRepository(_db); 
            _service = new PortifolioService(_repository);
            _configuration = configuration;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Getting Investiments...");
            List<Investiment> list;
            try
            {
                list = _service.ListAllInvestiments();

            }
            catch (Exception ex)
            {
                _logger.LogError("Error to Getting Investiments: " + ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok(list);
        }

        [HttpGet("{Symbol}")]
        public async Task<ActionResult> Get(string Symbol)
        {
            _logger.LogInformation("Getting Investiments by Symbol...");
            Investiment investiment;
            try
            {
                investiment = _service.GetInvestimentsBySymbol(Symbol.Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError("Error to Get Investiments: " + ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok(investiment);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Investiment investiment)
        {
            _logger.LogInformation("Post new investiment...");
            try
            {
                _service.AddInvestiment(investiment);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error to Post Investiment: " + ex.Message);
                return BadRequest(ex.Message); 
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Investiment investiment)
        {
            _logger.LogInformation("Updating investiment...");
            try
            {
                _service.UpdateInvestiment(id, investiment);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error to Update Investiment: " + ex.Message);
                return BadRequest(ex.Message);
            }
            
            return Ok();
        }

        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    _service.UpdateInvestiment(id, investiment);
        //    return Ok();
        //}
    }
}
