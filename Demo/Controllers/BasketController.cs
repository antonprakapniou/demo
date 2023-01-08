using Demo.Extensions;
using Demo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            Basket basket = new();

            var basketSession = HttpContext.Session.Get<Basket>(WebConstants.BasketSession);

            if (basketSession!=null
                &&basketSession!.TotalCount>0)
            {
                basket=basketSession!;
            }

            return View(basket);
        }
    }
}