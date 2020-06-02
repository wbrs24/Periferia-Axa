using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model.ViewModels.Common
{
    public class ServiceResult
    {
        public bool IsValid { get; set; }
        public string ContentResult { get; set; }
        public ServiceError Error { get; set; }
    }
}