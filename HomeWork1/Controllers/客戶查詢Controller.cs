using HomeWork1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeWork1.Controllers
{
    public class 客戶查詢Controller : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();
        // GET: 客戶查詢
        public ActionResult Index()
        {
            var data = db.客戶查詢View.AsQueryable();
            return View(data);
        }
    }
}