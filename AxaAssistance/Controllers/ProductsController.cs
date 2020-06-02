using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppServices.Interfaces;
using DataAccess.Model;
using DataAccess.Model.ViewModels;

namespace AxaAssistance.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: /Products/GetAllProducts
        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetAllProducts(int page = 1, int rows = 5)
        {
            var result = _productService.GetAllProducts(page, rows);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // POST: Products/Update
        [HttpPost]
        [AllowAnonymous]
        public ActionResult UpdateProduct(ProductViewModel productModel)
        {
            if (!ModelState.IsValid)
            {
                return View(productModel);
            }

            var result = _productService.UdpateProduct(productModel);
            return Json(result);
        }

        // POST: Products/Create
        [HttpPost]
        [AllowAnonymous]
        public ActionResult CreateProduct(ProductViewModel productModel)
        {
            if (!ModelState.IsValid)
            {
                if (productModel.IdProduct != 0)
                { return View(productModel); }
            }

            var result = _productService.CreateProduct(productModel);
            return Json(result);
        }

        // POST: Products/Delete
        [HttpPost]
        [AllowAnonymous]
        public ActionResult DeleteProduct(ProductViewModel productModel)
        {
            if (!ModelState.IsValid)
            {
                return View(productModel);
            }

            var result = _productService.DeleteProduct(productModel);
            return Json(result);
        }
    }
}
