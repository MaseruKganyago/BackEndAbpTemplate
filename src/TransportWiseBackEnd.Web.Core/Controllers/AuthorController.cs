using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportWiseBackEnd.EntityFrameworkCore;
using TransportWiseBackEnd.Models;
using TransportWiseBackEnd.Models.Author.DTO;

namespace TransportWiseBackEnd.Controllers
{
	[Route("api/[controller]/[action]")]
	public class AuthorsController : TransportWiseBackEndControllerBase
	{
		private readonly TransportWiseBackEndDbContext _context;
		private readonly IMapper _mapper;

		public AuthorsController(TransportWiseBackEndDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		// GET: api/Authors
		[HttpGet]
		[Authorize]
		public IEnumerable<AuthorDTO> GetAuthor()
		{
			var authors = _context.Authors.ToList();
			var authorsDTO = _mapper.Map<List<AuthorDTO>>(authors);
			return authorsDTO;
		}

		// GET: api/Authors/5
		[HttpGet("{id}")]
		[Authorize]
		public async Task<ActionResult<AuthorDTO>> GetAuthor([FromRoute] Guid id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var author = await _context.Authors.FindAsync(id);
			var authorDTO = _mapper.Map<AuthorDTO>(author);

			if (author == null)
			{
				return NotFound();
			}

			return Ok(authorDTO);
		}

		// PUT: api/Authors/5
		[HttpPut("{id}")]
		[Authorize]
		public async Task<IActionResult> PutAuthor([FromRoute] Guid id, [FromBody] AuthorDTO author)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != author.Id)
			{
				return BadRequest();
			}

			_context.Entry(author).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!AuthorExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Authors
		[HttpPost]
		[Authorize]
		public async Task<IActionResult> PostAuthor([FromBody] AuthorDTO author)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var holder = _mapper.Map<AuthorModel>(author);
			_context.Authors.Add(holder);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetAuthor", new { id = author.Id }, author);
		}

		// DELETE: api/Authors/5
		[HttpDelete("{id}")]
		[Authorize]
		public async Task<IActionResult> DeleteAuthor([FromRoute] Guid id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var author = await _context.Authors.FindAsync(id);
			if (author == null)
			{
				return NotFound();
			}

			_context.Authors.Remove(author);
			await _context.SaveChangesAsync();

			return Ok(author);
		}

		private bool AuthorExists(Guid id)
		{
			return _context.Authors.Any(e => e.Id == id);
		}
	}
}
