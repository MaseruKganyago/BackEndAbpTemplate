using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TransportWiseBackEnd.Domain;
using TransportWiseBackEnd.FuelWise.Dto;

namespace TransportWiseBackEnd.Tasks.FuelWise.Dto
{
	public class FuelwiseMapProfile: Profile
	{
		public FuelwiseMapProfile()
		{
			CreateMap<Fuelwise, FuelwiseDTO>();
			CreateMap<Fuelwise, FuelwiseDTO>()
				.ForMember(dest =>
				dest.Title,
				opt => opt.MapFrom(src => src.Title))
				 .ForMember(dest =>
				 dest.Body,
				 opt => opt.MapFrom(src => src.Body));

			CreateMap<FuelwiseDTO, Fuelwise>();
			CreateMap<FuelwiseDTO, Fuelwise>()
				.ForMember(dest =>
				dest.Title,
				opt => opt.MapFrom(src => src.Title))
				 .ForMember(dest =>
				 dest.Body,
				 opt => opt.MapFrom(src => src.Body));
		}
	}
}
