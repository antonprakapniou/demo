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
            Basket basket = new();

            var basketSession = HttpContext.Session.Get<Basket>(WebConstants.BasketSession);            

            if (basketSession!=null
                &&basketSession!.TotalCount>0)
            {
                basket=basketSession!;//basket properties saved to coockies
            }

            var product = await _productService.GetProductByIdAsync(id);

            basket.Products.Add(new ProductWithCount
            {
                ProductViewModel = product,
                Count=productWithCount.Count,
                GeneralPrice=productWithCount.Count*product.Price
            });

            basket.TotalCount=basket.Products.Sum(p => p.Count);
            basket.TotalPrice=basket.Products.Sum(p => p.Count*p.ProductViewModel.Price);

            HttpContext.Session.Set(WebConstants.BasketSession, basket);//basket properties saved to coockies with changes
            return RedirectToAction(nameof(Index));
        }
    }
}