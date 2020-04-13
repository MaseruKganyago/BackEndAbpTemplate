using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TransportWiseBackEnd.FuelWise.Dto;
using TransportWiseBackEnd.FuelWise;

namespace TransportWiseBackEnd.Controllers
{
	[Route("api/[controller]/[action]")]
	public class FuelwiseController : TransportWiseBackEndControllerBase
	{
		private readonly IFuelwiseAppService _fuelwiseAppService;
		private readonly IMapper _mapper;

		public FuelwiseController(IFuelwiseAppService fuelwiseAppService, IMapper mapper)
		{
			_fuelwiseAppService = fuelwiseAppService;
			_mapper = mapper;
		}

		// GET: api/FuelWises
		[HttpGet]
		[Authorize]
		public IEnumerable<FuelwiseDTO> GetFuelWise()
		{
			var tips = _fuelwiseAppService.GetAll();
			var tipsDTO = _mapper.Map<List<FuelwiseDTO>>(tips);
			return tipsDTO;
		}

		// GET: api/FuelWises/5
		[HttpGet("{Id}")]
		[Authorize]
		public async Task<ActionResult<FuelwiseDTO>> GetFuelWise([FromRoute] int Id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var tip = await _fuelwiseAppService.GetFuelwise(Id);
			var tipDTO = _mapper.Map<FuelwiseDTO>(tip);

			if (tip == null)
			{
				return NotFound();
			}

			return Ok(tipDTO);
		}

		// PUT: api/FuelWises/5
		[HttpPut("{Id}")]
		[Authorize]
		public async Task<IActionResult> PutFuelWise([FromRoute] int Id, [FromBody] FuelwiseDTO fuelWise)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (Id != fuelWise.Id)
			{
				return BadRequest();
			}

			var newTip = await _fuelwiseAppService.PutFuelwise(Id, fuelWise);
			var newTipDTO = ObjectMapper.Map<FuelwiseDTO>(newTip);

			return Ok(newTipDTO);
		}

		// POST: api/FuelWises
		[HttpPost]
		[Authorize]
		public async Task<IActionResult> PostFuelWise([FromBody] FuelwiseDTO fuelWise)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var newTip = await _fuelwiseAppService.PostFuelwise(fuelWise);

			return Ok(newTip);
		}

		// DELETE: api/FuelWises/5
		[HttpDelete("{Id}")]
		[Authorize]
		public async Task<IActionResult> DeleteFuelWise([FromRoute] int Id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var deletedTip = await _fuelwiseAppService.DeleteFuelwise(Id);
			if (deletedTip == null)
			{
				return NotFound("Failed to delete, Author not found or invalid authorId.");
			}

			return Ok(deletedTip);
		}
	}
}
