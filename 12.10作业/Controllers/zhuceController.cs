using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bll;
using Model;


namespace _12._10作业.Controllers
{
    public class zhuceController : Controller
    {
        ZhuceBll bll = new ZhuceBll();
        // GET: zhuce
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ZhuceShow()
        {
            return View();
        }
        public JsonResult Zhuce(string Number, string Pwd)
        {
            return Json(bll.zhuces(Number, Pwd));
        }
    }
}