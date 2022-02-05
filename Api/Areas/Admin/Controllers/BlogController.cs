using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Areas.Admin.Models;

namespace WebAPI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Title";

                int BlogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;

                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
      
        }
        List<BlogModel>GetBlogList()
        {
            List<BlogModel> bm = new List<BlogModel>
            {
                new BlogModel{ID=1,BlogName="C# Programlamya Giriş"},
                new BlogModel{ID=2,BlogName="Tesla Firmasının Araçları"},
                new BlogModel{ID=3,BlogName="2020 Olimpiyatları"},

            };
            return bm;
        }
        public IActionResult BlogListExcel()
        {
            return View();
        }
        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BloRowCount = 2;
                foreach (var item in BlogTitleList())
                {
                    worksheet.Cell(BloRowCount, 1).Value = item.ID;
                    worksheet.Cell(BloRowCount, 2).Value = item.BlogName;
                    BloRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Calisma1.xlsx");
                }
            }
        }
        public List<BlogModel2>BlogTitleList()
        {
            List<BlogModel2> bm = new List<BlogModel2>();
            using(var c=new Context())
            {
                bm = c.Blogs.Select(x => new BlogModel2
                {
                    ID=x.BlogID,
                    BlogName=x.BlogTitle
                }).ToList();
         
            }
            return bm;
        }
        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }
    
}
