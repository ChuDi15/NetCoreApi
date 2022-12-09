using Dapper;
using MySql.Data.MySqlClient;
using NetCoreApiAssesment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApiAssesment.Data.Repositories
{
    public class OwnersRepository : IOwnersRepository
    {
        private readonly MySqlConfiguration _connectionString;
        public OwnersRepository(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<IEnumerable<Owners>> GetAllOwners()
        {
            var db = dbConnection();
            var sql = @" SELECT * FROM owners";

            return await db.QueryAsync<Owners>(sql, new {});
        }

    
      
        public async Task<Owners> GetAllOwnersId(int id)
        {
            var db = dbConnection();
            var sql = @" SELECT * FROM owners WHERE id=@Id";

            return await db.QueryFirstOrDefaultAsync<Owners>(sql, new { });
        }

        public async Task<bool> InsertOwner(Owners owner)
        {
            var db = dbConnection();
            var sql = @" INSERT INTO owners (firstName, lastName, driverLicense) VALUES (@FirstName, @LastName, @DriverLicense)";

            var result = await db.ExecuteAsync(sql, new 
            { owner.FirstName, owner.LastName, owner.DriverLicense});

            return result > 0;
        }

        public async Task<bool> UpdateOwner(Owners owner)
        {
            var db = dbConnection();
            var sql = @" UPDATE owners 
                        SET lastName = @LastName,
                            firstName = @FirstName,
                            driverLicense = @DriverLicense
                        WHERE id = @Id;";

            var result = await db.ExecuteAsync(sql, new
            {owner.Id, owner.FirstName, owner.LastName, owner.DriverLicense });

            return result > 0;
        }


    }
}
