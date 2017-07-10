using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace HotelDAL
{
    /// <summary>
    /// 分页通用类
    /// </summary>

    public class SQLCommon
    {
        /// <summary>
        /// 通用分页存储过程，有条件查询，有排序字段，按照排序字段的降序或升序
        /// </summary>
        /// <param name="PageSize">每页显示条数</param>
        /// <param name="CurrentCount">当前记录数量</param>
        /// <param name="TableName">表名称</param>
        /// <param name="where">查询条件</param>
        /// <param name="TotalCount">记录总数</param>
        /// <param name="Order">升降序排序</param>
        /// <returns></returns>
        public static DataSet GetList(int PageSize, string Order, int CurrentCount, string TableName, string where, out int TotalCount)
        {
            SqlParameter[] parmlist =
            {
                      new  SqlParameter("@PageSize",PageSize),       
                      new  SqlParameter("@CurrentCount",CurrentCount),
                      new  SqlParameter("@TableName",TableName),      
                      new  SqlParameter("@where",where),   
                      new  SqlParameter("@TotalCount",SqlDbType.Int,4),    
                      new  SqlParameter("@Order",Order)     
            };
            parmlist[4].Direction = ParameterDirection.Output;
            DataSet ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "prPager", parmlist);
            TotalCount = Convert.ToInt32(parmlist[4].Value);
            return ds;
        }
    }
}
