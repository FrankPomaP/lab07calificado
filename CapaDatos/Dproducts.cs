using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class Dproducts
    {
        private string _connectionString = "Server=FRANKPOMA\\SQLEXPRESS;Database=lab07;User Id=user2;Password=123456;TrustServerCertificate=True;Integrated Security=True";

        public List<Products> ListarProductos()
        {
            var productos = new List<Products>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("GetAllProducts", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var producto = new Products
                                {
                                    ProductId = Convert.ToInt32(reader["product_id"]),
                                    Name = reader["name"]?.ToString() ?? string.Empty, // Fix for CS8601
                                    Price = Convert.ToDecimal(reader["price"]),
                                    Stock = Convert.ToInt32(reader["stock"]),
                                    Active = Convert.ToBoolean(reader["active"])
                                };

                                productos.Add(producto);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar productos en la base de datos.", ex);
                }
            }

            return productos;
        }
    }
}
