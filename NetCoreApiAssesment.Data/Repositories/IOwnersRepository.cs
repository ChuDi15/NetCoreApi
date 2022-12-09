using NetCoreApiAssesment.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApiAssesment.Data.Repositories
{
    public interface IOwnersRepository
    {
        Task<IEnumerable<Owners>> GetAllOwners();
        Task<Owners> GetAllOwnersId(int id);

        Task<bool> InsertOwner(Owners owner);
        Task<bool> UpdateOwner(Owners owner);
    }
}
