using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportWiseBackEnd.Models
{
	public class FileStorageModel
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string FilePath { get; set; }
		public string ContentType { get; set; }
	}
}
