using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportWiseBackEnd.Controllers;
using TransportWiseBackEnd.Domain;
using TransportWiseBackEnd.EntityFrameworkCore;
using TransportWiseBackEnd.Articles;
using TransportWiseBackEnd.Articles.Dto;

namespace TransportWiseBackEnd.Web.Host.Controllers
{
	[Route("api/[controller]/[action]")]
	public class ArticlesController : TransportWiseBackEndControllerBase
	{

			private readonly IArticleAppService _articleAppService;
			private readonly IMapper _mapper;

			public ArticlesController(IArticleAppService articleAppService, IMapper mapper)
			{
				_articleAppService = articleAppService;
				_mapper = mapper;
			}

			// GET: api/Articles
			[HttpGet]
			[Authorize]
			public IEnumerable<ArticleDTO> GetArticles()
			{
				var articles = _articleAppService.GetAll();
				var articlesDTO = _mapper.Map<List<ArticleDTO>>(articles);

				return articlesDTO;

			}

			// GET: api/Articles/5
			[HttpGet("{Id}")]
			[Authorize]
			public async Task<ActionResult<ArticleDTO>> FetchArticles([FromRoute] int Id)
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}

				var article = await _articleAppService.GetArticle(Id);
				var articleDTO = _mapper.Map<ArticleDTO>(article);

				if (articleDTO == null)
				{
					return NotFound();
				}

				return Ok(articleDTO);
			}

			// PUT: api/Articles/5
			[HttpPut("{Id}")]
			[Authorize]
			public async Task<IActionResult> UpdateArticle([FromRoute] int Id, [FromBody] ArticleDTO articles)
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}

				if (Id != articles.Id)
				{
					return BadRequest();
				}

				var newArticle = await _articleAppService.PutArticle(Id, articles);
				var newArticleDTO = ObjectMapper.Map<ArticleDTO>(newArticle);

				return Ok(newArticleDTO);
			}

			// POST: api/Articles
			[HttpPost]
			[Authorize]
			public async Task<IActionResult> PostArticles([FromBody] ArticleDTO article)
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}

				var result = await _articleAppService.PostArticle(article);

				return Ok(result);
			}

			// DELETE: api/Articles/5
			[HttpDelete("{Id}")]
			[Authorize]
			public async Task<IActionResult> DeleteArticles([FromRoute] int Id)
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}

				var articles = await _articleAppService.DeleteArticle(Id);

				if (articles == null)
				{
					return NotFound("Failed to delete, Author not found or invalid articleId.");
				}

				return Ok(articles);
			}
	}
}
