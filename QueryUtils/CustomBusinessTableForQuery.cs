using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.QueryUtils
{
    /// <summary>
    /// 可以自己根据业务实现持久化的表  表示某角色看某个表（或关联之后的结果集）的时候哪些字段参与查询。
    /// 类似管理员的角色，如果能看到全部数据，即不需要查询条件，那么提供一个空值
    /// </summary>
    public class CustomBusinessTableForQuery
    {
        /// <summary>
        /// 类的名称 类可以对应一个表或对应一个结果集
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 类参与查询的属性名称
        /// </summary>
        public string PropertyName { get; set; }
    }
}
