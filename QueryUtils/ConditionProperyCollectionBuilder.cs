using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.QueryUtils
{
    public class ConditionProperyCollectionBuilder<TSource> where TSource:class
    {
        private bool _readAll;
        List<ConditionPropery> conProps = new List<ConditionPropery>();

        public ConditionProperyCollectionBuilder()
        {
           
        }

        public ConditionProperyCollectionBuilder<TSource> AddConditionValue(string name,object value)
        {
            ConditionPropery conp = conProps.FirstOrDefault(cp=>cp.Key.PropertyName == name);
            if (conp != null)
            {
                conp.PropertyValue = value;
            }

            return this;
        }

        /// <summary>
        /// 通过外部接口，判断是否需要添加查询条件
        /// </summary>
        /// <param name="readAll"></param>
        public void SetRights(bool readAll)
        {
            _readAll = readAll;
        }

        public List<ConditionPropery> Get()
        {
            if (!conProps.Any())
            {
                if (!_readAll)
                {
                    AttributeConditionSourceProvider prodiver = new AttributeConditionSourceProvider();
                    List<CustomBusinessTableForQuery> conditionSource = prodiver.Get<TSource>();
                    foreach (var cbtfq in conditionSource)
                    {
                        Type properTy = typeof(TSource).GetProperty(cbtfq.PropertyName).PropertyType;
                        conProps.Add(
                                new ConditionPropery()
                                {
                                    Key = new PropertyKey()
                                    {
                                        PropertyName = cbtfq.PropertyName,
                                        PropertyType = properTy
                                    },
                                });
                    }
                }
            }
            return conProps;
        }
    }
}
