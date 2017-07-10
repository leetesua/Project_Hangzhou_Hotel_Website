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
    public class DishsController : Controller
    {
        //
        // GET: /HotelAdmin/Dishs/

        public ActionResult DishesPublish()
        {
            return View();
        }
        /// <summary>
        /// 发布菜品
        /// </summary>
        /// <param name="objModel"></param>
        /// <param name="DishImg"></param>
        /// <returns></returns>
        public ActionResult DoAdd(Dishes objModel, HttpPostedFileBase DishImg) 
        {
                //判断文件是否上传成功（文件大小、文件名重命名）
            try
            {
                    //判断是否有文件
                if (DishImg != null && DishImg.FileName != "")
                {
                    //判断文件大小是否符合要求
                    double fileLength = DishImg.ContentLength / (1024.0 * 1024.0);
                    if (fileLength > 2.0)
                    {
                        return Content("<script>alert('图片最大不能超过2MB');loaction.href='" + Url.Action("DishesPublish") + "'</script>");
                    }
                    //获取文件名/重命名
                    string fileName = DishImg.FileName;
                    fileName = DateTime.Now.ToString("yyyyMMddmmhhss") + ".png";
                    objModel.DishImg = fileName;
                    int res = 0;

                    //判断是修改还是新增 
                    if (objModel.DishId != 0&& objModel.DishId != null)  //代表用户要做修改菜品
                    {
                        //调用BLL进行内容修改到数据库
                        res = new DishMananger().ModifyDish(objModel);
                        if (res > 0)
                        {
                            //[3]成功我们再上传图片到项目文件底下
                            string filePath = Server.MapPath("~/UploadFile/" + fileName);
                            DishImg.SaveAs(filePath);
                            return Content("<script>alert('菜品修改成功!');location.href='" + Url.Action("DishesManager") + "'</script>");
                        }
                        else
                        {
                            return Content("<script>alert('菜品修改失败!');location.href='" + Url.Action("DishesPublish") + "'</script>");
                        }
                    }
                    else {  //新增菜品
                        //调用BLL进行内容插入到数据库成功
                        res = new DishMananger().AddDish(objModel);
                        if (res > 0)
                        {
                            //[3]成功我们再上传图片到项目文件底下
                            string filePath = Server.MapPath("~/UploadFile/" + fileName);
                            DishImg.SaveAs(filePath);
                            return Content("<script>alert('菜品上传成功!');location.href='" + Url.Action("DishesPublish") + "'</script>");
                        }
                        else
                        {
                            return Content("<script>alert('菜品上传失败!');location.href='" + Url.Action("DishesPublish") + "'</script>");
                        }
                    
                    }                   
                }
                else
                {
                    return Content("<script>alert('请选择上传的图片!');location.href='" + Url.Action("DishesPublish") + "'</script>");
                }
            }
            catch (Exception ex)
            {
                return Content("<script>alert('程序出错'"+ex.Message+");location.href='" + Url.Action("DishesPublish") + "'</script>");
            }  
        }
        /// <summary>
        /// 菜品分页查询
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DishesManager(string CategoryId, int? id = 1)
        {
            int totalCount = 0;
            int pageIndex = id ?? 1;
            int pageSize = 6;
            PagedList<Dishes> objlist =new DishMananger().GetDishes(CategoryId, pageSize, (pageIndex - 1) * 5, out totalCount).AsQueryable().ToPagedList(pageIndex, pageSize);
            objlist.TotalItemCount = totalCount;
            objlist.CurrentPageIndex = (int)(id ?? 1);
            Hotel.Models.Common info=new    Hotel.Models.Common();     
            info.Dishes = objlist;
            return View("DishesManager", info);          
        }
        /// <summary>
        /// 删除菜品对象
        /// </summary>
        /// <param name="disId"></param>
        /// <returns></returns>
        public ActionResult DelDish(string disId) 
        {
            //调用BLL进行数据处理
            //先根据id查询对象模型
            Dishes objModel=new DishMananger().GetDishById(disId);
            string filePath=Server.MapPath("~/UploadFile/"+objModel.DishImg);
            int res = new DishMananger().DelDish(disId);
            if (res > 0)
            {
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                return Content("删除成功!");
            }
            else
            {
                return Content("删除失败!");
            }
        }
    
    }
}
