using HotelDAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelBLL
{
    /// <summary>
    /// 菜品预定业务逻辑层
    /// </summary>
    public class DishBookManager
    {
        DishBookService objDishBookS = new DishBookService();
        /// <summary>
        /// 客户预定
        /// </summary>
        /// <param name="objDishBook"></param>
        /// <returns></returns>
        public int Book(DishBook objDishBook)
        {
            return objDishBookS.Book(objDishBook);
        }
        /// <summary>
        /// 根据预定id修改订单状态
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="orderStatus"></param>
        /// <returns></returns>
        public int ModifyBook(string bookId, string orderStatus)
        {
            return objDishBookS.ModifyBook(bookId, orderStatus);
        }
        /// <summary>
        /// 获取未关闭的订单
        /// </summary>
        /// <returns></returns>
        public List<DishBook> GetAllDishBook()
        {
            return objDishBookS.GetAllDishBook();
        }
    }
}
