﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportWiseBackEnd.Models
{
	public class ArticleModel
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public string UserName { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
	}
}
