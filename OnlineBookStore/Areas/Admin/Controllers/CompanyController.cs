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
    [Authorize(Roles = StaticDetails.Role_Admin + "," + StaticDetails.Role_Employee)]

    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> FormCompany(int? id)
        {
            Company company = new Company();
            //to create
            if (id == null)
            {
                return View(company);
            }

            //to update
            company = await _unitOfWork.Company.GetAsync(id.GetValueOrDefault());
            if(company==null)
            {
                return NotFound();
            }
            return View(company);
        }

        #region API CALLS
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FormCompany(Company company)
        {
            if (ModelState.IsValid)
            {
                if(company.Id==0)
                {
                    await _unitOfWork.Company.AddAsync(company);
                    
                }else
                {
                    _unitOfWork.Company.Update(company);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _unitOfWork.Company.GetAllAsync();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objInDb = await _unitOfWork.Company.GetAsync(id);
            if (objInDb == null)
            {
                return Json(new { success = false, message = "Error on delete." });
            }
            await _unitOfWork.Company.RemoveAsync(objInDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Deleted." });
        }
        #endregion
    }
}
