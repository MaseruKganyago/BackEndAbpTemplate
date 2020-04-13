using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace TransportWiseBackEnd.Domain
{
	[Table("FuelWise")]
	public class Fuelwise: AuditedEntity
	{
		[Required]
		public string Title { get; set; }
		[Required]
		public string Body { get; set; }
	}
}
