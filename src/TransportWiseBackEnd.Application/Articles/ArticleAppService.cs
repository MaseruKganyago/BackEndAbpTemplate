using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Repositories;
using System.Threading.Tasks;
using Abp.Application.Services;
using TransportWiseBackEnd.Articles.Dto;
using System.Linq;
using TransportWiseBackEnd.Domain;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Abp.Timing;

namespace TransportWiseBackEnd.Articles
{
	public class ArticleAppService: TransportWiseBackEndAppServiceBase, IArticleAppService
	{
		private readonly IRepository<Article> _articleRepository;

		public ArticleAppService(IRepository<Article> articleRepository)
		{
			_articleRepository = articleRepository;
		}

		public async Task<List<ArticleDTO>> GetAll()
		{
			var article = await _articleRepository
				.GetAll()
				.OrderByDescending(t => t.CreationTime)
				.ToListAsync();
			return new List<ArticleDTO>(
				ObjectMapper.Map<List<ArticleDTO>>(article)
				);
		}

		public async Task<ArticleDTO> GetArticle(int Id)
		{
			var article = await _articleRepository
				.GetAsync(Id);

			var articleDTO = ObjectMapper.Map<ArticleDTO>(article);
			return articleDTO;
		}

		public async Task<ArticleDTO> PostArticle(ArticleDTO article)
		{
			var holder = ObjectMapper.Map<Article>(article);
			var IdHolder = await _articleRepository.InsertAndGetIdAsync(holder);

			var newArticle = await _articleRepository.GetAsync(IdHolder);
			var newArtcleDTO = ObjectMapper.Map<ArticleDTO>(newArticle); 

			return newArtcleDTO;
		}

		public async Task<ArticleDTO> PutArticle(int Id, ArticleDTO newArticle)
		{
			var article = await _articleRepository
				.GetAsync(Id);

			article.Title = newArticle.Title;
			article.Content = newArticle.Content;
			article.LastModificationTime = Clock.Now;

			var results = await _articleRepository.UpdateAsync(article);
			var resultsDto = ObjectMapper.Map<ArticleDTO>(results);

			return resultsDto;
		}

		public async Task<ArticleDTO> DeleteArticle(int Id)
		{
			var article = await _articleRepository
				.GetAsync(Id);

			if (article != null)
			{
				await _articleRepository.DeleteAsync(article);
				var deleted = ObjectMapper.Map<ArticleDTO>(article);
				return deleted;
			}
			else
			{
				var failed = ObjectMapper.Map<ArticleDTO>(article);
				return failed = null;
			}
		}
	}
}
