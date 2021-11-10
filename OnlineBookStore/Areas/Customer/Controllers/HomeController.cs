using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineBookStore.DataAccess.Repository.IRepository;
using OnlineBookStore.Models;
using OnlineBookStore.Models.ViewModels;
using OnlineBookStore.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnlineBookStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> productList = await _unitOfWork.Product.GetAllAsync(includeProperties: "Category,CoverType");
            
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim != null)
            {
                IEnumerable<ShoppingCart> ShoppingCartList = await _unitOfWork.ShoppingCart
                   .GetAllAsync(s => s.ApplicationUserId == claim.Value);
               var count = ShoppingCartList
                   .ToList().Count();

                HttpContext.Session.SetInt32(StaticDetails.sshoppingCart, count);


            }

            return View(productList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Details(ShoppingCart cartObject)
        {
            cartObject.Id = 0;
            if(ModelState.IsValid)
            {
                //then add to cart
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                cartObject.ApplicationUserId = claim.Value;

                ShoppingCart cartInDb = await _unitOfWork.ShoppingCart
                    .GetFirstOrDefaultAsync(c => c.ApplicationUserId == cartObject.ApplicationUserId && c.ProductId == cartObject.ProductId,
                    includeProperties:"Product");

                if (cartInDb ==null)
                {
                    await _unitOfWork.ShoppingCart.AddAsync(cartObject);

                }
                else
                {
                    cartInDb.Count += cartObject.Count;
                    _unitOfWork.ShoppingCart.Update(cartInDb);
                }
                _unitOfWork.Save();

                IEnumerable<ShoppingCart> ShoppingCartList = await _unitOfWork.ShoppingCart
                    .GetAllAsync(s => s.ApplicationUserId == cartObject.ApplicationUserId);
                var count = ShoppingCartList 
                    .ToList().Count();

                // HttpContext.Session.SetObject(StaticDetails.sshoppingCart, cartObject);
                //HttpContext.Session.GetObject<ShoppingCart>(StaticDetails.sshoppingCart);
                HttpContext.Session.SetInt32(StaticDetails.sshoppingCart, count);
                return RedirectToAction(nameof(Index));

            }

            else
            {
                var productInDd = await _unitOfWork.Product
              .GetFirstOrDefaultAsync(p => p.Id == cartObject.ProductId, includeProperties: "Category,CoverType");
                ShoppingCart cartObj = new ShoppingCart()
                {
                    Product = productInDd,
                    ProductId = productInDd.Id
                };


                return View(cartObj);
            }

          
        }

        public async Task<IActionResult> Details(int id)
        {

            var productInDd = await _unitOfWork.Product
                .GetFirstOrDefaultAsync(p => p.Id == id, includeProperties: "Category,CoverType");
            ShoppingCart cartObj = new ShoppingCart()
            {
                Product = productInDd,
                ProductId = productInDd.Id
            };
           

            return View(cartObj);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
