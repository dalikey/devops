using DevOps.Domain.Roles;
using DevOps.Strategies;
using Moq;

namespace DevOps.Tests.Domain {
    public class RolesTests {


        [Fact]
        public void Tester_Should_Match_Output_And_Be_Performed_Once() {

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
            Assert.Contains("Testing a task...", sw.ToString());            
        }

        [Fact]
        public void ScrumMaster_Should_Match_Output_And_Be_Performed_Once() {

            //Arrange
            var mockStrategy = new Mock<IRoleStrategy>();
            ScrumMaster scrumMaster = new ScrumMaster();
            scrumMaster.roleStrategy = mockStrategy.Object;

            using StringWriter sw = new();
            Console.SetOut(sw);

            //Act
            scrumMaster.Work();

            //Assert
            mockStrategy.Verify(s => s.PerformRole(), Times.Once);
            Assert.Contains("Managing a team or task...", sw.ToString());
        }

        [Fact]
        public void ProductOwner_Should_Match_Output_And_Be_Performed_Once() {

            //Arrange
            var mockStrategy = new Mock<IRoleStrategy>();
            ProductOwner productOwner = new ProductOwner();
            productOwner.roleStrategy = mockStrategy.Object;

            using StringWriter sw = new();
            Console.SetOut(sw);

            //Act
            productOwner.Work();

            //Assert
            mockStrategy.Verify(s => s.PerformRole(), Times.Once);
            Assert.Contains("Managing a team or task...", sw.ToString());
        }

        [Fact]
        public void LeadDeveloper_Should_Match_Output_And_Be_Performed_Once() {

            //Arrange
            var mockStrategy = new Mock<IRoleStrategy>();
            LeadDeveloper leadDeveloper = new LeadDeveloper();
            leadDeveloper.roleStrategy = mockStrategy.Object;

            using StringWriter sw = new();
            Console.SetOut(sw);

            //Act
            leadDeveloper.Work();

            //Assert
            mockStrategy.Verify(s => s.PerformRole(), Times.Once);
            Assert.Contains("Managing a team or task...", sw.ToString());
        }

        [Fact]
        public void Developer_Should_Match_Output_And_Be_Performed_Once() {

            //Arrange
            var mockStrategy = new Mock<IRoleStrategy>();
            Developer developer = new Developer();
            developer.roleStrategy = mockStrategy.Object;

            using StringWriter sw = new();
            Console.SetOut(sw);

            //Act
            developer.Work();

            //Assert
            mockStrategy.Verify(s => s.PerformRole(), Times.Once);
            Assert.Contains("Programming a new task...", sw.ToString());
        }
    }
}
