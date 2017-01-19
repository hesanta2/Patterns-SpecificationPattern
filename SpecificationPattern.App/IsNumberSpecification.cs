using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationPattern.App
{
    public class IsNumberSpecification : CompositeSpecification<int>
    {
        private int number;

        public IsNumberSpecification(int number)
        {
            this.number = number;
        }

        public override Expression<Func<int, bool>> SpecExpression
        {
            get
            {
                return (obj => obj == number);
            }
        }
    }
}
