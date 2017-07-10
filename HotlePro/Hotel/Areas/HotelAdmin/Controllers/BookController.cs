using HotelBLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Areas.HotelAdmin.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        //
        // GET: /HotelAdmin/Book/

        public ActionResult BookManagers()
        {
            List<DishBook> objlist = new DishBookManager().GetAllDishBook();
            ViewBag.list = objlist;
            return View();
        }
        /// <summary>
        /// 修改订单状态
        /// </summary>
        /// <param name="statId">订单状态参数</param>
        /// <param name="BookId">预订状态id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DoUpdate(string statId, string BookId) 
        {
            try
            {
                //调用BLL进行数据处理 修改订单状态
                int res = new DishBookManager().ModifyBook(BookId, statId);
                if (res > 0)
                {
                    return Content("<script>alert('订单状态修改完成!');location.href='" + Url.Action("BookManagers") + "'</script>");
                }
                else {
                    return Content("<script>alert('订单状态修改失败!');location.href='" + Url.Action("BookManagers") + "'</script>");
                }
            }
            catch (Exception ex)
            {
                return Content("<script>alert('"+ex.Message+"');location.href='" + Url.Action("BookManagers") + "'</script>");
              
            }
        }

    }
}
