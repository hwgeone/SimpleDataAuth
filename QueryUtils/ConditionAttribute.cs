using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.QueryUtils
{
    /// <summary>
    /// 这个应该放在自己业务项目中
    /// </summary>
    public class ConditionAttribute : Attribute
    {
        public ActionEntity action { get; set; }

        public ConditionAttribute()
        {
            action = new ActionEntity();
            action.AssemblyName = "Application";
            action.ClassName = "AuthUtil";
            action.MethodName = "GetCurrentUserSite";
        }
    }
}
