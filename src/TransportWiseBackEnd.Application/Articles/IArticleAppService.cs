using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TransportWiseBackEnd.Articles.Dto;
using Abp.Application.Services;

namespace TransportWiseBackEnd.Articles
{
	public interface IArticleAppService: IApplicationService
	{
		Task<List<ArticleDTO>> GetAll();
		Task<ArticleDTO> GetArticle(int Id);
		Task<ArticleDTO> PostArticle(ArticleDTO article);
		Task<ArticleDTO> PutArticle(int Id, ArticleDTO article);
		Task<ArticleDTO> DeleteArticle(int Id);
	}
}
