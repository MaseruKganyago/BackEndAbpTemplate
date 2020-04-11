using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace TransportWiseBackEnd.Models.Author.DTO
{
	public class AuthorMapProfile: Profile
	{
		AuthorMapProfile()
		{
			CreateMap<AuthorModel, AuthorDTO>();
			CreateMap<AuthorModel, AuthorDTO>()
				.ForMember(dest =>
				dest.Name,
				opt => opt.MapFrom(src => src.Name))
				.ForMember(dest =>
				dest.Surname,
				opt => opt.MapFrom(src => src.Surname))
				.ForMember(dest =>
				dest.JobTitle,
				opt => opt.MapFrom(src => src.JobTitle))
				.ForMember(dest =>
				dest.DriverExperience,
				opt => opt.MapFrom(src => src.DriverExperience));

			CreateMap<AuthorDTO, AuthorModel>();
			CreateMap<AuthorDTO, AuthorModel>()
				.ForMember(dest =>
				dest.Name,
				opt => opt.MapFrom(src => src.Name))
				.ForMember(dest =>
				dest.Surname,
				opt => opt.MapFrom(src => src.Surname))
				.ForMember(dest =>
				dest.JobTitle,
				opt => opt.MapFrom(src => src.JobTitle))
				.ForMember(dest =>
				dest.DriverExperience,
				opt => opt.MapFrom(src => src.DriverExperience));
		}
	}
}
