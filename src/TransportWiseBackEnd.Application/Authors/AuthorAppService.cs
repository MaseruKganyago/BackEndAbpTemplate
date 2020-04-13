using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Timing;
using Microsoft.EntityFrameworkCore;
using TransportWiseBackEnd.Domain;
using TransportWiseBackEnd.Authors.Dto;

namespace TransportWiseBackEnd.Authors
{
	public class AuthorAppService: TransportWiseBackEndAppServiceBase, IAuthorAppService
	{
		private readonly IRepository<Author> _authorRepository;

		public AuthorAppService(IRepository<Author> authorRepository)
		{
			_authorRepository = authorRepository;
		}

		public async Task<List<AuthorDTO>> GetAll()
		{
			var author = await _authorRepository
				.GetAll()
				.OrderByDescending(t => t.CreationTime)
				.ToListAsync();

			return new List<AuthorDTO>(
				ObjectMapper.Map<List<AuthorDTO>>(author)
				);
		}

		public async Task<AuthorDTO> GetAuthor(int Id)
		{
			var author = await _authorRepository
				.GetAsync(Id);

			var holder = ObjectMapper.Map<AuthorDTO>(author);

			return holder;
		}

		public async Task<AuthorDTO> PostAuthor(AuthorDTO author)
		{
			var _author = ObjectMapper.Map<Author>(author);
			_author.CreationTime = Clock.Now;
			var newAuthorId = await _authorRepository.InsertAndGetIdAsync(_author);

			var newAuthorHolder = await _authorRepository.GetAsync(newAuthorId);
			var newAuthor = ObjectMapper.Map<AuthorDTO>(newAuthorHolder);

			return newAuthor;
		}

		public async Task<AuthorDTO> PutAuthor(int Id, AuthorDTO author)
		{
			var authorOld = await _authorRepository.GetAsync(Id);

			authorOld.Name = author.Name;
			authorOld.Surname = author.Surname;
			authorOld.Jobtitle = author.JobTitle;
			authorOld.Driverexperience = author.DriverExperience;
			authorOld.LastModificationTime = Clock.Now;

			var holder = await _authorRepository.UpdateAsync(authorOld);
			var newAuthor = ObjectMapper.Map<AuthorDTO>(holder);

			return newAuthor;
		}

		public async Task<AuthorDTO> DeleteAuthor(int Id)
		{
			var author = await _authorRepository.GetAsync(Id);

			if (author != null)
			{
				await _authorRepository.DeleteAsync(author);
				var deleted = ObjectMapper.Map<AuthorDTO>(author);
				return deleted;
			}
			else {
				var failed = ObjectMapper.Map<AuthorDTO>(author);
				return failed = null;
			} 
		}
	}
}
