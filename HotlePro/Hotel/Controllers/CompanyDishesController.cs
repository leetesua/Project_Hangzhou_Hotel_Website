using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.Models;
using Models;
using HotelBLL;
using Webdiyer.WebControls.Mvc;

namespace Hotel.Controllers
{
    public class CompanyDishesController : Controller
    {
        //
        // GET: /CompanyDishes/

        public ActionResult DishesBooks()
        {
            return View();
        }
        public ActionResult Environment() 
        {
            return View();
        }
        /// <summary>
        /// 美食展示分页
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DishesShow(int? id=1) 
        {
            int totalCount=0;
            int pageIndex=id??1;
            int pageSize=6;
          PagedList<Dishes> objlist=new DishMananger().GetDishes("",pageSize,(pageIndex-1)*6,out totalCount).AsQueryable().ToPagedList(pageIndex,pageSize);
          objlist.TotalItemCount = totalCount;
          objlist.CurrentPageIndex = (int)(id ?? 1);
          Hotel.Models.Common info = new Hotel.Models.Common();
          info.Dishes = objlist;
            return View("DishesShow",info);
        }
        /// <summary>
        /// 在线预订
        /// </summary>
        /// <param name="objDish"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DoAdd(DishBook objDish)
        {
            ////调用BLL业务逻辑层  新增数据
            objDish.BookTime = DateTime.Now;
           int res = new DishBookManager().Book(objDish);
           if (res > 0)
           {
               return Content("success");
           }
           else
           {
               return Content("error");
           }          
        }
        /// <summary>
        ///验证码判断 
        /// </summary>
        /// <returns></returns>
        public ActionResult ExsitsValidate()
        {
            string txtValidateCode = Request["value"];          
            if (String.Compare(Session["ValidateCode"].ToString(), txtValidateCode, true) != 0)
            {                
                return Content("0");  //0代表验证码不正确
            }
            else
            {
                return Content("1"); //1代表正确
            }
        }
        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult ValidateCode() 
        {
            CreateValidateCode objCreate = new CreateValidateCode();
            string code = objCreate.CreateRandomCode(6);
            Session["ValidateCode"] = code;         
            return File(objCreate.CreateValidateGraphic(code), "images/jpeg");
        }
    }
}
