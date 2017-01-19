using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationPattern.App
{
    public class SportCarSpecification : CompositeSpecification<Car>
    {

        public override Expression<Func<Car, bool>> SpecExpression
        {
            get
            {
                return (car =>
                            ((car.Type & Car.CarType.Sport) != 0)
                            && car.MaxSpeed >= 250
                            && car.Doors <= 2
                        );
            }
        }
    }
}
