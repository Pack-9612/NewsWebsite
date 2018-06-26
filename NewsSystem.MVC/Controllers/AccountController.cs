using NewsSystem.Models;
using System.Runtime.Remoting.Contexts;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NewsSystem.MVC.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        //public ActionResult Register()
        //{
        //    return View();
        //}

        //public ActionResult Register(MainUser User)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Context ctx = new Context();
        //        ctx.Users.Add(User);
        //        ctx.SaveChanges();
        //    }

        //    return View();

        //}

    }
}