using AutoMapper;
using DataAccess.Interfaces;
using DataAccess.Model;
using DataAccess.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMapper _mapper;
        private AxaTestEntities _dbContext;
        public ProductRepository(IMapper mapper) {
            _mapper = mapper;
        }

        public ProductViewModel Create(ProductViewModel pvm)
        {
            var result = 0;
            pvm.State = pvm.State.Equals("Available") ? "true" : "false";
            var prod = _mapper.Map<ProductViewModel, Product>(pvm);
            prod.CreationDate = DateTime.Now;

            using (_dbContext = new AxaTestEntities())
            {
                _dbContext.Products.Add(prod);
                result = _dbContext.SaveChanges();
            }
            return result > 0 ? pvm : null;
        }

        public bool Delete(ProductViewModel pvm)
        {
            var result = 0;
            //var prod = _mapper.Map<ProductViewModel, Product>(pvm);
            //prod.Categories = null;
            using (_dbContext = new AxaTestEntities())
            {
                var productIdParameter = new SqlParameter("@ProductId", pvm.IdProduct);

                result = _dbContext.Database
                                .ExecuteSqlCommand("exec dbo.DeleteProductbyId @ProductId", productIdParameter);
            }
            return result > 0 ? true : false;
        }

        public ProductViewModel Update(ProductViewModel pvm)
        {
            var s = 0;
            using (_dbContext = new AxaTestEntities())
            {
                var result = _dbContext.Products.SingleOrDefault(p => p.IdProduct == pvm.IdProduct);
                if (result != null)
                {
                    result.Name = pvm.Name;
                    result.Description = pvm.Description;
                    result.Quantity = Convert.ToByte(pvm.Quantity);
                    result.State = pvm.State.Equals("Available") ? true : false;
                    result.UnitPrice = pvm.Price;
                    s = _dbContext.SaveChanges();
                }
            }
            return s > 0 ? pvm : null;
        }

        public IEnumerable<ProductViewModel> GetProducts()
        {
            IEnumerable<ProductViewModel> lpvm;
            using (_dbContext = new AxaTestEntities())
            {
                var lp = _dbContext.Products.ToList();
                lpvm = _mapper.Map<List<Product>, List<ProductViewModel>>(lp);
            }
            return lpvm;
        }
    }
}
