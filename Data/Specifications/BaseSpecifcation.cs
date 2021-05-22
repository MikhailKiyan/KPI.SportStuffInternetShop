using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using KPI.SportStuffInternetShop.Contracts;

namespace KPI.SportStuffInternetShop.Data.Specifications {
    public class BaseSpecifcation<TEntity> : ISpecification<TEntity> {
        public BaseSpecifcation() { }

        public BaseSpecifcation(Expression<Func<TEntity, bool>> criteria) {
            this.Criteria = criteria;
        }

        public Expression<Func<TEntity, bool>> Criteria { get; }

        public List<Expression<Func<TEntity, object>>> Includes { get; } = new List<Expression<Func<TEntity, object>>>();

        public Expression<Func<TEntity, object>> OrderBy { get; private set; }

        public Expression<Func<TEntity, object>> OrderByDescending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; private set; }

        protected void AddInclude(
                Expression<Func<TEntity, object>> includeExpression) {
            this.Includes.Add(includeExpression);
        }

        protected void AddOrderBy(
                Expression<Func<TEntity, object>> orderByExpression) {
            this.OrderBy = orderByExpression;
        }

        protected void AddOrderByDescending(
                Expression<Func<TEntity, object>> orderByDescExpression) {
            this.OrderByDescending = orderByDescExpression;
        }

        protected void ApplyPaging(
                int skip,
                int take) {
            this.Skip = skip;
            this.Take = take;
            this.IsPagingEnabled = true;
        }
    }
}
