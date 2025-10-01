using CerealAPI.Interfaces;
using CerealAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace CerealAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CerealController(ICerealRepository cerealRepository) : Controller
    {
        private readonly ICerealRepository _cerealRepository = cerealRepository;

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Cereal>))]
        public IActionResult GetCereal()
        {
            var cereals = _cerealRepository.GetCereals();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cereals);
        }
    }
}