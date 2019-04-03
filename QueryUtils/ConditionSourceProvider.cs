﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.QueryUtils
{
    public abstract class ConditionSourceProvider
    {
        public abstract List<ConditionPropery> Get<TSource>();
    }
}
