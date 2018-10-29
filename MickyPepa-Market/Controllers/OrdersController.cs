using MickyPepa_Market.Models;
using MickyPepa_Market.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MickyPepa_Market.Controllers
{
    public class OrdersController : Controller
    {
        MickyPepa_MarketContext db = new MickyPepa_MarketContext();
        // GET: Orders
        public ActionResult NewOrder()
        {
            var orderView = new OrderView();
            orderView.Customer = new Customer();
            orderView.Product = new List<ProductOrder>();

            var list = db.Customers.ToList();
            list = list.OrderBy(c => c.FullName).ToList();
            ViewBag.CustomerID = new SelectList(list, "CustomerID", "FullName");

            return View(orderView);
        }

        [HttpPost]
        public ActionResult NewOrder(OrderView orderView)
        {

            var list = db.Customers.ToList();
            list = list.OrderBy(c => c.FullName).ToList();
            ViewBag.CustomerID = new SelectList(list, "CustomerID", "FullName");
            return View(orderView);
        }

        public ActionResult AddProduct(ProductOrder productOrder)
        {
            return View(productOrder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}