using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eshop.CoreLib.Models;
using Eshop.DataAccess.SQLSERVERLib;
using EShop.DataAccess.INMemoryCacheLib;
using Eshop.CoreLib.ViewModels;
namespace EShop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        InMemoryCache<Product> context;
        InMemoryCache<ProductCategories> productCategory;

        public ProductManagerController()
        {
            context = new InMemoryCache<Product>();
            productCategory = new InMemoryCache<ProductCategories>();
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }

        public ActionResult Create()
        {
            ProductManagerViewModel viewModel = new ProductManagerViewModel();

            viewModel.product = new Product();
            viewModel.productCategories = productCategory.Collection();
            return View(viewModel);
        }
[HttpPost]
        public ActionResult Create(Product product)
        {
            if(!ModelState.IsValid)
            {
                return View(product);
            }
           else  {
                context.Insert(product);
                context.CommitChanges();
                return RedirectToAction("Index");

            }
        }

        public ActionResult Edit(string Id)
        {
            Product product = context.Find(Id);

            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                ProductManagerViewModel viewModel = new ProductManagerViewModel();

                viewModel.product = product;
                viewModel.productCategories = productCategory.Collection();
                return View(viewModel);

            }
        }

        [HttpPost]
        public ActionResult Edit(Product product, string id)
        {

            Product productToEdit = context.Find(id);

            if (productToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                //else
                //{

                productToEdit.Category = product.Category;
                productToEdit.Description = product.Description;
                productToEdit.Image = product.Image;
                productToEdit.Price = product.Price;
                context.Update(productToEdit);
                context.CommitChanges();
                return RedirectToAction("Index");

                //}
            }
        }
            public ActionResult Delete(string id)
            {
                Product product = context.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(product);
                }
            }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            Product productToDelete = context.Find(id);
            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(productToDelete.Id);
                context.CommitChanges();
                return RedirectToAction("Index");
            }
        }

    }
}