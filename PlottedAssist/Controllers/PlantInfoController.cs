using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlottedAssist.Controllers
{
    public class PlantInfoController : Controller
    {
        // GET: PlantInfo
        public ActionResult Nurseries()
        {
            return View();
        }
    }
}