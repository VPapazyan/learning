using Entity_CodeFirst.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_CodeFirst.DAL
{
    public class InventoryService
    {
        string conn = "Server=.\\SQLExpress;Database=SalesDB;Trusted_Connection=true";

        public async Task CreateInventoryAsync(Inventory inventory)
        {
            var query = $"Insert Into Inventories Values({inventory.Name}, {inventory.Price})";

            using(var sqlConnection = new SqlConnection(conn))
            {
                var sqlCommand = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();
                await sqlCommand.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateInventoryAsync(Inventory inventory)
        {
            var query = $"Update Inventories Set Name = {inventory.Name}, Price = {inventory.Price}) Where Id = {inventory.Id}";

            using (var sqlConnection = new SqlConnection(conn))
            {
                var sqlCommand = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();
                await sqlCommand.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteInventoryAsync(int inventoryId)
        {
            var query = $"Delete From Inventories Where Id = {inventoryId}";

            using (var sqlConnection = new SqlConnection(conn))
            {
                var sqlCommand = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();
                await sqlCommand.ExecuteNonQueryAsync();
            }
        }

        public async Task<List<Inventory>> GetAllInventoriesAsync()
        {
            var result = new List<Inventory>();
            var query = $"Select * Inventories";

            using (var sqlConnection = new SqlConnection(conn))
            {
                var sqlCommand = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();
                var reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    result.Add(new Inventory
                    {
                        Name = reader.GetString(1),
                        Price = reader.GetInt32(2)
                    });
                }
            }

            return result;
        }

        public async Task<Inventory> GetInventoryAsync(int inventoryId)
        {
            Inventory result = null;
            var query = $"Select * From Inventories Where Id = {inventoryId}";

            using (var sqlConnection = new SqlConnection(conn))
            {
                var sqlCommand = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();
                var reader = await sqlCommand.ExecuteReaderAsync();

                result = new Inventory
                {
                    Name = reader.GetString(1),
                    Price = reader.GetInt32(2)
                };
            }

            return result;
        }
    }
}
