using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationPattern.App
{
    class Program
    {
        static void Main(string[] args)
        {

            ISpecification<int> spec1 = new IsNumberSpecification(2);
            ISpecification<int> spec2 = new IsPairNumberSecification();

            ISpecification<int> resultSpec = spec1.And(spec2).Not().Or(spec1);

            Console.WriteLine($"{resultSpec.SpecExpression} = {resultSpec.IsSatisfiedBy(2)}");
        }
    }
}
