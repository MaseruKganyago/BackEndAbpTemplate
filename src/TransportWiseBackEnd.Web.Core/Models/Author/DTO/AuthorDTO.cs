using System;
using System.Collections.Generic;
using System.Text;

namespace TransportWiseBackEnd.Models.Author.DTO
{
	public class AuthorDTO
	{
			public Guid Id { get; set; }
			public string Name { get; set; }
			public string Surname { get; set; }
			public string JobTitle { get; set; }
			public string DriverExperience { get; set; }
	}
}
