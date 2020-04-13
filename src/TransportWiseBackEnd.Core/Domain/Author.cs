using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace TransportWiseBackEnd.Domain
{
	[Table("Authors")]
	public class Author : AuditedEntity
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string Surname { get; set; }
		public string Jobtitle { get; set; }
		[Required]
		public string Driverexperience { get; set; }

	}
}
