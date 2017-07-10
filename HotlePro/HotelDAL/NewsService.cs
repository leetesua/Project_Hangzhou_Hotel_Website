using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HotelDAL
{
    public class NewsService
    { 
        
        
        /// <summary>
        /// 获取新闻所有分类
        /// </summary>
        /// <returns></returns>
        public List<NewsCategory> GetAllCategory()
        {
            string sql = "SELECT CategoryId,CategoryName FROM NewsCategory";
            List<NewsCategory> list = new List<NewsCategory>();
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            while (objReader.Read())
            {
                list.Add(new NewsCategory()
                {
                    CategoryId = Convert.ToInt32(objReader["CategoryId"]),
                    CategoryName = objReader["CategoryName"].ToString()
                });
            }
            objReader.Close();
            return list;
        }
        
        /// <summary>
        /// 查询指定的新闻条数
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<News> GetNews(int count)
        {
            string sql = "SELECT TOP (@COUNT)      NewsId,NewsTitle,NewsContents,PublishTime,NewsCategory.CategoryId,CategoryName FROM News INNER JOIN NewsCategory ON  NewsCategory.CategoryId=News.CategoryId ORDER BY PublishTime         DESC";
            SqlParameter[] param = new SqlParameter[]
          {
            new SqlParameter("@COUNT",count)
          };
            List<News> list = new List<News>();
            SqlDataReader objReader = SQLHelper.GetReader(sql, param);
            while (objReader.Read())
            {
                list.Add(new News()
                {
                    CategoryId = Convert.ToInt32(objReader["CategoryId"]),
                    CategoryName = objReader["CategoryName"].ToString(),
                    NewsContents = objReader["NewsContents"].ToString(),
                    NewsId = Convert.ToInt32(objReader["NewsId"]),
                    NewsTitle = objReader["NewsTitle"].ToString(),
                    PublishTime = Convert.ToDateTime(objReader["PublishTime"])
                });
            }
            objReader.Close();
            return list;
        }


        /// <summary>
        /// 发布新闻(调用存储过程实现)
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        public int PublishNews(News objmodel)
        {
            //[1]将对象的属性封装在参数数组里
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@NewsTitle",objmodel.NewsTitle),
                new SqlParameter("@NewsContents",objmodel.NewsContents),
                new SqlParameter("@PubulishTime",objmodel.PublishTime),
                new SqlParameter("@CategoryId",objmodel.CategoryId)
            };
            try
            {
                //[2]调用存储过程，返回结果
                return SQLHelper.UpdateByProcedure("usp_AddNews", param);
            }
            catch (SqlException e)
            {
                throw new Exception("数据库操作出现异常！具体信息:\r\n" + e.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        ///// <summary>
        ///// 发布新闻
        ///// </summary>
        ///// <param name="objNews"></param>
        ///// <returns></returns>
        //public int PublishNews(News objNews)
        //{
        //    string sql = "INSERT INTO News (NewsTitle,NewsContents,CategoryId) VALUES(@NewsTitle,@NewsContents,@CategoryId)";
        //    SqlParameter[] param = new SqlParameter[]
        //    {
        //        new SqlParameter("@NewsTitle",objNews.NewsTitle),
        //        new SqlParameter("@NewsContents",objNews.NewsContents),
        //        new SqlParameter("@CategoryId",objNews.CategoryId)
        //    };
        //    return SQLHelper.Update(sql, param);
        //}
        /// <summary>
        /// 根据id查询新闻详情
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        public News GetNewsById(string newsId)
        {
            string sql = "SELECT NewsId,NewsTitle,NewsContents,CategoryId,PublishTime FROM News  WHERE NewsId=@NewsId";
            SqlParameter[] param = new SqlParameter[] 
            {
             new SqlParameter("@NewsId",newsId)
            
            };
            News objNews = null;
            SqlDataReader objReader = SQLHelper.GetReader(sql, param);
            if (objReader.Read())
            {
                objNews = new News()
                {
                    CategoryId = Convert.ToInt32(objReader["CategoryId"]),                  
                    NewsContents = objReader["NewsContents"].ToString(),
                    NewsId = Convert.ToInt32(objReader["NewsId"]),
                    NewsTitle = objReader["NewsTitle"].ToString(),
                    PublishTime = Convert.ToDateTime(objReader["PublishTime"])
                };
            }
            objReader.Close();
            return objNews;
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
            string order = string.Format("PublishTime DESC");
            string TableName = string.Format("News");
            string Where = "1=1";
            if (!string.IsNullOrEmpty(CategoryId))
            {
                Where += string.Format("  And CategoryId='{0}'", CategoryId);
            }
            DataSet ds = SQLCommon.GetList(pageSize, order, currentCount, TableName, Where, out TotalCount);
            List<News> result = new List<News>();
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    result.Add(new News()
                    {
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        NewsContents = dr["NewsContents"].ToString(),
                        NewsId = Convert.ToInt32(dr["NewsId"]),
                        NewsTitle = dr["NewsTitle"].ToString(),
                        PublishTime = Convert.ToDateTime(dr["PublishTime"].ToString())
                    });
                }
            }
            return result;
        }
        /// <summary>
        /// 根据id查询name
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public string GetCategoryName(int categoryId)
        {
            string sql = string.Format("select CategoryName from NewsCategory where CategoryId={0}", categoryId);
            string categoryName = null;
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            if (objReader.Read())
            {
                categoryName = objReader["CategoryName"].ToString();
            }
            objReader.Close();
            return categoryName;
        }


        /// <summary>
        /// 新闻更新
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        public int ModifyNews(News objmodel)
        {
            try
            {
                string sql = string.Format("UPDATE News SET NewsTitle='{0}',NewsContents='{1}',PublishTime='{2}',CategoryId='{3}' WHERE NewsId={4}", objmodel.NewsTitle, objmodel.NewsContents, objmodel.PublishTime, objmodel.CategoryId, objmodel.NewsId);
                return SQLHelper.Update(sql);
            }
            catch (SqlException e)
            {
                throw new Exception("数据库操作出现异常！具体信息:\r\n" + e.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// 删除新闻
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        public int DelNews(string newsId)
        {
            try
            {
                string sql = "DELETE FROM News WHERE NewsId=@NewsId";
                SqlParameter[] param = new SqlParameter[] { new SqlParameter("@NewsId", newsId) };
                return SQLHelper.Update(sql, param);
            }
            catch (SqlException e)
            {
                throw new Exception("数据库操作出现异常！具体信息:\r\n" + e.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
