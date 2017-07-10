﻿using HotelDAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelBLL
{
    public class SuggestionManager
    {
        SuggestionService objsug = new SuggestionService();
        /// <summary>
        /// 提交投诉
        /// </summary>
        /// <param name="objSuggestion"></param>
        /// <returns></returns>
        public int SubmitSuggestion(Suggestion objSuggestion)
        {
            return objsug.SubmitSuggestion(objSuggestion);
        }
        /// <summary>
        /// 获取最新的建议
        /// </summary>
        /// <returns></returns>
        public List<Suggestion> GetSuggestion()
        {
            return objsug.GetSuggestion();
        }
        /// <summary>
        /// 受理投诉
        /// </summary>
        /// <param name="suggestionId"></param>
        /// <returns></returns>
        public int HandlSuggestion(string suggestionId)
        {
            return objsug.HandlSuggestion(suggestionId);
        }
    }
}
