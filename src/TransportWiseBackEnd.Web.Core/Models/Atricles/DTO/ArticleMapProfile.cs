using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace TransportWiseBackEnd.Models.Articles.DTO
{
	public class ArticleMapProfile: Profile
	{
		public ArticleMapProfile()
		{
			CreateMap<ArticleModel, ArticleDTO>();
			CreateMap<ArticleModel, ArticleDTO>()
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

			CreateMap<ArticleDTO, ArticleModel>();
			CreateMap<ArticleDTO, ArticleModel>()
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
