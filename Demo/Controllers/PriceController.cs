using AutoMapper;
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

        public async Task<IActionResult> Index()
        {
            var productList=await _productService.GetProductsAsync();
            var productWithCountList = new List<ProductWithCount>();

            foreach (var product in productList)
            {
                ProductWithCount productWithCount = new()
                {
                    ProductViewModel=product,
                    Count=1
                };

                productWithCountList.Add(productWithCount);
            }

            return View(productWithCountList);
        }
    }
}