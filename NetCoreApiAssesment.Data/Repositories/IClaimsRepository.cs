using NetCoreApiAssesment.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApiAssesment.Data.Repositories
{
    public interface IClaimsRepository
    {

        Task<IEnumerable<ClaimsVID>> GetAllClaims();
        Task<ClaimsVID> GetAllClaimsVehicle(int id_vehicle);

        Task<bool> InsertClaim(Claims claim);
        Task<bool> UpdateClaim(Claims claim);
    }


}
