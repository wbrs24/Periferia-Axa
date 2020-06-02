using DataAccess.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IProductRepositorys
    {
        IEnumerable<ProductViewModel> GetAll();
    }
}
