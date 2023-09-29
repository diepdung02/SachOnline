using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SachOnline.Controllers
{
    public class SlideController : Controller
    {
        // GET: Slide
        public ActionResult SliderPartial()
        {
            return View();
        }
    }
}