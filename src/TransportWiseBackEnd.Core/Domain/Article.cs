using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace TransportWiseBackEnd.Domain
{
	[Table("Article")]
	public class Article : AuditedEntity
	{
		[Required]
		public string Title { get; set; }
		[Required]
		public string Content { get; set; }
		[Required]
		public string Username { get; set; }
		[Required]
		public string Description { get; set; }
		public string Image { get; set; }

	}
}
