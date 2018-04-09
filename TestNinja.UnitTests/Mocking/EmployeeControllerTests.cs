using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using TestNinja.Mocking;


namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    class EmployeeControllerTests_DeleteEmployee
    {
        private Mock<IEmployeeRepository> _empRepository;
        private EmployeeController _empController;

        [SetUp]
        public void Setup()
        {
            _empRepository = new Mock<IEmployeeRepository>();
            _empController = new EmployeeController(_empRepository.Object);
        }

        [Test]
        public void WhenIDPassed_CallEmployeeRepository()
        {

            _empController.DeleteEmployee(1);

            _empRepository.Verify(er => er.DeleteEmployee(1));
        }

        [Test]
        public void WhenIDPassed_ReturnsRedirectResult()
        {
            var result = _empController.DeleteEmployee(1);

            Assert.That(result, Is.InstanceOf(typeof(RedirectResult)));
        }


    }
}
