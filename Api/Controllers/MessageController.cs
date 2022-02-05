using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager mn = new Message2Manager(new EfMessage2Repository());
        [AllowAnonymous]
        public IActionResult InBox()
        {
            int id = 5;

            var values = mn.GetInboxListByWriter(id);
            return View(values);
           
        }
        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var value = mn.TGetById(id);
            

            return View(value);
        }
    }
}
