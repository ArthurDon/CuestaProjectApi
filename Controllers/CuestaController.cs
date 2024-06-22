using CustaProject.Dtos;
using CustaProject.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Net;
namespace CustaProject.Controllers
{
    [ApiController]
    [Route("v1/")]
    public class CuestaController : ControllerBase
    {
        private readonly ICuestaRepository _cuestaRepository;
        private readonly ILogger<CuestaController> _logger;

        public CuestaController(ICuestaRepository cuestaRepository, ILogger<CuestaController> logger)
        {
            _cuestaRepository = cuestaRepository;
            _logger = logger;
        }

        [HttpGet("GetInformation")]
        [ProducesResponseType(typeof(CuestaResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetResult([FromQuery] string earringId = null, [FromQuery] string category = null)
        {
            if (earringId == null && category == null)
            {
                return BadRequest("Pelo menos um filtro (dentition ou category) deve ser fornecido.");
            }
            var cuestaResult = await _cuestaRepository.GetResult(earringId, category);

            if (cuestaResult == null)
            {
                return NotFound();
            }
            return Ok(cuestaResult);
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(CuestaResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetResultAll()
        {
            var cuestaResult = await _cuestaRepository.GetResultAll();

            if (cuestaResult == null)
            {
                return NotFound();
            }
            return Ok(cuestaResult);
        }

        [HttpPost("InsertAnimal")]
        [ProducesResponseType(typeof(CuestaResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> InsertAnimal(
         [FromQuery][Required] string animalGenus,
         [FromQuery][Required] string dateBirth,
         [FromQuery][Required] int weight,
         [FromQuery][Required] string dentition,
         [FromQuery][Required] int quantity,
         [FromQuery][Required] string nameDad,
         [FromQuery][Required] string category,
         [FromQuery][Required] string nameMom,
         [FromQuery][Required] string dadAnimal,
         [FromQuery][Required] string momAnimal,
         [FromQuery][Required] string earringId,
         [FromQuery][Required] string createdBy)
        {
            var animalDto = new AnimalDto
            {
                AnimalGenus = FirstCharToUpper(animalGenus),
                DateBirth = FormatDateOfBirth(dateBirth),
                Weight = weight,
                Dentition = FirstCharToUpper(dentition),
                Quantity = quantity,
                NameDad = FirstCharToUpper(nameDad),
                Category = FirstCharToUpper(category),
                NameMom = FirstCharToUpper(nameMom),
                DadAnimal = FirstCharToUpper(dadAnimal),
                MomAnimal = FirstCharToUpper(momAnimal),
                CreatedBy = FirstCharToUpper(createdBy),
                EarringId = earringId,
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(weight <= 0)
            {
                return BadRequest("O peso precisa ser maior que zero.");
            }

            if (quantity < 0)
            {
                return BadRequest("Quantidade menor que zero não existe.");
            }

            var result = await _cuestaRepository.InsertAnimal(animalDto);

            if (!result)
            {
                return BadRequest("Não foi possível inserir o animal.");
            }

            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpDelete("delete")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteAnimal([FromQuery] string earringId = null, [FromQuery] string category = null)
        {
            if (earringId == null && category == null)
            {
                return BadRequest("Pelo menos um filtro (dentition ou animalName) deve ser fornecido.");
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isDeleted = await _cuestaRepository.DeleteAnimal(earringId, category);


            if (!isDeleted)
            {
                return NotFound("Animal não encontrado. Verifique os filtros fornecidos.");
            }

            return NoContent();
        }

        [HttpPut("update")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateAnimal([FromQuery] string earringId, [FromBody] AnimalUpdateDto updateDto)
        {
            if (string.IsNullOrEmpty(earringId))
            {
                return BadRequest("O campo 'dentition' é obrigatório.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Dados inválidos para atualização.");
            }

            if (updateDto == null)
            {
                return BadRequest("Dados inválidos para atualização.");
            }

            var existingAnimal = await _cuestaRepository.GetAnimalByDentition(earringId);

            if (existingAnimal == null)
            {
                return NotFound($"Animal com brinco '{earringId}' não encontrado.");
            }

            var isUpdated = await _cuestaRepository.UpdateAnimal(earringId, updateDto);
            if (!isUpdated)
            {
                return BadRequest($"Não foi possível atualizar o animal com brinco '{earringId}'.");
            }

            return NoContent();
        }

        private string FirstCharToUpper(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }

        private string FormatDateOfBirth(string dateOfBirth)
        {
            if (DateTime.TryParseExact(dateOfBirth, "MMM dd yyyy hh:mmtt", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            {
                return parsedDate.ToString("yyyy-MM-dd");
            }

            return dateOfBirth;
        }
    }
}