using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using TransportWiseBackEnd.FileStorage.Dto;

namespace TransportWiseBackEnd.FileStorage
{
	public interface IFileAppService: IApplicationService
	{
		Task<List<FilestorageDTO>> GetAll();
		Task<FilestorageDTO> GetFile(int Id);
		Task<FilestorageDTO> PutFile(int Id, FilestorageDTO file);
		Task<FilestorageDTO> PostFile(FilestorageDTO file);
		Task<FilestorageDTO> DeleteFile(int Id);
	}
}
