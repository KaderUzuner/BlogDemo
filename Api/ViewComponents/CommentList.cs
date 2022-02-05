using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ViewComponents
{
    public class CommentList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentvalues = new List<UserComment>
            {
                new UserComment
                {
                    ID=1,
                    Username="Kader"
                },
                  new UserComment
                {
                    ID=2,
                    Username="Mehmethan"
                },
            };
            return View(commentvalues);
        }
    }
}
