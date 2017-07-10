using HotelBLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace Hotel.Areas.HotelAdmin.Controllers
{
     [Authorize]
    public class HotelNewsController : Controller
    {
        //
        // GET: /HotelAdmin/HotelNews/

        public ActionResult NewsPublish()
        {
            return View();
        }
        public ActionResult NewsUpDate(string newsId)
        {
            News objmodel = new NewsManager().GetNewsById(newsId);
            objmodel.NewsId = Convert.ToInt32(newsId);
            return View("NewsUpDate", objmodel);
        }
        [HttpGet]
        /// <summary>
        /// 新闻管理
        /// </summary>
        /// <returns></returns>
        public ActionResult NewManagers(int? id = 1)
        {
            int totalCount = 0;
            int pageIndex = id ?? 1;
            int pageSize = 6;
            PagedList<News> objlist = new NewsManager().GetNews("", pageSize, (pageIndex - 1) * 5, out totalCount).AsQueryable().ToPagedList(pageIndex, pageSize);
            objlist.TotalItemCount = totalCount;
            objlist.CurrentPageIndex = (int)(id ?? 1);
            Hotel.Models.Common info = new Hotel.Models.Common();
            info.objNewsModel = objlist;
            return View("NewManagers", info);
        }
        [HttpGet]
        public ActionResult DoDelNew(string newsId)
        {
           //调用BLL进行数据处理
            int res = new NewsManager().DelNews(newsId);
            if (res > 0)
            {
                return Content("<script>alert('新闻删除成功!');location.href='" + Url.Action("NewManagers") + "'</script>");
            }
            else {
                return Content("<script>alert('新闻删除失败!');location.href='" + Url.Action("NewManagers") + "'</script>");
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult DoNews(News objModel)
        {
            //数据验证（客户端验证） mvc视图模型验证
            //调用BLL进行数据处理
            objModel.PublishTime = DateTime.Now;
            int res = 0;
            if (objModel.NewsId != 0&& objModel.NewsId != null)   //修改操作
            {
                res = new NewsManager().ModifyNews(objModel);
                if (res > 0)
                {
                    return Content("<script>alert('新闻修改成功!');location.href='" + Url.Action("NewManagers") + "'</script>");
                }
                else
                {
                    return Content("<script>alert('新闻修改失败!');location.href='" + Url.Action("NewsUpDate") + "'</script>");
                }

            }
            else
            {
                res = new NewsManager().PublishNews(objModel);
                if (res > 0)
                {
                    return Content("<script>alert('新闻发布成功!');location.href='" + Url.Action("NewsPublish") + "'</script>");
                }
                else
                {
                    return Content("<script>alert('新闻发布失败!');location.href='" + Url.Action("NewsPublish") + "'</script>");
                }
            }

        }

    }
}
