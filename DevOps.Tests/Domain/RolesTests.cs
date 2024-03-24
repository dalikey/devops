using DevOps.Domain.Roles;
using DevOps.Strategies;
using Moq;

namespace DevOps.Tests.Domain {
    public class RolesTests {


        [Fact]
        public void Tester_Should_Be_Performed_Once() {

            //Arrange
            var mockStrategy = new Mock<IRoleStrategy>();
            Tester tester = new Tester();
            tester.roleStrategy = mockStrategy.Object;

            using StringWriter sw = new();
            Console.SetOut(sw);

            //Act
            tester.Work();

            //Assert
            mockStrategy.Verify(s => s.PerformRole(), Times.Once);
        }

        [Fact]
        public void ScrumMaster_Should_Be_Performed_Once() {

            //Arrange
            var mockStrategy = new Mock<IRoleStrategy>();
            ScrumMaster scrumMaster = new ScrumMaster();
            scrumMaster.roleStrategy = mockStrategy.Object;

            //Act
            scrumMaster.Work();

            //Assert
            mockStrategy.Verify(s => s.PerformRole(), Times.Once);
        }

        [Fact]
        public void ProductOwner_Should_Be_Performed_Once() {

            //Arrange
            var mockStrategy = new Mock<IRoleStrategy>();
            ProductOwner productOwner = new ProductOwner();
            productOwner.roleStrategy = mockStrategy.Object;

            //Act
            productOwner.Work();

            //Assert
            mockStrategy.Verify(s => s.PerformRole(), Times.Once);
        }

        [Fact]
        public void LeadDeveloper_Should_Be_Performed_Once() {

            // Arrange
            var mockStrategy = new Mock<IRoleStrategy>();
            mockStrategy.Setup(s => s.PerformRole()).Verifiable();
            LeadDeveloper leadDeveloper = new LeadDeveloper();
            leadDeveloper.roleStrategy = mockStrategy.Object;

            // Act
            leadDeveloper.Work();

            // Assert
            mockStrategy.Verify(s => s.PerformRole(), Times.Once);
        }

        [Fact]
        public void Developer_Should_Be_Performed_Once() {

            //Arrange
            var mockStrategy = new Mock<IRoleStrategy>();
            Developer developer = new Developer();
            developer.roleStrategy = mockStrategy.Object;

            //Act
            developer.Work();

            //Assert
            mockStrategy.Verify(s => s.PerformRole(), Times.Once);
        }
    }
}
