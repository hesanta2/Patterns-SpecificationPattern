using System;
using System.Linq.Expressions;

namespace SpecificationPattern
{
    public class NotSpecification<T> : CompositeSpecification<T>
    {
        private ISpecification<T> specification;

        public NotSpecification(ISpecification<T> specification)
        {
            this.specification = specification;
        }

        public override Expression<Func<T, bool>> SpecExpression
        {
            get
            {
                var objParam = Expression.Parameter(typeof(T), "objParam");

                return Expression.Lambda<Func<T, bool>>
                (
                    Expression.Not
                    (
                        Expression.Invoke(this.specification.SpecExpression, objParam)
                    ),
                    objParam                  
                );
            }
        }

    }
}