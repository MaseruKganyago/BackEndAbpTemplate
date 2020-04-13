using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TransportWiseBackEnd.Domain;

namespace TransportWiseBackEnd.FileStorage.Dto
{
	class FileStorageMapProfile : Profile
	{
		public FileStorageMapProfile()
		{
			CreateMap<Filestorage, FilestorageDTO>()
				.ForMember(dest =>
				dest.Name,
				opt => opt.MapFrom(src => src.Filename))
				.ForMember(dest =>
				dest.FilePath,
				opt => opt.MapFrom(src => src.Filepath))
				.ForMember(dest =>
				dest.ContentType,
				opt => opt.MapFrom(src => src.Contentstype));
		}
	}
}
