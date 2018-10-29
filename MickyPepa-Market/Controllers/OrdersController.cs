using MickyPepa_Market.Models;
using MickyPepa_Market.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
            orderView.Products = new List<ProductOrder>();
            Session["orderView"] = orderView;

            var list = db.Customers.ToList();
            list.Add(new Customer { CustomerID = 0, FirstName = "[Seleccione un Cliente...]" });
            list = list.OrderBy(c => c.FullName).ToList();
            ViewBag.CustomerID = new SelectList(list, "CustomerID", "FullName");

            return View(orderView);
        }

        [HttpPost]
        public ActionResult NewOrder(OrderView orderView)
        {
            orderView = Session["orderView"] as OrderView;
            var customerID = int.Parse(Request["CustomerID"]);
            if (customerID == 0)
            {
                var listaCC = db.Customers.ToList();
                listaCC.Add(new Customer { CustomerID = 0, FirstName = "[Seleccione un Cliente...]" });
                listaCC = listaCC.OrderBy(c => c.FullName).ToList();
                ViewBag.CustomerID = new SelectList(listaCC, "CustomerID", "FullName");
                ViewBag.Error = "Debe seleccionar un cliente";
                return View(orderView);
            }
            var customer = db.Customers.Find(customerID);
            if (customer == null)
            {
                var listaCC = db.Customers.ToList();
                listaCC.Add(new Customer { CustomerID = 0, FirstName = "[Seleccione un Cliente...]" });
                listaCC = listaCC.OrderBy(c => c.FullName).ToList();
                ViewBag.CustomerID = new SelectList(listaCC, "CustomerID", "FullName");
                ViewBag.Error = "El cliente no existe";
                return View(orderView);
            }

            if (orderView.Products.Count == 0)
            {
                var listaCC = db.Customers.ToList();
                listaCC.Add(new Customer { CustomerID = 0, FirstName = "[Seleccione un Cliente...]" });
                listaCC = listaCC.OrderBy(c => c.FullName).ToList();
                ViewBag.CustomerID = new SelectList(listaCC, "CustomerID", "FullName");
                ViewBag.Error = "Debe ingresar Detalle";

                return View(orderView);
            }

            int orderID = 0;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var order = new Order
                    {
                        CustomerID = customerID,
                        OrderDate = DateTime.Now,
                        OrderStatus = OrderStatus.Create
                    };

                    db.Orders.Add(order);
                    db.SaveChanges();

                    orderID = db.Orders.ToList().Select(o => o.OrderID).Max();

                    foreach (var item in orderView.Products)
                    {
                        var orderDetail = new OrderDetail
                        {
                            ProductID = item.ProductID,
                            Description = item.Description,
                            Price = item.Price,
                            Quantity = item.Quantity,
                            OrderID = orderID
                        };
                        db.OrderDetails.Add(orderDetail);
                    }
                    db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    ViewBag.Error = "Error: " + ex.Message;
                    return View(orderView);
                }
            }

            ViewBag.Message = String.Format("La orden: {0}, grabada ok", orderID);

            //Mandamos viewbag a la vista
            var listaCU = db.Customers.ToList();
            listaCU.Add(new Customer { CustomerID = 0, FirstName = "[Seleccione un Cliente...]" });
            listaCU = listaCU.OrderBy(c => c.FullName).ToList();
            ViewBag.CustomerID = new SelectList(listaCU, "CustomerID", "FullName");

            orderView = new OrderView();
            orderView.Customer = new Customer();
            orderView.Products = new List<ProductOrder>();
            Session["orderView"] = orderView;

            return View(orderView);
        }

        public ActionResult AddProduct()
        {

            var list = db.Products.ToList();
            list.Add(new ProductOrder { ProductID = 0, Description = "[Seleccione un producto...]" });
            list = list.OrderBy(p => p.Description).ToList();
            ViewBag.ProductID = new SelectList(list, "ProductID", "Description");
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(ProductOrder productOrder)
        {
            var orderView = Session["orderView"] as OrderView;
            var productID = int.Parse(Request["ProductID"]);
            if (productID == 0)
            {
                var lista = db.Products.ToList();
                lista.Add(new ProductOrder { ProductID = 0, Description = "[Seleccione un producto...]" });
                lista = lista.OrderBy(p => p.Description).ToList();
                ViewBag.ProductID = new SelectList(lista, "ProductID", "Description");
                ViewBag.Error = "Debe seleccionar un producto";
                return View(productOrder);
            }

            var product = db.Products.Find(productID);
            if (product == null)
            {
                var lista = db.Products.ToList();
                lista.Add(new ProductOrder { ProductID = 0, Description = "[Seleccione un producto...]" });
                lista = lista.OrderBy(p => p.Description).ToList();
                ViewBag.ProductID = new SelectList(lista, "ProductID", "Description");
                ViewBag.Error = "El producto no existe";
            }

            productOrder = orderView.Products.Find(p => p.ProductID == productID);
            if (productOrder == null)
            {
                productOrder = new ProductOrder()
                {
                    Description = product.Description,
                    Price = product.Price,
                    ProductID = product.ProductID,
                    Quantity = float.Parse(Request["Quantity"])
                };
                orderView.Products.Add(productOrder);
            }
            else
            {
                productOrder.Quantity += float.Parse(Request["Quantity"]);
            }


            var listc = db.Customers.ToList();
            listc.Add(new Customer { CustomerID = 0, FirstName = "[Seleccione un Cliente...]" });
            listc = listc.OrderBy(c => c.FullName).ToList();
            ViewBag.CustomerID = new SelectList(listc, "CustomerID", "FullName");

            return View("NewOrder", orderView);
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