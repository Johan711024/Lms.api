using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lms.Core;
using Lms.Data.Data;
using AutoMapper;
using Lms.Common.DTOs;
using Lms.Core.Repositories;
using Microsoft.AspNetCore.JsonPatch;

namespace Lms.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentsController : ControllerBase
    {
        private readonly LmsapiContext _context;
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public TournamentsController(LmsapiContext context, IUnitOfWork uow, IMapper mapper)
        {
            _context = context;
            this.uow = uow;
            this.mapper = mapper;
        }




        // GET: api/Tournaments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tournament>>> GetTournament()
        {
            if (_context.Tournament == null)
            {
                return NotFound();
            }

            var tournaments = await uow.TournamentRepository.GetAllAsync();

            var dto = mapper.Map<IEnumerable<TournamentDto>>(tournaments);

            return Ok(dto);
        }








        // GET: api/Tournaments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tournament>> GetTournament(int? id)
        {
            if (_context.Tournament == null)
            {
                return NotFound();
            }
            if (id == null)
            {
                return NotFound();
            }
            //var tournament = await _context.Tournament.FindAsync(id);

            var tournament = await uow.TournamentRepository.GetAsync((int)id);

            if (tournament == null)
            {
                return NotFound();
            }

            var dto = mapper.Map<TournamentDto>(tournament);

            return Ok(dto);
        }








        // PUT: api/Tournaments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTournament(int id, TournamentDto dto)
        {
            var tournament = await uow.TournamentRepository.GetAsync(id);

            if (tournament == null)
            {
                return NotFound();
            }
            mapper.Map(dto, tournament);


            uow.TournamentRepository.Update(tournament);

            await uow.CompleteAsync();

            return Ok(mapper.Map<TournamentDto>(tournament));
        }




        [HttpPatch("{id}")]
        public async Task<ActionResult<TournamentDto>> PatchTournament(int id, JsonPatchDocument<TournamentDto> patchDocument)
        {
            var tournament = await uow.TournamentRepository.GetAsync(id);
            if (tournament == null) return NotFound();

            var dto = mapper.Map<TournamentDto>(tournament);

            patchDocument.ApplyTo(dto, ModelState);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            mapper.Map(dto, tournament);
            await uow.CompleteAsync();

            return Ok(mapper.Map<TournamentDto>(tournament));
        }







        // POST: api/Tournaments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TournamentDto>> PostTournament(Tournament dto)
        {
            //if (_context.Tournament == null)
            //{
            //    return Problem("Entity set 'LmsapiContext.Tournament'  is null.");
            //}

            var tournament = mapper.Map<Tournament>(dto);

            uow.TournamentRepository.Add(tournament);

            await uow.CompleteAsync();

            //Fråga lärare om detta. Vad gör den?
            return CreatedAtAction(nameof(GetTournament), new { id = tournament.Id }, mapper.Map<Tournament>(dto));
        }








        // DELETE: api/Tournaments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournament(int id)
        {
            if (_context.Tournament == null)
            {
                return NotFound();
            }
            var tournament = await uow.TournamentRepository.GetAsync(id);

            if (tournament == null)
            {
                return NotFound();
            }

            uow.TournamentRepository.Remove(tournament);
            await uow.CompleteAsync();

            return NoContent();
        }

        //private bool TournamentExists(int id)
        //{
        //    return (_context.Tournament?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
