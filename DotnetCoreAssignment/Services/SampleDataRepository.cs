using Bogus;
using DotnetCoreAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreAssignment.Services
{
    public class SampleDataRepository : ProductDataService
    {
        static List<ProductModel> productsList = new List<ProductModel>();
        public int Delete(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> GetAllProducts()
        {
            if(productsList.Count == 0) {
                productsList.Add(new ProductModel { Id = 1, Name = "Mouse Pad", Price = 500, Description = "This is a mouse" });
                productsList.Add(new ProductModel { Id = 2, Name = "Camera", Price = 900, Description = "This is a Camera" });
                productsList.Add(new ProductModel { Id = 3, Name = "Laptop", Price = 5000, Description = "This is a Laptop" });

                for (int i = 0; i < 100; i++)
                {
                    productsList.Add(new Faker<ProductModel>()
                        .RuleFor(p => p.Id, i + 4)
                        .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                        .RuleFor(p => p.Price, f => f.Random.Decimal(100))
                        .RuleFor(p => p.Description, f => f.Rant.Review())
                        );
                }

            }
            
            return productsList;
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
            throw new NotImplementedException();
        }

        public int Update(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
