using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationPattern.App
{
    public class ConventionalCarSpecification : CompositeSpecification<Car>
    {

        public override Expression<Func<Car, bool>> SpecExpression
        {
            get
            {
                return (car =>
                            car.Type == Car.CarType.Normal
                            && car.MaxSpeed <= 220
                            && car.Doors > 1
                            && car.Doors < 6
                        );
            }
        }
    }
}
