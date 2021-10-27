using Amazon.ECS.Model;
using DotnetCoreAssignment.Models;
using MathNet.Numerics;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreAssignment.Services
{
    
    public class ProductsDb : ProductDataService
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assignment;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private string parameterName;

        public int Delete(ProductModel product)
        {
            int newId = -1;
            string sqlQuery = "DELETE FROM dbo.Products WHERE Id = @Id";
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                SqlCommand sqlcom = new SqlCommand(sqlQuery, sqlcon);
                sqlcom.Parameters.AddWithValue("@Id", product.Id);

                try
                {
                    sqlcon.Open();
                    newId = Convert.ToInt32(sqlcom.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return newId;
        }

        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> foundProducts = new List<ProductModel>();
            string sqlQuery = "SELECT * FROM dbo.Products";
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                SqlCommand sqlcom = new SqlCommand(sqlQuery, sqlcon);
                try
                {
                    sqlcon.Open();
                    SqlDataReader reader = sqlcom.ExecuteReader();
                    while(reader.Read())
                    {
                        foundProducts.Add(new ProductModel { Id = (int)reader[0], Name = (string)reader[1], Price = (decimal)reader[2], Description = (string)reader[3] });
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return foundProducts;
        }

        public ProductModel GetProductById(int id)
        {
            ProductModel foundProduct = null;
            string sqlQuery = "SELECT * FROM dbo.Products WHERE Id = @Id";
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                SqlCommand sqlcom = new SqlCommand(sqlQuery, sqlcon);
                sqlcom.Parameters.AddWithValue("@Id", id);

                try
                {
                    sqlcon.Open();
                    SqlDataReader reader = sqlcom.ExecuteReader();
                    while (reader.Read())
                    {
                        foundProduct = new ProductModel { Id = (int)reader[0], Name = (string)reader[1], Price = (decimal)reader[2], Description = (string)reader[3] } ;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return foundProduct;
        }

        public int Insert(ProductModel product)
        {
            int newId = -1;
            string sqlQuery = "INSERT INTO dbo.Products VALUES (@Name, @Price, @Description)";
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                SqlCommand sqlcom = new SqlCommand(sqlQuery, sqlcon);
                sqlcom.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 100).Value = product.Name;
                sqlcom.Parameters.Add("@Price", System.Data.SqlDbType.Decimal, 100).Value = product.Price;
                sqlcom.Parameters.Add("@Description", System.Data.SqlDbType.VarChar, 500).Value = product.Description;
                sqlcom.Parameters.AddWithValue("@Id", product.Id);

                try
                {
                    sqlcon.Open();
                    newId = sqlcom.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return newId;
        }

        public List<ProductModel> SearchProducts(string searchTerm)
        {
            List<ProductModel> foundProducts = new List<ProductModel>();
            string sqlQuery = "SELECT * FROM dbo.Products WHERE Name LIKE @Name";
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                SqlCommand sqlcom = new SqlCommand(sqlQuery, sqlcon);
                sqlcom.Parameters.AddWithValue("@Name", '%' + searchTerm + '%');

                try
                {
                    sqlcon.Open();
                    SqlDataReader reader = sqlcom.ExecuteReader();
                    while (reader.Read())
                    {
                        foundProducts.Add(new ProductModel { Id = (int)reader[0], Name = (string)reader[1], Price = (decimal)reader[2], Description = (string)reader[3] });
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return foundProducts;
        }

        public int Update(ProductModel product)
        {
            int newId = -1;
            string sqlQuery = "UPDATE dbo.Products SET Name = @Name, Price = @Price, Description = @Description WHERE Id = @Id";
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                SqlCommand sqlcom = new SqlCommand(sqlQuery, sqlcon);
                sqlcom.Parameters.AddWithValue("@Name", product.Name);
                sqlcom.Parameters.AddWithValue("@Price", product.Price);
                sqlcom.Parameters.AddWithValue("@Description", product.Description);
                sqlcom.Parameters.AddWithValue("@Id", product.Id);

                try
                {
                    sqlcon.Open();
                    newId = Convert.ToInt32(sqlcom.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return newId;
        }
    }
}
