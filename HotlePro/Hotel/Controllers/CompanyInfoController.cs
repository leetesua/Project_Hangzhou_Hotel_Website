using HotelBLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Controllers
{
    public class CompanyInfoController : Controller
    {
        //
        // GET: /CompanyInfo/

        public ActionResult Index()
        {
            List<News> objlist = new NewsManager().GetNews(5);
            ViewBag.list = objlist;
            return View();
        }
        /// <summary>
        /// 公司简介
        /// </summary>
        /// <returns></returns>
        public ActionResult ComDesc() 
        {
            return View();
        }
        public ActionResult JoinUs()
        {
            return View();
        }
        public ActionResult DoSugg(Suggestion objSug,string ValidateCode ) 
        {
            if (String.Compare(Session["ValidateCode"].ToString(), ValidateCode, true) != 0)
            {
                ModelState.AddModelError("yzm", "验证码输入不正确，请重新输入");
                return View("Suggestions");
            }
            else
            {
                //调用BLL 数据处理
                int res = new SuggestionManager().SubmitSuggestion(objSug);
                if (res > 0)
                {
                    return Content("添加成功!");
                }
                else
                {
                    return Content("添加失败!");
                }
            }
          
        }
        /// <summary>
        /// 投诉建议
        /// </summary>
        /// <returns></returns>
        public ActionResult Suggestions() 
        {
            return View();
        }
        public ActionResult AboutUs() 
        {
            return View();
        }
        public ActionResult ZhaoPinList() 
        {
            return View();
        }
        public ActionResult ZhaoPinDetail(string PostId) 
        {
            Recruitment objRec = new RecruitmentManager().GetPostById(PostId);
            return View("ZhaoPinDetail", objRec);
         }
    }
}
