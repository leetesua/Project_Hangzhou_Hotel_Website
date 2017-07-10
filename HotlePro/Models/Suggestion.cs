using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace Models
{
    /// <summary>
    /// 投诉建议实体类
    /// </summary>
    [Serializable]
    public class Suggestion
    {
        public int SuggestionId { get; set; }
        [DisplayName("客户姓名")]
        [Required(ErrorMessage="{0}不能为空")]
        public string CustomerName { get; set; }
        [DisplayName("消费情况")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string ConsumeDesc { get; set; }
        [DisplayName("投诉建议详情")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string SuggestionDesc { get; set; }
        public DateTime SuggestTime { get; set; }
        [DisplayName("手机号")]
        [Required(ErrorMessage = "{0}不能为空")]
        [RegularExpression(@"^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$",ErrorMessage="请输入正确的{0}")]
        public string PhoneNumber { get; set; }
        [DisplayName("电子邮件")]
        [Required(ErrorMessage = "{0}不能为空")]
        [RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "请输入正确的{0}")]
        public string Email { get; set; }
        public int StatusId { get; set; }
    }
}
