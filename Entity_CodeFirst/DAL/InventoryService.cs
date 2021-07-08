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
        public async Task CreateInventoryAsync(Inventory inventory)
        {
            var conn = "Server=.\\SQLExpress;Database=SalesDB;Trusted_Connection=true";
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
            var conn = "Server=.\\SQLExpress;Database=SalesDB;Trusted_Connection=true";
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
            var conn = "Server=.\\SQLExpress;Database=SalesDB;Trusted_Connection=true";
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
            var conn = "Server=.\\SQLExpress;Database=SalesDB;Trusted_Connection=true";
            var query = $"Delete * Inventories";

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

        public async Task<Inventory> GetInventoryAsync()
        {
            Inventory result = null;
            var conn = "Server=.\\SQLExpress;Database=SalesDB;Trusted_Connection=true";
            var query = $"Delete * Inventories";

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
