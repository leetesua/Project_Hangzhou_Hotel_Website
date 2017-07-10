using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace HotelDAL
{
    /// <summary>
    /// 菜品预定管理数据访问
    /// </summary>
    public class DishBookService
    {
        /// <summary>
        /// 客户预定
        /// </summary>
        /// <param name="objDishBook"></param>
        /// <returns></returns>
        public int Book(DishBook objDishBook)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("INSERT INTO DishBook ");
            strsql.Append("(HotelName,ConsumeTime,ConsumePersons,");
            strsql.Append("RoomType,CustomerName,CustomerPhone,");
            strsql.Append("CustomerEmail,Comments)");
            strsql.Append("  VALUES (@HotelName,@ConsumeTime,@ConsumePersons,");
            strsql.Append("@RoomType,@CustomerName,@CustomerPhone,");
            strsql.Append("@CustomerEmail,@Comments)");
            SqlParameter[] param = new SqlParameter[]
           {
                  new SqlParameter("@HotelName",objDishBook.HotelName),
                  new SqlParameter("@ConsumeTime",objDishBook.ConsumeTime),
                  new SqlParameter("@ConsumePersons",objDishBook.ConsumePersons),
                  new SqlParameter("@RoomType",objDishBook.RoomType),
                  new SqlParameter("@CustomerName",objDishBook.CustomerName),
                  new SqlParameter("@CustomerPhone",objDishBook.CustomerPhone),
                  new SqlParameter("@CustomerEmail",objDishBook.CustomerEmail),
                  new SqlParameter("@Comments",objDishBook.Comments)
           };
            return SQLHelper.Update(strsql.ToString(), param);
        }
        /// <summary>
        /// 根据预定id修改订单状态
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="orderStatus"></param>
        /// <returns></returns>
        public int ModifyBook(string bookId, string orderStatus)
        {
            string sql = string.Format("UPDATE DishBook SET OrderStatus='{0}' WHERE BookId='{1}'", orderStatus, bookId);
            return SQLHelper.Update(sql);
        }
        /// <summary>
        /// 获取未关闭的订单或未审核的订单
        /// </summary>
        /// <returns></returns>
        public List<DishBook> GetAllDishBook()
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(" SELECT *  FROM DishBook WHERE OrderStatus=0 ");
            strsql.Append(" OR OrderStatus=1 ORDER BY BookTime DESC");
            List<DishBook> list = new List<DishBook>();
            SqlDataReader objReader = SQLHelper.GetReader(strsql.ToString());
            while (objReader.Read())
            {
                list.Add(new DishBook()
                {
                    HotelName = objReader["HotelName"].ToString(),
                    BookId = Convert.ToInt32(objReader["BookId"]),
                    CustomerName = objReader["CustomerName"].ToString(),
                    CustomerPhone = objReader["CustomerPhone"].ToString(),
                    CustomerEmail = objReader["CustomerEmail"].ToString(),
                    RoomType = objReader["RoomType"].ToString(),
                    ConsumePersons = Convert.ToInt32(objReader["ConsumePersons"].ToString()),
                    ConsumeTime = Convert.ToDateTime(objReader["ConsumeTime"]),
                    Comments = objReader["Comments"].ToString(),
                    BookTime = Convert.ToDateTime(objReader["BookTime"]),
                    OrderStatus = Convert.ToInt32(objReader["OrderStatus"])
                });
            }
            objReader.Close();
            return list;
        }
    }
}
