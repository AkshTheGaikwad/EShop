using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShop.DataAccess.INMemoryCacheLib;
using Eshop.CoreLib.Models;
using EShop.CoreLib;

namespace EShop.WebUI.Controllers
{
    public class ProductCategoriesManagerController : Controller
    {
        // GET: ProductCategoriesManager
        ICache<ProductCategories> context;

        public ProductCategoriesManagerController(ICache<ProductCategories> productCategoriesContext)
        {
            context = productCategoriesContext;
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<ProductCategories> productCategories = context.Collection().ToList();
            return View(productCategories);
        }

        public ActionResult Create()
        {
            ProductCategories productCategory = new ProductCategories();
            return View(productCategory);
        }
        [HttpPost]
        public ActionResult Create(ProductCategories productCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(productCategory);
            }
            else
            {
                context.Insert(productCategory);
                context.CommitChanges();
                return RedirectToAction("Index");

            }
        }

        public ActionResult Edit(string Id)
        {
            ProductCategories productCategory = context.Find(Id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategory);
            }
        }

        [HttpPost]
        public ActionResult Edit(ProductCategories productCategory, string id)
        {
            ProductCategories productCategoryToEdit = context.Find(id);

            if (productCategoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(productCategory);
                }
                //else
                //{

                productCategoryToEdit.CategoryName = productCategory.CategoryName;
               
                context.Update(productCategoryToEdit);
                context.CommitChanges();
                return RedirectToAction("Index");

                //}
            }
        }
        public ActionResult Delete(string id)
        {
            ProductCategories productCategory = context.Find(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategory);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            ProductCategories productCategoryToDelete = context.Find(id);
            if (productCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(productCategoryToDelete.Id);
                context.CommitChanges();
                return RedirectToAction("Index");
            }
        }
    }
}