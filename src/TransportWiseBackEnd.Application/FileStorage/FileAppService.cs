using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Timing;
using Microsoft.EntityFrameworkCore;
using TransportWiseBackEnd.Domain;
using TransportWiseBackEnd.FileStorage.Dto;

namespace TransportWiseBackEnd.FileStorage
{
	public class FileAppService: ApplicationService, IFileAppService
	{
		private readonly IRepository<Filestorage> _fileRepository;

		public FileAppService(IRepository<Filestorage> fileRepository)
		{
			_fileRepository = fileRepository;
		}

		public async Task<List<FilestorageDTO>> GetAll()
		{
			var files = await _fileRepository
				.GetAll()
				.OrderByDescending(t => t.CreationTime)
				.ToListAsync();

			return new List<FilestorageDTO>(
				ObjectMapper.Map<List<FilestorageDTO>>(files)
				);
		}

		public async Task<FilestorageDTO> GetFile(int Id)
		{
			var file = await _fileRepository
				.GetAsync(Id);

			var holder = ObjectMapper.Map<FilestorageDTO>(file);

			return holder;
		}

		public async Task<FilestorageDTO> PutFile(int Id, FilestorageDTO file)
		{
			var fileOld = await _fileRepository.GetAsync(Id);

			fileOld.Filename = file.Name;
			fileOld.Contentstype = file.ContentType;
			file.LastModificationTime = Clock.Now;

			var updatedHolder = await _fileRepository.UpdateAsync(fileOld);
			var updatedFile = ObjectMapper.Map<FilestorageDTO>(updatedHolder);

			return updatedFile;
		}

		public async Task<FilestorageDTO> PostFile(FilestorageDTO file)
		{
			var _file = ObjectMapper.Map<Filestorage>(file);
			_file.CreationTime = Clock.Now;
			var newFileId = await _fileRepository.InsertAndGetIdAsync(_file);

			var newFileHolder = await _fileRepository.GetAsync(newFileId);
			var newFile = ObjectMapper.Map<FilestorageDTO>(newFileHolder);

			return newFile;
		}

		public async Task<FilestorageDTO> DeleteFile(int Id)
		{
			var file = await _fileRepository.GetAsync(Id);

			if (file != null)
			{
				await _fileRepository.DeleteAsync(file);
				var deleted = ObjectMapper.Map<FilestorageDTO>(file);
				return deleted;
			}
			else
			{
				var failed = ObjectMapper.Map<FilestorageDTO>(file);
				return failed = null;
			}
		}
	}
}
