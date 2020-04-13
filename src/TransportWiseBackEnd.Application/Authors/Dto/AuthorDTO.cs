using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace TransportWiseBackEnd.Authors.Dto
{
	public class AuthorDTO: AuditedEntityDto
	{
			public string Name { get; set; }
			public string Surname { get; set; }
			public string JobTitle { get; set; }
			public string DriverExperience { get; set; }
	}
}
