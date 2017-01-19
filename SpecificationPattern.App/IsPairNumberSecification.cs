using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationPattern.App
{
    public class IsPairNumberSecification : CompositeSpecification<int>
    {

        public override Expression<Func<int, bool>> SpecExpression
        {
            get
            {
                return (obj => obj % 2 == 0);
            }
        }
    }
}
