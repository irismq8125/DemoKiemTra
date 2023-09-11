using DemoKiemTra.Models.DanhSach;
using Microsoft.AspNetCore.Mvc;

namespace DemoKiemTra.Controllers
{
    public class DanhSachController : Controller
    {
        public static List<ModelDanhSach> products = new List<ModelDanhSach>();
        public IActionResult Index(bool? check = false)
        {
            if ((bool)check)
            {
                products.Clear();
            }
            else
            {
                return View(products.ToList());
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(string tensanpham, int soluong, int dongia)
        {
            var homeProduct = new ModelDanhSach(tensanpham, soluong, dongia);
            products.Add(homeProduct);
            return View(products);
        }

        public IActionResult RemoveProduct(int position)
        {
            products.RemoveAt(position - 1);
            return RedirectToAction("Index", "Home");
        }
    }
}
