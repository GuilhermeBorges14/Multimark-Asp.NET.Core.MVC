using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multimark.Models;

namespace Multimark.Controllers
{
    public class PublicController : Controller
    {
        private readonly MultimarkContext _context;

        public PublicController(MultimarkContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult AcessoNegado()
        {
            return View();
        }

        public IActionResult Logout()
        {
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddMinutes(5);
            Response.Cookies.Append("User", "", cookie);

            return RedirectToAction("Login", "Public");

        }

        [HttpPost]
        public IActionResult Login(string utilizador, string senha)
        {
            string user = AutenticarUser(utilizador, senha);
            if (user == "")
            {
                ViewBag.Error = "Utilizador e/ou senha inválidos";
                return View();
            }
            else
            {
                CookieOptions cookie = new CookieOptions();
                cookie.Expires = DateTime.Now.AddMinutes(5);
                Response.Cookies.Append("User", user, cookie);
                return RedirectToAction("Index", "Home");
            }
        }

        public string AutenticarUser(string utilizador, string senha)
        {
            var query = (from u in _context.Adms
                         where u.User == utilizador &&
                         u.Password == senha
                         select u).SingleOrDefault();

            if (query == null)
            {
                return "";
            }
            else
            {
                return query.User;
            }
        }

    }
}
