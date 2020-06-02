using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Model.ViewModels
{
    public class ProductViewModel
    {
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Quantity { get; set; }
        public string State { get; set; }
        public int CreatedBy { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}