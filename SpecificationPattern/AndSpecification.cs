using System;
using System.Linq.Expressions;

namespace SpecificationPattern
{
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        private ISpecification<T> leftSpecification;
        private ISpecification<T> rightSpecification;


        public AndSpecification(ISpecification<T> leftSpecification, ISpecification<T> rightSpecification)
        {
            this.leftSpecification = leftSpecification;
            this.rightSpecification = rightSpecification;
        }

        public override Expression<Func<T, bool>> SpecExpression
        {
            get
            {
                var objParam = Expression.Parameter(typeof(T), "objParam");

                return Expression.Lambda<Func<T, bool>>
                (
                    Expression.And
                    (
                        Expression.Invoke(this.leftSpecification.SpecExpression, objParam)
                        , Expression.Invoke(this.rightSpecification.SpecExpression, objParam)
                    ),
                    objParam                  
                );
            }
        }

    }
}