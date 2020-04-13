using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using TransportWiseBackEnd.Authors.Dto;

namespace TransportWiseBackEnd.Authors
{
	public interface IAuthorAppService: IApplicationService
	{
		Task<List<AuthorDTO>> GetAll();
		Task<AuthorDTO> GetAuthor(int Id);
		Task<AuthorDTO> PostAuthor(AuthorDTO author);
		Task<AuthorDTO> PutAuthor(int Id, AuthorDTO author);
		Task<AuthorDTO> DeleteAuthor(int Id);
	}
}
