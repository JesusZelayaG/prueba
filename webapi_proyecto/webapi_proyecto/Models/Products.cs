using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_proyecto.Models
{
    public class Products
    {
        public string IdProduct { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public double ProductPrice { get; set; }
        public string ProductCategory { get; set; }
    }
}
