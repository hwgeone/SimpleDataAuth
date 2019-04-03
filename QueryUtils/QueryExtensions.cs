using Application.QueryUtils;
using Application.SSO;
using Common.QueryUtils;
using Models.EnumModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.QueryUtils
{
    /// <summary>
    /// 对接自己项目的权限接口（很复杂），这么只是简化
    /// </summary>
    public static class QueryExtensions
    {
        static bool readAll;
        static QueryExtensions()
        {
            var userContex = AuthUtil.GetCurrentUser();
            
            List<string> rights = userContex.Rights.Select(a => a.Name).ToList();
            if (rights.Contains(Rights.ReadAll))
            {
                readAll = true;
            }
        }

        public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source) where TSource : class
        {
            ConditionProperyCollectionBuilder<TSource> builder = new ConditionProperyCollectionBuilder<TSource>();
            builder.SetRights(readAll);
            ConditionFiller<TSource> filter = new ConditionFiller<TSource>().Init(builder).FillConditionsValue();
            List<ConditionPropery> conProps = builder.Get();
            foreach (var conProp in conProps)
            {
                source = source.Where(SimpleFilterFactory<TSource>.GetWhereExpression(conProp));
            }

            return source;
        }

        public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source) where TSource : class
        {
            ConditionProperyCollectionBuilder<TSource> builder = new ConditionProperyCollectionBuilder<TSource>();
            builder.SetRights(readAll);
            ConditionFiller<TSource> filter = new ConditionFiller<TSource>().Init(builder).FillConditionsValue();
            List<ConditionPropery> conProps = builder.Get();
            foreach (var conProp in conProps)
            {
                source = source.Where(SimpleFilterFactory<TSource>.GetWhereFunc(conProp));
            }

            return source;
        }
    }
}
