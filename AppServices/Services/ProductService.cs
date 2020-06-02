using AppServices.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Model.ViewModels;
using DataAccess.Model.ViewModels.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private ServiceResult _sr;
        public ProductService(IProductRepository repository)
        {
            _repo = repository;
        }

        public ServiceResult GetAllProducts(int page,int rows)
        {
            _sr = new ServiceResult() { IsValid = true, Error = new ServiceError() };
            var prods = _repo.GetProducts();
            var cant = 0;
            if (prods == null)
            {
                _sr.IsValid = false;
                _sr.Error.ErrorMessage = "¡Products not found!";
                return _sr;
            }

            // total
            double totalPages = Math.Ceiling((double)prods.Count() / rows);
            cant = prods.Count();
            // paging
            prods = prods.Skip((page - 1) * rows).Take(rows).ToList();

            var jsonData = new
            {
                total = totalPages,
                records = cant,
                page,
                rows = prods
            };
            _sr.ContentResult = JsonConvert.SerializeObject(jsonData);
            return _sr;
        }

        public IEnumerable<ProductViewModel> GetProducts()
        {
            return _repo.GetProducts();
        }

        public ServiceResult DeleteProduct(ProductViewModel pvm) 
        {
            _sr = new ServiceResult() { IsValid = true, Error = new ServiceError() };
            var prod = _repo.Delete(pvm);
            if (!prod)
            {
                _sr.IsValid = false;
                _sr.Error.ErrorMessage = "¡The product cannot be removed!";
                return _sr;
            }
            var pds = GetAllProducts(1, 5);
            return pds;
        }

        public ServiceResult UdpateProduct(ProductViewModel pvm) 
        {
            _sr = new ServiceResult() { IsValid = true, Error = new ServiceError() };
            var user = _repo.Update(pvm);
            if (user == null)
            {
                _sr.IsValid = false;
                _sr.Error.ErrorMessage = "¡The product cannot be updated!";
                return _sr;
            }
            var pds = GetAllProducts(1, 5);
            return pds;
        }

        public ServiceResult CreateProduct(ProductViewModel pvm)
        {
            _sr = new ServiceResult() { IsValid = true, Error = new ServiceError() };
            var user = _repo.Create(pvm);
            if (user == null)
            {
                _sr.IsValid = false;
                _sr.Error.ErrorMessage = "¡The product cannot be created!";
                return _sr;
            }
            var pds = GetAllProducts(1, 5);
            return pds;
        }
    }
}