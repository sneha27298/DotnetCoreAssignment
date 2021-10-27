using DotnetCoreAssignment.Models;
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
        public int Delete(ProductModel product)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public int Insert(ProductModel product)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
