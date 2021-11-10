using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStore.DataAccess.Repository.IRepository;
using OnlineBookStore.Models;
using OnlineBookStore.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =StaticDetails.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> FormCategory(int? id)
        {
            Category category = new Category();
            //to create
            if (id == null)
            {
                return View(category);
            }

            //to update
            category = await _unitOfWork.Category.GetAsync(id.GetValueOrDefault());
            if(category==null)
            {
                return NotFound();
            }
            return View(category);
        }

        #region API CALLS
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FormCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                if(category.Id==0)
                {
                    await _unitOfWork.Category.AddAsync(category);
                    
                }else
                {
                    _unitOfWork.Category.Update(category);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _unitOfWork.Category.GetAllAsync();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objInDb = await _unitOfWork.Category.GetAsync(id);
            if (objInDb == null)
            {
                return Json(new { success = false, message = "Error on delete." });
            }
            await _unitOfWork.Category.RemoveAsync(objInDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Deleted." });
        }
        #endregion
    }
}
