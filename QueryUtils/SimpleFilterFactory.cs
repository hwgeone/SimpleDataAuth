using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.QueryUtils
{
    public static class SimpleFilterFactory<TSource>
    {
        private static ConditionPropery curConProp;
        private static object lockobj = new object();
        public static Expression<Func<TSource, bool>> GetWhereExpression(ConditionPropery conProp)
        {
            return ExpressionHelper.GetMeberEqualValueLambda<TSource>(conProp);
        }

        public static Func<TSource, bool> GetWhereFunc(ConditionPropery conProp)
        {
            lock (lockobj)
            {
                curConProp = conProp;
            }
            return FuncMethod;
        }

        public static bool FuncMethod(TSource source)
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
        public ConditionPropery()
        {
            Key = new PropertyKey();
            action = new ActionEntity();
        }
        public PropertyKey Key { get; set; }
        public object PropertyValue { get; set; }
        public ActionEntity action { get; set; }
    }

    public class PropertyKey
    {
        public string PropertyName { get; set; }
        public Type PropertyType { get; set; }
    }
}
