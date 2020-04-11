using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace TransportWiseBackEnd.Models.FileStorage
{
	class FileStorageMapProfile: Profile
	{
		public FileStorageMapProfile()
		{
			CreateMap<FileStorageModel, FileStorageDTO>()
				.ForMember(dest =>
				dest.Name,
				opt => opt.MapFrom(src => src.Name))
				.ForMember(dest =>
				dest.FilePath,
				opt => opt.MapFrom(src => src.FilePath))
				.ForMember(dest =>
				dest.ContentType,
				opt => opt.MapFrom(src => src.ContentType));
		}
	}
}
