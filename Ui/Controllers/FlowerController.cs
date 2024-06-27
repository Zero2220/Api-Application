using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Ui.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Ui.Exceptions;
using Ui.Services.Interfaces;
using Ui.Models.Flowers;

namespace Flower_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowerController : ControllerBase
    {
        private readonly IFlowerService _flowerService;

        public FlowerController(IFlowerService flowerService)
        {
            _flowerService = flowerService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int page = 1)
        {
            try
            {
                var flowers = await _flowerService.GetAllPaginated<FlowerGetRequest>(page);
                return Ok(flowers);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var flower = await _flowerService.Get<FlowerGetRequest>(id);
                return Ok(flower);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize]
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] FlowerCreateRequest flowerDto)
        {
            if (flowerDto == null)
            {
                return BadRequest("Invalid flower data.");
            }

            try
            {
                var response = await _flowerService.Create(flowerDto);
                return Ok(response);
            }
            catch (ModelException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize]
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] FlowerUpdateRequest flowerDto)
        {
            if (flowerDto == null)
            {
                return BadRequest("Invalid flower data.");
            }

            try
            {
                await _flowerService.Update(flowerDto, id);
                return NoContent();
            }
            catch (ModelException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _flowerService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize]
        [HttpPost("CreateFromForm")]
        public async Task<IActionResult> CreateFromForm([FromForm] FlowerCreateRequest flowerFormDto)
        {
            if (flowerFormDto == null)
            {
                return BadRequest("Invalid flower data.");
            }

            try
            {
                var response = await _flowerService.CreateFromForm(flowerFormDto);
                return Ok(response);
            }
            catch (ModelException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
