using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportWiseBackEnd.Models
{
	public class AuthorModel
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string JobTitle { get; set; }
		public string DriverExperience { get; set; }

	}
}
