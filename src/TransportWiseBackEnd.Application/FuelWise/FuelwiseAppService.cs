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
using TransportWiseBackEnd.FuelWise.Dto;

namespace TransportWiseBackEnd.FuelWise
{
	class FuelwiseAppService: TransportWiseBackEndAppServiceBase, IFuelwiseAppService
	{
		private readonly IRepository<Fuelwise> _fuelwiseRepository;

		public FuelwiseAppService(IRepository<Fuelwise> fuelwiseRepository)
		{
			_fuelwiseRepository = fuelwiseRepository;
		}

		public async Task<List<FuelwiseDTO>> GetAll()
		{
			var fuelwise = await _fuelwiseRepository
				.GetAll()
				.OrderByDescending(t => t.CreationTime)
				.ToListAsync();

			return new List<FuelwiseDTO>(
				ObjectMapper.Map<List<FuelwiseDTO>>(fuelwise)
				);
		}

		public async Task<FuelwiseDTO> GetFuelwise(int Id)
		{
			var fuelwise = await _fuelwiseRepository
				.GetAsync(Id);

			var holder = ObjectMapper.Map<FuelwiseDTO>(fuelwise);

			return holder;
		}

		public async Task<FuelwiseDTO> PostFuelwise(FuelwiseDTO fuelwise)
		{
			var _fuelwise = ObjectMapper.Map<Fuelwise>(fuelwise);
			_fuelwise.CreationTime = Clock.Now;
			var newFuelwiseId = await _fuelwiseRepository.InsertAndGetIdAsync(_fuelwise);

			var newFuelwiseHolder = await _fuelwiseRepository.GetAsync(newFuelwiseId);
			var newFuelwise = ObjectMapper.Map<FuelwiseDTO>(newFuelwiseHolder);

			return newFuelwise;
		}

		public async Task<FuelwiseDTO> PutFuelwise(int Id, FuelwiseDTO fuelwise)
		{
			var fuelwiseOld = await _fuelwiseRepository.GetAsync(Id);

			fuelwiseOld.Title = fuelwise.Title;
			fuelwiseOld.Body = fuelwise.Body;
			fuelwiseOld.LastModificationTime = Clock.Now;

			var updatedHolder = await _fuelwiseRepository.UpdateAsync(fuelwiseOld);
			var updatedFile = ObjectMapper.Map<FuelwiseDTO>(updatedHolder);

			return updatedFile;
		}

		public async Task<FuelwiseDTO> DeleteFuelwise(int Id)
		{
			var fuelwise = await _fuelwiseRepository.GetAsync(Id);

			if (fuelwise != null)
			{
				await _fuelwiseRepository.DeleteAsync(fuelwise);
				var deleted = ObjectMapper.Map<FuelwiseDTO>(fuelwise);
				return deleted;
			}
			else
			{
				var failed = ObjectMapper.Map<FuelwiseDTO>(fuelwise);
				return failed = null;
			}
		}
	}
}
