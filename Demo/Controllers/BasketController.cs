using Demo.Extensions;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            var basketSession = HttpContext.Session.Get<Basket>(WebConstants.BasketSession);

            Basket basket = new();

            if (basketSession!=null
                &&basketSession!.TotalCount>0)
            {
                basket=basketSession!;
            }

            return View(basket);
        }
    }
}