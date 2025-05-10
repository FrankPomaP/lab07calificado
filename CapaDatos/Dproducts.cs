using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class Dproducts
    {
        private string _connectionString = "Server=FRANKPOMA\\SQLEXPRESS;Database=lab07;User Id=user2;Password=123456;TrustServerCertificate=True;Integrated Security=True";

        // Listar todos los productos
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
                                    Name = reader["name"]?.ToString() ?? string.Empty,
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

        // Insertar un nuevo producto
        public void InsertarProducto(Products producto)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("InsertProduct1", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Name", producto.Name);
                        cmd.Parameters.AddWithValue("@Price", producto.Price);
                        cmd.Parameters.AddWithValue("@Stock", producto.Stock);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar el producto en la base de datos.", ex);
                }
            }
        }

        // Actualizar un producto existente
        public void ActualizarProducto(Products producto)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UpdateProduct", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ProductId", producto.ProductId);
                        cmd.Parameters.AddWithValue("@Name", producto.Name);
                        cmd.Parameters.AddWithValue("@Price", producto.Price);
                        cmd.Parameters.AddWithValue("@Stock", producto.Stock);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar el producto en la base de datos.", ex);
                }
            }
        }

        // Eliminación lógica del producto (Active = 0)
        public void EliminarProducto(int productId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DeleteProduct", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ProductId", productId);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar lógicamente el producto.", ex);
                }
            }
        }
    }
}
