﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace KPI.SportStuffInternetShop.Contracts {
    public interface ISpecification<TEntity> {
        Expression<Func<TEntity, bool>> Criteria { get; }

        List<Expression<Func<TEntity, object>>> Includes { get; }

        Expression<Func<TEntity, object>> OrderBy { get; }

        Expression<Func<TEntity, object>> OrderByDescending { get; }

        int Take { get; }

        int Skip { get; }

        bool IsPagingEnabled { get; }
    }
}
