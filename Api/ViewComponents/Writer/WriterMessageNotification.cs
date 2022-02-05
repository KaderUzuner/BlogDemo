using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        Message2Manager mn = new Message2Manager(new EfMessage2Repository());
        public IViewComponentResult Invoke()
        {

            int id = 5;

            var values = mn.GetInboxListByWriter(id);
            return View(values);
        }
    }
}
