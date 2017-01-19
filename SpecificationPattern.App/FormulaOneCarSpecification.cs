using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationPattern.App
{
    public class FormulaOneCarSpecification : CompositeSpecification<Car>
    {

        public override Expression<Func<Car, bool>> SpecExpression
        {
            get
            {
                return (car =>
                            ((car.Type & Car.CarType.Competition) != 0)
                            && car.MaxSpeed > 200
                        );
            }
        }
    }
}
