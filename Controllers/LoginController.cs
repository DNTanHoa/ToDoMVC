using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoModel.Context;
using ToDoModel.Service;
using ToDoMVC.Models;

namespace ToDoMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly ERPContext _context;

        public LoginController(ERPContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Submit(LoginModel model)
        {
            var result = new UserService(_context).Login(model.username, model.password);

            if (result && ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tên Đăng Nhập Hoặt Mật Khẩu Không Được Để Trống");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();   
        }
    }
}