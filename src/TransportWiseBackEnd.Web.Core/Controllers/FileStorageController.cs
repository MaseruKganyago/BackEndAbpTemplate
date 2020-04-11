using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportWiseBackEnd.EntityFrameworkCore;
using TransportWiseBackEnd.Models;
using TransportWiseBackEnd.Models.FileStorage;

namespace TransportWiseBackEnd.Controllers
{
	[Route("api/[controller]/[action]")]
	public class FileStorageController : TransportWiseBackEndControllerBase
	{
		private readonly TransportWiseBackEndDbContext _context;
		private readonly IMapper _mapper;

		public FileStorageController(TransportWiseBackEndDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		// GET: api/FileStorages
		[HttpGet]
		[Authorize]
		public IEnumerable<FileStorageDTO> GetFileStorage()
		{
			var files = _context.FileStorage.ToList();
			var filesDTO = _mapper.Map<List<FileStorageDTO>>(files);

			return filesDTO;
		}

		// GET: api/FileStorages/5
		[HttpGet("{id}")]
		[Authorize]
		public async Task<ActionResult<FileStorageDTO>> GetFileStorage([FromRoute] Guid id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var file = await _context.FileStorage.FindAsync(id);
			var fileDTO = _mapper.Map<FileStorageDTO>(file);

			if (file == null)
			{
				return NotFound();
			}

			return Ok(file);
		}

		// PUT: api/FileStorages/5
		[HttpPut("{id}")]
		[Authorize]
		public async Task<IActionResult> PutFileStorage([FromRoute] Guid id, [FromBody] FileStorageModel fileStorage)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != fileStorage.Id)
			{
				return BadRequest();
			}

			_context.Entry(fileStorage).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!FileStorageExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/FileStorages
		[HttpPost]
		[Authorize]
		public async Task<IActionResult> PostFileStorage([FromBody] FileStorageModel fileStorage)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			_context.FileStorage.Add(fileStorage);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetFileStorage", new { id = fileStorage.Id }, fileStorage);
		}

		// DELETE: api/FileStorages/5
		[HttpDelete("{id}")]
		[Authorize]
		public async Task<IActionResult> DeleteFileStorage([FromRoute] Guid id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var fileStorage = await _context.FileStorage.FindAsync(id);
			if (fileStorage == null)
			{
				return NotFound();
			}

			_context.FileStorage.Remove(fileStorage);
			await _context.SaveChangesAsync();

			return Ok(fileStorage);
		}

		private bool FileStorageExists(Guid id)
		{
			return _context.FileStorage.Any(e => e.Id == id);
		}
	}
}