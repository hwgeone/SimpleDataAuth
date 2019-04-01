using Application.SSO;
using Domain.Enitties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EnumModels;

namespace Application.QueryUtils
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
            object value = new object();
            foreach (var condProp in conditionsProps)
            {
                string name = condProp.Key.PropertyName;
                _builder.AddConditionValue(name, value);
            }

            return this;
        }
    }
}
