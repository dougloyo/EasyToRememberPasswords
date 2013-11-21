using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyToRememberPasswords.Models;

namespace EasyToRememberPasswords.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var model = new PasswordViewModel{};

            prepareModel(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(PasswordViewModel model)
        {
            prepareModel(model);

            model.Password = "C@briol3t";

            return View(model);
        }

        private void prepareModel(PasswordViewModel model)
        {
            model.AvailableCharacterCount = new List<int> {5, 6, 7, 8, 9};
        }
    }
}
