using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.QueryUtils
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

        public override List<CustomBusinessTableForQuery> Get<TSource>()
        {
            List<CustomBusinessTableForQuery> qs = new List<CustomBusinessTableForQuery>();

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
                        qs.Add(
                            new CustomBusinessTableForQuery()
                            {
                                ClassName = sourceType.Name,
                                PropertyName = prop.Name
                            }
                        );
                    }
                }
            }

            return qs;
        }
    }
}
