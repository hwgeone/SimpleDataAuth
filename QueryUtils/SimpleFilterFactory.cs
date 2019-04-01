using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.QueryUtils
{
    public static class SimpleFilterFactory<TSource>
    {
        private static ConditionPropery curConProp;

        public static Expression<Func<TSource, bool>> GetWhereExpression(ConditionPropery conProp)
        {
            return ExpressionHelper.GetMeberEqualValueLambda<TSource>(conProp);
        }

        public static Func<TSource, bool> GetWhereFunc(ConditionPropery conProp)
        {
            curConProp = conProp;
            Func<TSource, bool> func = FuncMethod;
            return func;
        }

        private static bool FuncMethod(TSource source)
        {
            Type sourceType = typeof(TSource);
            PropertyInfo prop = sourceType.GetProperty(curConProp.Key.PropertyName);
            Object propObj = prop.GetValue(source);
            if (propObj == null)
                return false;
            if (propObj.Equals(curConProp.PropertyValue))
                return true;
            return false;
        }
    }

    public class ConditionPropery
    {
        public PropertyKey Key { get; set; }
        public object PropertyValue { get; set; }
    }

    public class PropertyKey
    {
        public string PropertyName { get; set; }
        public Type PropertyType { get; set; }
    }
}
