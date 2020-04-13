using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TransportWiseBackEnd.FileStorage;
using TransportWiseBackEnd.FileStorage.Dto;

namespace TransportWiseBackEnd.Controllers
{
	[Route("api/[controller]/[action]")]
	public class FileStorageController : TransportWiseBackEndControllerBase
	{
		private readonly IFileAppService _fileAppService;
		private readonly IMapper _mapper;

		public FileStorageController(IFileAppService fileAppService, IMapper mapper)
		{
			_fileAppService = fileAppService;
			_mapper = mapper;
		}

		// GET: api/FileStorages
		[HttpGet]
		[Authorize]
		public IEnumerable<FilestorageDTO> GetAllFiles()
		{
			var files = _fileAppService.GetAll();
			var filesDTO = _mapper.Map<List<FilestorageDTO>>(files);

			return filesDTO;
		}

		// GET: api/FileStorages/5
		[HttpGet("{Id}")]
		[Authorize]
		public async Task<ActionResult<FilestorageDTO>> GetFile([FromRoute] int Id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var file = await _fileAppService.GetFile(Id);


			if (file == null)
			{
				return NotFound();
			}
			else
			{
				var fileDTO = _mapper.Map<FilestorageDTO>(file);
				return Ok(fileDTO);
			}
		}

		// PUT: api/FileStorages/5
		[HttpPut("{Id}")]
		[Authorize]
		public async Task<IActionResult> PutFileStorage([FromRoute] int Id, [FromBody] FilestorageDTO file)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (Id != file.Id)
			{
				return BadRequest();
			}

			var newArticle = await _fileAppService.PutFile(Id, file);
			var newArticleDTO = ObjectMapper.Map<FilestorageDTO>(newArticle);

			return Ok(newArticleDTO);
		}

		// POST: api/FileStorages
		[HttpPost]
		[Authorize]
		public async Task<IActionResult> PostFileStorage([FromBody] FilestorageDTO file)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var newFile = await _fileAppService.PostFile(file);

			return Ok(newFile);
		}

		// DELETE: api/FileStorages/5
		[HttpDelete("{Id}")]
		[Authorize]
		public async Task<IActionResult> DeleteFile([FromRoute] int Id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var file = await _fileAppService.DeleteFile(Id);
			if (file == null)
			{
				return NotFound("Failed to delete, Author not found or invalid authorId.");
			}

			return Ok(file);
		}
	}
}