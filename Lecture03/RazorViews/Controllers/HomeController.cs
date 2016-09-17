using System.Linq;
using System.Web.Mvc;
using RazorViews.Models;

namespace RazorViews.Controllers
{
    public class HomeController : Controller
    {
        private static Product[] _catalog = {
            new Product { Name = "Coca-Cola", Category = Category.Beverages, Amount = 100, PricePerUnit = 1.5M, Discount = true },
            new Product { Name = "Milk", Category = Category.Dairy, Amount = 500, PricePerUnit = 0.6M, Discount = false },
            new Product { Name = "Corn flakes", Category = Category.Cereals, Amount = 0, PricePerUnit = 1.1M, Discount = true },
            new Product { Name = "Tomatoes", Category = Category.Vegetables, Amount = null, PricePerUnit = 0.8M, Discount = false },
            new Product { Name = "Cake", Category = Category.Bakery, Amount = null, PricePerUnit = null, Discount = false }
        };

        public ActionResult Index() => View(_catalog[0]);
        public ActionResult Catalog() => View(_catalog);
        public ActionResult Details(int id) => View(_catalog.First(p => p.ID == id));
    }
}