using AutoMapper;
using CerealAPI.DTO;
using CerealAPI.Interfaces;
using CerealAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace CerealAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CerealController(ICerealRepository cerealRepository, IManufactorerRepository manufactorerRepository, ITypeRepository typeRepository, IMapper mapper) : Controller
    {
        private readonly ICerealRepository _cerealRepository = cerealRepository;
        private readonly IManufactorerRepository _manufactorerRepository = manufactorerRepository;
        private readonly ITypeRepository _typeRepository = typeRepository;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Cereal>))]
        public IActionResult GetCereal()
        {
            var cereals = _mapper.Map<List<CerealDTO>>(_cerealRepository.GetCereals());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cereals);
        }

        [HttpGet("{cerealId}")]
        [ProducesResponseType(200, Type = typeof(Cereal))]
        [ProducesResponseType(400)]
        public IActionResult GetCereal(int cerealId)
        {
            if (!_cerealRepository.CerealExists(cerealId))
                return NotFound();
            var cereal = _mapper.Map<CerealDTO>(_cerealRepository.GetCereal(cerealId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cereal);
        }

        [HttpPost("[action]")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCereal([FromBody] CerealDTO cerealCreate)
        {
            if (cerealCreate == null)
                return BadRequest(ModelState);
            var cereal = _cerealRepository.GetCereals()
                .Where(c => c.Id == cerealCreate.Id)
                .FirstOrDefault();

            if (cereal != null)
            {
                ModelState.AddModelError("", "Cereal already exists");
                return StatusCode(422, ModelState);
            }
            if (cerealCreate.Id != 0)
            {
                ModelState.AddModelError("", "Id should be 0 to auto-update");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_manufactorerRepository.ManufactorerExists(cerealCreate.Mfr.Shortform))
                cerealCreate.Mfr = _manufactorerRepository.GetManufactorer(cerealCreate.Mfr.Shortform);
            if (_typeRepository.TypeExists(cerealCreate.Type.Shortform))
                cerealCreate.Type = _typeRepository.GetType(cerealCreate.Type.Shortform);

            var cearelMap = _mapper.Map<Cereal>(cerealCreate);

            if (!_cerealRepository.CreateCereal(cearelMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Created");
        }

        [HttpDelete("[action]/{cerealId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCereal(int cerealId)
        {
            if (!_cerealRepository.CerealExists(cerealId))
                return NotFound();

            var cerealToDelete = _cerealRepository.GetCereal(cerealId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_cerealRepository.DeleteCereal(cerealToDelete))
            {
                ModelState.AddModelError("", "Something went wrong with deleting the Cereal");
            }

            return NoContent();
        }

        // [HttpGet("[action]")]
        // [ProducesResponseType(200, Type = typeof(Cereal))]
        // [ProducesResponseType(400)]
        // public IActionResult GetCerealsWhere()
        // {
        //     List<Cereal> cereals = _mapper.Map<List<Cereal>>(_cerealRepository.GetCereals());
        //     if (!ModelState.IsValid)
        //         return BadRequest(ModelState);
        //     if (HttpContext.Request.Query != null)
        //     {
        //         foreach (var query in HttpContext.Request.Query)
        //         {
        //             if (typeof(Cereal).GetProperty(query.Key) != null)
        //             {
        //                 if (query.Value.First() == null) continue;
        //                 if (query.Value.First().StartsWith('@'))
        //                 {
        //                     cereals = [.. cereals.Where(a => a.GetType().GetProperty(query.Key).GetValue(a) != null &&
        //                         a.GetType().GetProperty(query.Key).GetValue(a).ToString().Contains(query.Value.First().Substring(1), System.StringComparison.OrdinalIgnoreCase))];
        //                 }
        //                 else if (typeof(Cereal).GetProperty(query.Key).PropertyType == typeof(int))
        //                 {
        //                     cereals = [.. cereals.Where(a => (int)a.GetType().GetProperty(query.Key).GetValue(a) == int.Parse(query.Value))];
        //                 }
        //                 else if (typeof(Cereal).GetProperty(query.Key).PropertyType == typeof(float))
        //                 {
        //                     cereals = [.. cereals.Where(a => (float)a.GetType().GetProperty(query.Key).GetValue(a) == float.Parse(query.Value))];
        //                 }
        //                 else if (typeof(Cereal).GetProperty(query.Key).PropertyType == typeof(string))
        //                 {
        //                     cereals = [.. cereals.Where(a => a.GetType().GetProperty(query.Key).GetValue(a) != null &&
        //                         a.GetType().GetProperty(query.Key).GetValue(a).ToString().Equals(query.Value, System.StringComparison.OrdinalIgnoreCase))];
        //                 }
        //                 else return NotFound();
        //             }
        //         }
        //         return Ok(cereals);
        //     }
        //     return NotFound();
        // }
    }
}