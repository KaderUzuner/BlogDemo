using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutRepository());
        [HttpGet]
        public IActionResult Index()
        {
            var values = abm.GetList();
            return View(values);
        }
        [HttpGet]
        public PartialViewResult SocialMediaAbout()
        {
           
            return PartialView();
        }
    }
}
