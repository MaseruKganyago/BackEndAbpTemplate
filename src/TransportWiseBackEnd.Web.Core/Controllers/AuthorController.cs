using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportWiseBackEnd.Domain;
using TransportWiseBackEnd.Authors;
using TransportWiseBackEnd.Authors.Dto;

namespace TransportWiseBackEnd.Controllers
{
	[Route("api/[controller]/[action]")]
	public class AuthorsController : TransportWiseBackEndControllerBase
	{
		private readonly IAuthorAppService _authorAppService;
		private readonly IMapper _mapper;

		public AuthorsController(IAuthorAppService authorAppService, IMapper mapper)
		{
			_authorAppService = authorAppService;
			_mapper = mapper;
		}

		// GET: api/Authors
		[HttpGet]
		[Authorize]
		public IEnumerable<AuthorDTO> GetAuthors()
		{
			var authors = _authorAppService.GetAll();
			var authorsDTO = _mapper.Map<List<AuthorDTO>>(authors);
			return authorsDTO;
		}

		// GET: api/Authors/5
		[HttpGet("{Id}")]
		[Authorize]
		public async Task<ActionResult<AuthorDTO>> GetAuthor([FromRoute] int Id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var author = await _authorAppService.GetAuthor(Id);
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
		public async Task<IActionResult> UpdateAuthor([FromRoute] int Id, [FromBody] AuthorDTO author)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (Id != author.Id)
			{
				return BadRequest();
			}

			var newArticle = await _authorAppService.PutAuthor(Id, author);
			var newArticleDTO = ObjectMapper.Map<AuthorDTO>(newArticle);

			return Ok(newArticleDTO);
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

			var newAuthor = await _authorAppService.PostAuthor(author);

			return Ok(newAuthor);
		}

		// DELETE: api/Authors/5
		[HttpDelete("{Id}")]
		[Authorize]
		public async Task<IActionResult> DeleteAuthor([FromRoute] int Id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var author = await _authorAppService.DeleteAuthor(Id);
			if (author == null)
			{
				return NotFound("Failed to delete, Author not found or invalid authorId.");
			}

			return Ok(author);
		}
	}
}
