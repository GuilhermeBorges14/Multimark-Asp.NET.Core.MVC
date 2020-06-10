using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Multimark.Models;

namespace Multimark.Controllers
{
    public class AdmController : Controller
    {
        private readonly MultimarkContext _context;

        public AdmController(MultimarkContext context)
        {
            _context = context;
        }

        // GET: Adms
        public async Task<IActionResult> Index()
        {
            return View(await _context.Adms.ToListAsync());
        }

        // GET: Adms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adm = await _context.Adms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adm == null)
            {
                return NotFound();
            }

            return View(adm);
        }

        // GET: Adms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,User,Password")] Adm adm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adm);
        }

        // GET: Adms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adm = await _context.Adms.FindAsync(id);
            if (adm == null)
            {
                return NotFound();
            }
            return View(adm);
        }

        // POST: Adms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,User,Password")] Adm adm)
        {
            if (id != adm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdmExists(adm.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(adm);
        }

        // GET: Adms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adm = await _context.Adms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adm == null)
            {
                return NotFound();
            }

            return View(adm);
        }

        // POST: Adms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adm = await _context.Adms.FindAsync(id);
            _context.Adms.Remove(adm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdmExists(int id)
        {
            return _context.Adms.Any(e => e.Id == id);
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

            return RedirectToAction("Login", "Adm");

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
