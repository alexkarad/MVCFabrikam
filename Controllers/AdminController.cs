using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCFabrikam.Models;

namespace MVCFabrikam.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        private FabrikamEntities _context = new FabrikamEntities();

        public ActionResult ValidateLogin(AdminAccount account)
        {
            string username = account.Username;
            string password = account.Password;

            var query =
                from c in _context.AdminLogins
                where c.Username == username && c.Password == password
                select c;

            if (query.Any())
            {
                return Redirect("https://localhost:44394/Blog/Blog");
            }
            else
            {
                return View("SignIn");
            }

        }

       

        public ActionResult SignIn()
        {
            AdminAccount obj = new AdminAccount();
            return View(obj);
        }

        public ActionResult Admin()
        {
            return View("SignIn");
        }
    }
}