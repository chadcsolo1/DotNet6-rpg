using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_rpg.Dtos.Character;
using DotNet_rpg.Services.CharacterServices;
using Microsoft.AspNetCore.Mvc;


namespace DotNet_rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {

            _characterService = characterService;
        }

        [HttpGet("GetAll")]

        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> GetAllCharacters()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]


        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetCharacterById(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpDelete("{id}")]


        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> DeleteCharacter(int id)
        {
            var response = await _characterService.DeleteCharacter(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }


        [HttpPost("Create")]

        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> CreateNewCharacter(AddCharacterDto newCharacter)
        {

            return Ok(await _characterService.CreateNewCharacter(newCharacter));
        }

        [HttpPut("Update")]

        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var response = await _characterService.UpdateCharacter(updatedCharacter);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
