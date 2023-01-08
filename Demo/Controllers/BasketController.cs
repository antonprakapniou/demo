using Demo.Extensions;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            List<ProductWithCount> basket = new();

            if (HttpContext.Session.Get<IEnumerable<ProductWithCount>>(WebConstants.SessionCart)!=null
                &&HttpContext.Session.Get<IEnumerable<ProductWithCount>>(WebConstants.SessionCart)!.Count()>0)
            {
                basket=HttpContext.Session.Get<IEnumerable<ProductWithCount>>(WebConstants.SessionCart)!.ToList();
            }

            return View(basket);
        }
    }
}