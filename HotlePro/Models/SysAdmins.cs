using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;


namespace Models
{
    [Serializable]
 public  class SysAdmins
    {
       [DisplayName("登录名")]
        [Required(ErrorMessage="{0}不能为空")]
        public int LoginId { get; set; }
        public string LoginName { get; set; }
        [DisplayName("密码")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string LoginPwd { get; set; }            
    }
}
