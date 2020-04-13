using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TransportWiseBackEnd.Domain;

namespace TransportWiseBackEnd.Articles.Dto
{
	public class ArticleMapProfile: Profile
	{
		public ArticleMapProfile()
		{
			CreateMap<Article, ArticleDTO>();
			CreateMap<Article, ArticleDTO>()
				.ForMember(dest =>
				dest.Title,
				opt => opt.MapFrom(src => src.Title))
				.ForMember(dest =>
				dest.Description,
				opt => opt.MapFrom(src => src.Description))
				.ForMember(dest =>
				dest.Content,
				opt => opt.MapFrom(src => src.Content))
				.ForMember(dest =>
				dest.Image,
				opt => opt.MapFrom(src => src.Image));

			CreateMap<ArticleDTO, Article>();
			CreateMap<ArticleDTO, Article>()
				.ForMember(dest =>
				dest.Title,
				opt => opt.MapFrom(src => src.Title))
				.ForMember(dest =>
				dest.Description,
				opt => opt.MapFrom(src => src.Description))
				.ForMember(dest =>
				dest.Content,
				opt => opt.MapFrom(src => src.Content))
				.ForMember(dest =>
				dest.Image,
				opt => opt.MapFrom(src => src.Image));

		}
	}
}
