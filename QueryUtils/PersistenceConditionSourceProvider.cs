using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.QueryUtils
{
    public class PersistenceConditionSourceProvider:ConditionSourceProvider
    {
        public override List<CustomBusinessTableForQuery> Get<TSource>()
        {
            throw new NotImplementedException();
        }
    }
}
