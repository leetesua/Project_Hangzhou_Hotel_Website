using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    [Serializable]
    /// <summary>
    /// 菜品表
    /// </summary>
 public   class Dishes
    {
        public int DishId { get; set; }
        public string DishName { get; set; }
        public int UnitPrice { get; set; }
        public int CategoryId { get; set; }
        public string DishImg { get; set; }
        public string CategoryName { get; set; }
    }
}
