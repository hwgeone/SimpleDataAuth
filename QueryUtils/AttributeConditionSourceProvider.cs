using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.QueryUtils
{
    /// <summary>
    /// 可以对接自己系统的角色权限，这儿简化
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    public class AttributeConditionSourceProvider : ConditionSourceProvider
    {
        public AttributeConditionSourceProvider()
        {

        }

        public override List<ConditionPropery> Get<TSource>()
        {
            List<ConditionPropery> cps = new List<ConditionPropery>();

            Type sourceType = typeof(TSource);
            PropertyInfo[] props = sourceType.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    ConditionAttribute conAttr = attr as ConditionAttribute;

                    if (conAttr != null)
                    {
                        ConditionPropery conProp = new ConditionPropery();
                        conProp.Key.PropertyName = prop.Name;
                        conProp.Key.PropertyType = prop.PropertyType;
                        conProp.action = conAttr.action;
                        cps.Add(conProp);
                    }
                }
            }

            return cps;
        }
    }
}
