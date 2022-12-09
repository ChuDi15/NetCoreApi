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
    public class ClaimsRepository : IClaimsRepository
    {
        private readonly MySqlConfiguration _connectionString;
        public ClaimsRepository(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<IEnumerable<ClaimsVID>> GetAllClaims()
        {
            var db = dbConnection();
            var sql = @"SELECT claims.id,description,status,date,vehicle_id FROM claims INNER JOIN vehicles ON claims.vehicle_id=vehicles.id";

            return await db.QueryAsync<ClaimsVID>(sql, new { });
        }

        public async Task<ClaimsVID> GetAllClaimsVehicle(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT claims.id,description,status,date,vehicle_id FROM claims INNER JOIN vehicles ON claims.vehicle_id=vehicles.id WHERE vehicle_id=@Id";

            return await db.QueryFirstOrDefaultAsync<ClaimsVID>(sql, new { Id = id });
        }

        public async Task<bool> InsertClaim(Claims claim)
        {
            var db = dbConnection();
            var sql = @" INSERT INTO claims (description, status, date, vehicle_id ) VALUES (@Description, @Status, @Date, @Vehicle_Id)";

            var result = await db.ExecuteAsync(sql, new
            { claim.Description, claim.Status, claim.Date, claim.Vehicle_Id });

            return result > 0;
        }

        public async Task<bool> UpdateClaim(Claims claim)
        {
            
            var db = dbConnection(); 
            var sql = @" UPDATE claims 
                        SET 
                            description = @Description,
                            status = @Status,
                            date = @Date,
                            vehicle_id = @Vehicle_Id
                        WHERE id = @Id;";

            var result = await db.ExecuteAsync(sql, new
            {claim.Id, claim.Description, claim.Status, claim.Date, claim.Vehicle_Id });

            return result > 0;
        }
    }
}
