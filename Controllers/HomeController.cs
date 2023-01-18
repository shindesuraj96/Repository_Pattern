using Repository_Design_Pattern.Models;
using Repository_Design_Pattern.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repository_Design_Pattern.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository _productRepository;
        public HomeController()
        {
            this._productRepository = new ProductRepository(new DataContext());
        }
        public ActionResult Index()
        {
            return View(_productRepository.GetProducts());
        }
        public ActionResult Create()
        {
            return View(new Product_Table());
        }
        [HttpPost]
        public ActionResult Create(Product_Table product)
        {
            _productRepository.InsertProduct(product);
            _productRepository.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int Id)
        {
            return View(_productRepository.GetProductById(Id));
        }
        [HttpPost]
        public ActionResult Update(Product_Table product)
        {
            _productRepository.UpdateProduct(product);
            _productRepository.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            _productRepository.DeleteProduct(Id);
            _productRepository.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}