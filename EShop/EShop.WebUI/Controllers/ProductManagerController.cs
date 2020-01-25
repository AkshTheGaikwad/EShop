using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShop.WebUI;

namespace EShop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        // GET: ProductManager
        public ActionResult Index()
        {
            return View();
        }
    }
}