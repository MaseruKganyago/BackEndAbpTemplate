using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportWiseBackEnd.Models
{
	public class FuelWiseModel
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Body { get; set; }
		public Guid AuthorId { get; set; }
	}
}
