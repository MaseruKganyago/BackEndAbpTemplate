using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace TransportWiseBackEnd.FileStorage.Dto
{
	public class FilestorageDTO: AuditedEntityDto
	{
		public string Name { get; set; }
		public string FilePath { get; set; }
		public string ContentType { get; set; }
	}
}
