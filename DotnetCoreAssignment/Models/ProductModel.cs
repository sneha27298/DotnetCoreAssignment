using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreAssignment.Models
{
    public class ProductModel
    {
        [DisplayName("Product Id")]
        public int Id { get; set; }
        [DisplayName("Product Name")]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [DisplayName("Reviews")]
        public string Description { get; set; }
    }
}
