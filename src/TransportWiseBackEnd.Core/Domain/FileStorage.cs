using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace TransportWiseBackEnd.Domain
{
	[Table("FileStorage")]
	public class Filestorage: AuditedEntity
	{
		[Required]
		public string Filename { get; set; }
		[Required]
		public string Filepath { get; set; }
		[Required]
		public string Contentstype { get; set; }
	}
}
