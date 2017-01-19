using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace SpecificationPattern.Test
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void And_Specification_True_AND_True_Is_True()
        {
            bool expected = true;

            ISpecification<bool> andSpecification = MockRepository.GenerateMock<ISpecification<bool>>();
            andSpecification.Expect(t => t.IsSatisfiedBy(true)).Return(true);


            ISpecification<bool> result = andSpecification;

            Assert.AreEqual(true, result.IsSatisfiedBy(true));
        }
    }
}
