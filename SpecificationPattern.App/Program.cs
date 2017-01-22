using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationPattern.App
{
    class Program
    {
        private static ISpecification<Car> formulaOneSpec = new FormulaOneCarSpecification();
        private static ISpecification<Car> sportCarSpec = new SportCarSpecification();
        private static ISpecification<Car> conventionalCarSpec = new ConventionalCarSpecification();

        private static ISpecification<Car> conventionalNotSportCarSpec = conventionalCarSpec.And(sportCarSpec.Not());
        private static ISpecification<Car> sportNotConventionalCarSpec = sportCarSpec.And(conventionalCarSpec.Not());
        private static ISpecification<Car> formulaOneSportNotConventionalCarSpec = formulaOneSpec.And(sportCarSpec).And(conventionalCarSpec.Not());

        static void Main(string[] args)
        {
            Car ferrariFormulaOne = new Car("Ferrari Formula One")
            {
                Type = Car.CarType.Competition | Car.CarType.Sport,
                MaxSpeed = 370,
                Doors = 0
            };

            Car audiR8 = new Car("Audi R8")
            {
                Type = Car.CarType.Sport,
                MaxSpeed = 335,
                Doors = 2
            };

            Car seatLeon = new Car("Seat Leon")
            {
                Type = Car.CarType.Normal,
                MaxSpeed = 220,
                Doors = 5
            };

            CheckSpecifications(ferrariFormulaOne);
            CheckSpecifications(audiR8);
            CheckSpecifications(seatLeon);
        }

        public static void CheckSpecifications(Car car)
        {
            Console.Write($@"
{car}
    - Is 'Conventional car' = {(conventionalCarSpec.IsSatisfiedBy(car) ? "YES" : "NO")}
    - Is 'Sport car' = {(sportCarSpec.IsSatisfiedBy(car) ? "YES" : "NO")}
    - Is 'Formula one car' = {(formulaOneSpec.IsSatisfiedBy(car) ? "YES" : "NO")}
    - Is 'Conventional car' AND NOT 'Sport car' = {(conventionalNotSportCarSpec.IsSatisfiedBy(car) ? "YES" : "NO")}
    - Is 'Sport car' AND NOT 'Conventional car' = {(sportNotConventionalCarSpec.IsSatisfiedBy(car) ? "YES" : "NO")}
    - Is 'Formula one' AND 'Sport car' AND NOT 'Conventional car' = {(formulaOneSportNotConventionalCarSpec.IsSatisfiedBy(car) ? "YES" : "NO")}
");
        }
    }
}
