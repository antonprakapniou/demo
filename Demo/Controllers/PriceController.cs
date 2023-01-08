using Demo.Extensions;
using Demo.Interfaces;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class PriceController : Controller
    {
        private readonly IProductService _productService;

        public PriceController(IProductService productService)
        {
            _productService= productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var productList=await _productService.GetProductsAsync();
            return View(productList);
        }

        [HttpGet]
        public async Task<IActionResult> AddToBasket(Guid id)
        {
            var product=await _productService.GetProductByIdAsync(id);
            ProductWithCount productWithCount = new()
            {
                ProductViewModel= product,
                Count=1
            };

            return View(productWithCount);
        }

        [HttpPost]
        public async Task<IActionResult> AddToBasket(Guid id, ProductWithCount productWithCount)
        {
            List<ProductWithCount> basket = new();

            if (HttpContext.Session.Get<IEnumerable<ProductWithCount>>(WebConstants.SessionCart)!=null
                &&HttpContext.Session.Get<IEnumerable<ProductWithCount>>(WebConstants.SessionCart)!.Count()>0)
            {
                basket=HttpContext.Session.Get<List<ProductWithCount>>(WebConstants.SessionCart)!;
            }

            var product = await _productService.GetProductByIdAsync(id);

            basket.Add(new ProductWithCount
            {
                ProductViewModel = product,
                Count=productWithCount.Count
            });

            HttpContext.Session.Set(WebConstants.SessionCart, basket);
            return RedirectToAction(nameof(Index));
        }
    }
}