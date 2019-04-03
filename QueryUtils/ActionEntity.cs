using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Common.QueryUtils
{
    public class ActionEntity
    {
        #region 属性列表
        /// <summary>
        /// 程序集)
        /// </summary>
        public string AssemblyName { get; set; }
        public string ClassName { get; set; }
        /// <summary>
        /// 方法名称
        /// </summary>
        public string MethodName { get; set; }

        public ActionParameterpublic MethodParams { get; set; }

        public ActionEntity()
        {
            MethodParams = new ActionParameterpublic();
        }
        #endregion
    }
}
