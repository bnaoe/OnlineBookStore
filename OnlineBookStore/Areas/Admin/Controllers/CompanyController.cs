using Microsoft.AspNetCore.Mvc;
using OnlineBookStore.DataAccess.Repository.IRepository;
using OnlineBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
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

        public IActionResult FormCompany(int? id)
        {
            Company company = new Company();
            //to create
            if (id == null)
            {
                return View(company);
            }

            //to update
            company = _unitOfWork.Company.Get(id.GetValueOrDefault());
            if(company==null)
            {
                return NotFound();
            }
            return View(company);
        }

        #region API CALLS
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FormCompany(Company company)
        {
            if (ModelState.IsValid)
            {
                if(company.Id==0)
                {
                    _unitOfWork.Company.Add(company);
                    
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
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Company.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objInDb = _unitOfWork.Company.Get(id);
            if (objInDb == null)
            {
                return Json(new { success = false, message = "Error on delete." });
            }
            _unitOfWork.Company.Remove(objInDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Deleted." });
        }
        #endregion
    }
}
