using NetCoreApiAssesment.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApiAssesment.Data.Repositories
{
    public interface IVehiclesRepository
    {

        Task<IEnumerable<VehiclesOWID>> GetAllVehicles();
        Task<VehiclesOWID> GetAllVehiclesOwner(int id);

        Task<bool> InsertVehicle(Vehicles vehicle);
        Task<bool> UpdateVehicle(Vehicles vehicle);
    }
}
