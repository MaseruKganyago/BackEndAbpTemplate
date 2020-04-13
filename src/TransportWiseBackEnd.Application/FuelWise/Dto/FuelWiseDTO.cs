using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace TransportWiseBackEnd.FuelWise.Dto
{
	public class FuelwiseDTO: AuditedEntityDto
	{
		public string Title { get; set; }
		public string Body { get; set; }
	}
}
