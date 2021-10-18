using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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

    public class ApplicationUserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;

        public ApplicationUserController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager )
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _unitOfWork.ApplicationUser.GetAll(includeProperties: "Company");
            foreach (var user in users)
            {
                user.Role = _userManager.GetRolesAsync(user).Result.FirstOrDefault();

                if (user.Company == null)
                {
                    user.Company = new Company()
                    {
                        Name = ""
                    };
                }
            }
            return Json(new { data = users });
        }
        [HttpPost]
        public IActionResult LockUnlock([FromBody] string id)
        {
            var objInDb = _unitOfWork.ApplicationUser.Get(id);
            if (objInDb == null)
            {
                return Json(new { success = false, message = "Error while locking/unlocking." });
            }

            if (objInDb.LockoutEnd!=null && objInDb.LockoutEnd > DateTime.Now)
            {
                //user is currently locked, and will be unlocked
                objInDb.LockoutEnd = DateTime.Now;
            } else
            {
                objInDb.LockoutEnd = DateTime.Now.AddYears(1000);
            }
            _unitOfWork.Save();
            return Json(new { success = true, message = "Success!" });
        }
/*        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objInDb = _unitOfWork.ApplicationUser.Get(id);
            if (objInDb == null)
            {
                return Json(new { success = false, message = "Error on delete." });
            }
            _unitOfWork.ApplicationUser.Remove(objInDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Deleted." });
        }*/
        #endregion
    }
}
