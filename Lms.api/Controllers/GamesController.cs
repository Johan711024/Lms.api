using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lms.Core;
using Lms.Data.Data;
using Lms.Core.Repositories;
using AutoMapper;
using Lms.Common.DTOs;
using Microsoft.AspNetCore.JsonPatch;

namespace Lms.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly LmsapiContext _context;
        private readonly IMapper mapper;

        public IUnitOfWork uow { get; }

        public GamesController(LmsapiContext context, IUnitOfWork uow, IMapper mapper)
        {
            _context = context;
            this.uow = uow;
            this.mapper = mapper;
        }



        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGame()
        {
            if (_context.Game == null)
            {
                return NotFound();
            }

            var games = uow.GameRepository.GetAllAsync();

            var dto = mapper.Map<GameDto>(games);


            return Ok(dto);
        }



        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(int? id)
        {
            if (uow.GameRepository.GetAllAsync() == null)
            {
                return NotFound();
            }
            if (id == null)
            {
                return NotFound();
            }

            //var game = await _context.Game.FindAsync(id);
            var game = await uow.GameRepository.GetAsync((int)id);



            if (game == null)
            {
                return NotFound();
            }

            var dto = mapper.Map<GameDto>(game);

            return Ok(dto);
        }



        // PUT: api/Games/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(int id, GameDto dto)
        {
            var game = await uow.GameRepository.GetAsync(id);

            if (game == null) return NotFound();

            mapper.Map(dto, game);

            uow.GameRepository.Update(game);

            await uow.CompleteAsync();

            return Ok(mapper.Map<GameDto>(game));
        }





        [HttpPatch("{id}")]
        public async Task<ActionResult<GameDto>> PatchGame(int id, JsonPatchDocument<GameDto> patchDocument)
        {
            var game = await uow.GameRepository.GetAsync(id);
            if (game == null) return NotFound();

            var dto = mapper.Map<GameDto>(game);

            patchDocument.ApplyTo(dto, ModelState);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            mapper.Map(dto, game);
            await uow.CompleteAsync();

            return Ok(mapper.Map<GameDto>(game));
        }




        // POST: api/Games
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Game>> PostGame(GameDto dto)
        {
            if (uow.GameRepository.GetAllAsync() == null)
            {
                return Problem("Entity set 'LmsapiContext.Game'  is null.");
            }


            var game = mapper.Map<Game>(dto);

            uow.GameRepository.Add(game);

            await uow.CompleteAsync();

            return CreatedAtAction(nameof(GetGame), new { id = game.Id }, mapper.Map<Game>(dto));
        }










        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            if (_context.Game == null)
            {
                return NotFound();
            }
            var game = await uow.GameRepository.GetAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            _context.Game.Remove(game);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //private bool GameExists(int id)
        //{
        //    return (_context.Game?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
