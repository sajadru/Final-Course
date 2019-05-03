using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SearchAdventurework.Controllers
{
    public class ShowTableController : Controller
    {
        // GET: ShowTable
        public ActionResult Index()
        {
            var s_productid =(string.IsNullOrEmpty(Request["sproductid"]) ? "" : Request["sproductid"]);
            var s_name = string.IsNullOrEmpty(Request["sname"]) ? "" : Request["sname"];
            var s_color = string.IsNullOrEmpty(Request["scolor"]) ? string.Empty : Request["scolor"];
            var s_listprice = string.IsNullOrEmpty(Request["slistprice"]) ? "" : Request["slistprice"];
            var ctx = new AdventureWorks2017Entities();
            if (s_color == string.Empty)
            {
                var product = ctx.Products
                    .Where(p => p.Name.Contains(s_name) )
                    .Where(p => p.ProductID.ToString().Contains(s_productid))
                    .Where(p => p.ListPrice.ToString().Contains(s_listprice))
                    .OrderBy(p => p.ProductID)
                    .ToList()
                    ;
                TempData["sname"] = s_name;
                TempData["sproductid"] = s_productid;
                TempData["scolor"] = s_color;
                TempData["slistprice"] = s_listprice;
                return View(product);
            }
            else
            {
                var product = ctx.Products
                      .Where(p => p.Name.Contains(s_name) )
                      .Where(p => p.Color.Contains(s_color))
                      .Where(p => p.ProductID.ToString().Contains(s_productid))
                      .Where(p => p.ListPrice.ToString().Contains(s_listprice))
                      .OrderBy(p => p.ProductID)
                      .ToList()
                      ;
                return View(product);
            }
           
        }
    }
}