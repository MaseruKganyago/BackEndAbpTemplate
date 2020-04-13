using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using TransportWiseBackEnd.FuelWise.Dto;

namespace TransportWiseBackEnd.FuelWise
{
	public interface IFuelwiseAppService: IApplicationService
	{
		Task<List<FuelwiseDTO>> GetAll();
		Task<FuelwiseDTO> GetFuelwise(int Id);
		Task<FuelwiseDTO> PostFuelwise(FuelwiseDTO fuelwise);
		Task<FuelwiseDTO> PutFuelwise(int Id, FuelwiseDTO fuelwise);
		Task<FuelwiseDTO> DeleteFuelwise(int Id);
	}
}
