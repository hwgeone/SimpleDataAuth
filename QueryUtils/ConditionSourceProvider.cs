using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.QueryUtils
{
    public abstract class ConditionSourceProvider
    {
        public abstract List<CustomBusinessTableForQuery> Get<TSource>();
    }
}
