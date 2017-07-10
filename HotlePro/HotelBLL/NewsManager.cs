using HotelDAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelBLL
{
   public class NewsManager
    {
       NewsService objNewsService = new NewsService();
       /// <summary>
       /// 根据指定条数查询新闻信息
       /// </summary>
       /// <param name="count"></param>
       /// <returns></returns>
        public List<News> GetNews(int count)
        {
            return objNewsService.GetNews(count);
        }
        public string GetCategoryName(int categoryId) 
        {
            return objNewsService.GetCategoryName(categoryId);
        }
       /// <summary>
       /// 更新新闻
       /// </summary>
       /// <param name="objmodel"></param>
       /// <returns></returns>
        public int ModifyNews(News objmodel)
        {
            return objNewsService.ModifyNews(objmodel);
        }
         /// <summary>
        /// 获取新闻所有分类
        /// </summary>
        /// <returns></returns>
        public List<NewsCategory> GetAllCategory()
        {
            return objNewsService.GetAllCategory();
        }
       /// <summary>
       /// 删除新闻
       /// </summary>
       /// <param name="newsId"></param>
       /// <returns></returns>
        public int DelNews(string newsId)
        {
            return objNewsService.DelNews(newsId);
        }
         /// <summary>
        /// 分页查询新闻信息
        /// </summary>
        /// <param name="stuName"></param>
        /// <param name="pageSize"></param>
        /// <param name="currentCount"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>
        public List<News> GetNews(string CategoryId, int pageSize, int currentCount, out int TotalCount)
        {
            return objNewsService.GetNews(CategoryId, pageSize, currentCount, out TotalCount);
        }
       /// <summary>
       /// 根据id获取详情
       /// </summary>
       /// <param name="newsId"></param>
       /// <returns></returns>
        public News GetNewsById(string newsId)
        {
            return objNewsService.GetNewsById(newsId);
        }
       /// <summary>
       /// 发布新闻
       /// </summary>
       /// <param name="objNews"></param>
       /// <returns></returns>
        public int PublishNews(News objNews)
        {
            return objNewsService.PublishNews(objNews);
        }
    }
}
