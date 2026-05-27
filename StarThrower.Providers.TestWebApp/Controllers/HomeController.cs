using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StarThrower.Providers.TestWebApp.Common;
using StarThrower.Providers.TestWebApp.Models;

namespace StarThrower.Providers.TestWebApp.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            LoadBaseData(model);

            return View(model);
        }

    }
}
