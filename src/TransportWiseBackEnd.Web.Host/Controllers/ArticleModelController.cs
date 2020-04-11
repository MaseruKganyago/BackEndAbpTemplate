using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportWiseBackEnd.Controllers;
using TransportWiseBackEnd.EntityFrameworkCore;
using TransportWiseBackEnd.Models;
using TransportWiseBackEnd.Models.Articles.DTO;

namespace TransportWiseBackEnd.Web.Host.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArticleModelController : TransportWiseBackEndControllerBase
	{
		[Route("api/[controller]/[action]")]
		class ArticlesController : TransportWiseBackEndControllerBase
		{
			private readonly TransportWiseBackEndDbContext _context;
			private readonly IMapper _mapper;

			public ArticlesController(TransportWiseBackEndDbContext context, IMapper mapper)
			{
				_context = context;
				_mapper = mapper;
			}

			// GET: api/Articles
			[HttpGet]
			public IEnumerable<ArticleDTO> GetArticles()
			{
				var articles = _context.Articles.ToList();
				var articlesDTO = _mapper.Map<List<ArticleDTO>>(articles);

				return articlesDTO;

			}

			// GET: api/Articles/5
			[HttpGet("{id}")]
			public async Task<ActionResult<ArticleDTO>> GetArticles([FromRoute] Guid id)
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}

				var article = await _context.Articles.FindAsync(id);
				var articleDTO = _mapper.Map<ArticleDTO>(article);

				if (articleDTO == null)
				{
					return NotFound();
				}

				return Ok(articleDTO);
			}

			// PUT: api/Articles/5
			[HttpPut("{id}")]
			public async Task<IActionResult> PutArticles([FromRoute] Guid id, [FromBody] ArticleDTO articles)
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}

				if (id != articles.Id)
				{
					return BadRequest();
				}

				_context.Entry(articles).State = EntityState.Modified;

				try
				{
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ArticlesExists(id))
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

			// POST: api/Articles
			[HttpPost]
			public async Task<IActionResult> PostArticles([FromBody] ArticleDTO articles)
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}

				var holder = _mapper.Map<ArticleModel>(articles);
				_context.Articles.Add(holder);
				await _context.SaveChangesAsync();

				return CreatedAtAction("GetArticles", new { id = articles.Id }, articles);
			}

			// DELETE: api/Articles/5
			[HttpDelete("{id}")]
			public async Task<IActionResult> DeleteArticles([FromRoute] Guid id)
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}

				var articles = await _context.Articles.FindAsync(id);
				if (articles == null)
				{
					return NotFound();
				}

				_context.Articles.Remove(articles);
				await _context.SaveChangesAsync();

				return Ok(articles);
			}

			private bool ArticlesExists(Guid id)
			{
				return _context.Articles.Any(e => e.Id == id);
			}
		}
	}
}
