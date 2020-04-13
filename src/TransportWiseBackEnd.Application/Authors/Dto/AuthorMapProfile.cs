using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TransportWiseBackEnd.Domain;

namespace TransportWiseBackEnd.Authors.Dto
{
	public class AuthorMapProfile : Profile
	{
		AuthorMapProfile()
		{
			CreateMap<Author, AuthorDTO>();
			CreateMap<Author, AuthorDTO>()
				.ForMember(dest =>
				dest.Name,
				opt => opt.MapFrom(src => src.Name))
				.ForMember(dest =>
				dest.Surname,
				opt => opt.MapFrom(src => src.Surname))
				.ForMember(dest =>
				dest.JobTitle,
				opt => opt.MapFrom(src => src.Jobtitle))
				.ForMember(dest =>
				dest.DriverExperience,
				opt => opt.MapFrom(src => src.Driverexperience));

			CreateMap<AuthorDTO, Author>();
			CreateMap<AuthorDTO, Author>()
				.ForMember(dest =>
				dest.Name,
				opt => opt.MapFrom(src => src.Name))
				.ForMember(dest =>
				dest.Surname,
				opt => opt.MapFrom(src => src.Surname))
				.ForMember(dest =>
				dest.Jobtitle,
				opt => opt.MapFrom(src => src.JobTitle))
				.ForMember(dest =>
				dest.Driverexperience,
				opt => opt.MapFrom(src => src.DriverExperience));
		}
	}
}
