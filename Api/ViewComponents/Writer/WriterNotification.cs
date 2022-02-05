using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ViewComponents.Writer
{
    public class WriterNotification:ViewComponent
    {
        NotificationManager nm = new NotificationManager(new EfNotificationRepository());
        public IViewComponentResult Invoke()
        {
            var values = nm.GetList(x => x.NotificationStatus == true
              && x.NotificationStatus == true);
            if (values.Count() > 3)
            {
                values = values.Take(3).ToList();
            }
            return View(values);
        }
    }
}
