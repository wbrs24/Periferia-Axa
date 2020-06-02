using DataAccess.Model.ViewModels;
using DataAccess.Model.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductViewModel> GetProducts();
        ServiceResult GetAllProducts(int page, int rows);
        ServiceResult DeleteProduct(ProductViewModel pvm);
        ServiceResult UdpateProduct(ProductViewModel pvm);
        ServiceResult CreateProduct(ProductViewModel pvm);

    }
}
