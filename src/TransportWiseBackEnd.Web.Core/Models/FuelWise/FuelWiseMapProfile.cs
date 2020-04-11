using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace TransportWiseBackEnd.Models.FuelWise
{
	public class FuelWiseMapProfile: Profile
	{
		public FuelWiseMapProfile()
		{
			CreateMap<FuelWiseModel, FuelWiseDTO>();
			CreateMap<FuelWiseModel, FuelWiseDTO>()
				.ForMember(dest =>
				dest.Title,
				opt => opt.MapFrom(src => src.Title))
				 .ForMember(dest =>
				 dest.Body,
				 opt => opt.MapFrom(src => src.Body));

			CreateMap<FuelWiseDTO, FuelWiseModel>();
			CreateMap<FuelWiseDTO, FuelWiseModel>()
				.ForMember(dest =>
				dest.Title,
				opt => opt.MapFrom(src => src.Title))
				 .ForMember(dest =>
				 dest.Body,
				 opt => opt.MapFrom(src => src.Body));
		}
	}
}
