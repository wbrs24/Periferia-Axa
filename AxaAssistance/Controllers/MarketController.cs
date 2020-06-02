using AppServices.Interfaces;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AxaAssistance.Controllers
{
    public class MarketController : Controller
    {
        private readonly IProductService _productService;
        public MarketController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: Product
        public ActionResult Index()
        {
            return View(_productService.GetProducts());
        }

        // GET: Product
        public ActionResult Settings()
        {
            return View();
        }
    }
}