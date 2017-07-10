using HotelBLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Hotel.Areas.HotelAdmin.Controllers
{
    public class SysAdminController : Controller
    {
        //
        // GET: /HotelAdmin/SysAdmin/

        public ActionResult Index()
        {
            return View("AdminLogin");
        }
        [Authorize]
        public ActionResult AdminMain()
        {
            string name = User.Identity.Name;
            return View();
        }
        //投诉建议管理
        public ActionResult SuggestionList()
        {
            List<Suggestion> objlist = new SuggestionManager().GetSuggestion();         
            return View("SuggestionList",objlist);
        }
        [HttpGet]
        public ActionResult DoSugg(string suggId) 
        {
            //调用模型BLL进行数据处理
            int res = new SuggestionManager().HandlSuggestion(suggId);
            if (res > 0)
            {
                return Content("<script>alert('投诉受理成功!');location.href='" + Url.Action("SuggestionList") + "'</script>");
            }
            else
            {
                return Content("<script>alert('投诉受理失败!');location.href='" + Url.Action("SuggestionList") + "'</script>");
            }
          
        }
        /// <summary>
        /// 退出系统
        /// </summary>
        /// <returns></returns>
        public ActionResult ExtSys() 
        {
            Session["currentAdmin"] = null;
            Session.Abandon();
            FormsAuthentication.SignOut();
            return View("AdminLogin");
        }
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="objSys"></param>
        /// <returns></returns>
        public ActionResult LoginUser(SysAdmins objSys) 
        {
            //获取参数数据验证
            if (ModelState.IsValid)
            {
                //调用BLL业务逻辑层登录方法
                objSys = new SysAdminManager().AdminLogin(objSys);
                //if(登录成功)  1.存值到session 给2.当前登录用户发放票据 3.返回主页（）
                if (objSys != null)
                {
                    Session["currentAdmin"] = objSys.LoginName;
                    //发票据
                    FormsAuthentication.SetAuthCookie(objSys.LoginName, true);
                    return View("AdminMain");
                }
                else
                {
                    return Content("<script>alert('用户名或密码错误!');location.href='" + Url.Action("Index") + "'</script>");
                }
            }
            else
           {

                return View("AdminLogin");
            }
           
        }
    }
}
