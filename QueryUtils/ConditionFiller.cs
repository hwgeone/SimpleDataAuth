using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Common.QueryUtils
{
    /// <summary>
    /// 根据角色填充查询值
    /// </summary>
    public class ConditionFiller<TSource> where TSource : class
    {
        private ConditionProperyCollectionBuilder<TSource> _builder;

        public ConditionFiller()
        {

        }

        public ConditionFiller<TSource> Init(ConditionProperyCollectionBuilder<TSource> builder)
        {
            _builder = builder;

            return this;
        }

        public ConditionFiller<TSource> FillConditionsValue()
        {
            List<ConditionPropery> conditionsProps = _builder.Get();

            foreach (var condProp in conditionsProps)
            {
                object value = new object();
                ActionEntity action = condProp.action;
                try
                {
                    var executingPath = ConfigHelper.GetExecutingDirectory();
                    var assemblyTypes = Assembly.Load(action.AssemblyName).GetTypes();
                    Type outerClass = assemblyTypes
                                            .Single(t => !t.IsInterface && t.Name == action.ClassName);
                    object instance = Activator.CreateInstance(outerClass, action.MethodParams.ConstructorParameters);
                    MethodInfo mi = outerClass.GetMethod(action.MethodName);
                    value = mi.Invoke(instance, action.MethodParams.MethodParameters);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                string name = condProp.Key.PropertyName;
                _builder.AddConditionValue(name, value);
            }

            return this;
        }
    }
}
