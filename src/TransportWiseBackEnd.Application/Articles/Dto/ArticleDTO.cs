using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;


namespace TransportWiseBackEnd.Articles.Dto
{

	public class ArticleDTO: AuditedEntityDto
	{
		public string Title { get; set; }
		public string Content { get; set; }
		public string UserName { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
	}
}
