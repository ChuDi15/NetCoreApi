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
    public class VehiclesRepository : IVehiclesRepository
    {
        private readonly MySqlConfiguration _connectionString;
        public VehiclesRepository(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<VehiclesOWID>> GetAllVehicles()
        {
            var db = dbConnection();
            var sql = @"SELECT vehicles.id,brand,vin,color,year,owner_id FROM vehicles INNER JOIN owners ON vehicles.owner_id=owners.id ";

            return await db.QueryAsync<VehiclesOWID>(sql, new { });
        }

        public async Task<VehiclesOWID> GetAllVehiclesOwner(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT vehicles.id,brand,vin,color,year,owner_id FROM vehicles INNER JOIN owners ON vehicles.owner_id=owners.id WHERE owners.id=@Id";

            return await db.QueryFirstOrDefaultAsync<VehiclesOWID>(sql, new {Id = id });
        }

        public async Task<bool> InsertVehicle(Vehicles vehicle)
        {
            var db = dbConnection();
            var sql = @" INSERT INTO vehicles (brand, vin, color, year, owner_id ) VALUES (@Brand, @Vin, @Color, @Year, @Owner_id)";

            var result = await db.ExecuteAsync(sql, new
            { vehicle.Brand, vehicle.Vin, vehicle.Color, vehicle.Year, vehicle.Owner_id });

            return result > 0;
        }

        public async Task<bool> UpdateVehicle(Vehicles vehicle)
        {
            
            var db = dbConnection(); 
            var sql = @" UPDATE vehicles 
                        SET brand = @Brand,
                            vin = @Vin,
                            color = @Color,
                            year = @Year,
                            owner_id = @Owner_id
                        WHERE id = @Id;";

            var result = await db.ExecuteAsync(sql, new
            {vehicle.Id, vehicle.Brand, vehicle.Vin, vehicle.Color, vehicle.Year, vehicle.Owner_id });

            return result > 0;
        }
    }
}
