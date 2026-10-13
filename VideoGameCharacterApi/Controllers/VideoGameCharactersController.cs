using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGameCharacterApi.Models;
using VideoGameCharacterApi.Services;

namespace VideoGameCharacterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameCharactersController(IVideoGameCharacterService service) : ControllerBase
    {


        [HttpGet]
        public async Task<ActionResult<List<Character>>> GetCharacters()
        {
            return Ok(await service.GetCharactersAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Character?>> GetCharacterById(int id)
        {
            var character = await service.GetCharacterByIdAsync(id);
            if (character == null)
            {
                return NotFound("The character was not found with the specified ID.");
            }
            return Ok(character);
        }
    }
}
