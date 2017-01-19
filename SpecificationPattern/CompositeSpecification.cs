using System;

namespace SpecificationPattern
{
    public abstract class CompositeSpecification<T> : ISpecification<T>
    {

        public abstract System.Linq.Expressions.Expression<Func<T, bool>> SpecExpression { get; }

        public bool IsSatisfiedBy(T obj)
        {
            return this.SpecExpression.Compile()(obj);
        }

        public ISpecification<T> And(ISpecification<T> other)
        {
            return new AndSpecification<T>(this, other);
        }

        public ISpecification<T> Or(ISpecification<T> other)
        {
            return new OrSpecification<T>(this, other);
        }

        public ISpecification<T> Not()
        {
            return new NotSpecification<T>(this);
        }
    }
}