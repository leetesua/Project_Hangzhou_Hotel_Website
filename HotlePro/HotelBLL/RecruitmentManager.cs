using HotelDAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelBLL
{
    public class RecruitmentManager
    {
        RecruitmentService objRe = new RecruitmentService();
        /// <summary>
        /// 发布招聘信息
        /// </summary>
        /// <param name="objRecru"></param>
        /// <returns></returns>
        public int AddRecruitment(Recruitment objRecru)
        {
            return objRe.AddRecruitment(objRecru);
        }
        /// <summary>
        /// 查询所有职位列表信息
        /// </summary>
        /// <returns></returns>
        public List<Recruitment> GetAllRecList()
        {
            return objRe.GetAllRecList();
        }
        /// <summary>
        /// 根据发布编号查询详细职位信息
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public Recruitment GetPostById(string postId)
        {
            return objRe.GetPostById(postId);
        }
        /// <summary>
        /// 修改招聘信息
        /// </summary>
        /// <param name="objRecruitment"></param>
        /// <returns></returns>
        public int ModifyRecruiment(Recruitment objRecruitment)
        {
            return objRe.ModifyRecruiment(objRecruitment);
        }
        /// <summary>
        /// 删除招聘信息
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public int DeleteRecruiment(string postId)
        {
            return objRe.DeleteRecruiment(postId);
        }
    }
}
