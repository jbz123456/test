
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
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
        public ActionResult VerifyCode()
        {
            string verifyCode = string.Empty;
            Bitmap bitmap = VerifyCodeHelper.CreateVerifyCode(out verifyCode);

            #region 缓存Key 
            Cache cache = new Cache();
            // 先用当前类的全名称拼接上字符串 “verifyCode” 作为缓存的key
            var verifyCodeKey = $"{this.GetType().FullName}_verifyCode";
            cache.Remove(verifyCodeKey);
            cache.Insert(verifyCodeKey, verifyCode);
            #endregion

            MemoryStream memory = new MemoryStream();
            bitmap.Save(memory, ImageFormat.Gif);
            return File(memory.ToArray(), "image/gif");
        }
        public JsonResult Zhuce(string Number, string Pass, string verifyCode)
        {
            // 第一步检验验证码
            // 从缓存获取验证码作为校验基准  
            // 先用当前类的全名称拼接上字符串 “verifyCode” 作为缓存的key
            Cache cache = new Cache();
            var verifyCodeKey = $"{this.GetType().FullName}_verifyCode";
            object cacheobj = cache.Get(verifyCodeKey);
            if (cacheobj == null)
            {
                return Json(new
                {
                    Success = false,
                    Message = "验证码已失效"
                },JsonRequestBehavior.AllowGet);
            }//不区分大小写比较验证码是否正确
            else if (!(cacheobj.ToString().Equals(verifyCode, StringComparison.CurrentCultureIgnoreCase)))
            {
                return Json(new
                {
                    Success = false,
                    Message = "验证码错误"
                },JsonRequestBehavior.AllowGet);
            }
            else if ((cacheobj.ToString().Equals(verifyCode, StringComparison.CurrentCultureIgnoreCase)))
            {
                if(bll.zhuces(Number, Pass)>0)
                {
                    return Json(new
                    {
                        Success = true,
                        Message = "登录成功！"
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new
                    {
                        Success = false,
                        Message = "账号密码错误！"
                    }, JsonRequestBehavior.AllowGet);
                }
                
            }else
            {
                return Json(new
                {
                    Success = false,
                    Message = "未知错误！"
                }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult Show()
        {
            return View();
        }
        public JsonResult Xianshi(int PageIndex=1, int PageSize=2)
        {
            return Json(bll.Xian(PageIndex, PageSize), JsonRequestBehavior.AllowGet);
        }
    }
}