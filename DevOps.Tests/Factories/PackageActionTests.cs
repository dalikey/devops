using DevOps.Factories;
using Moq;

namespace DevOps.Tests.Factories {
    public class PackageActionTests {
        [Fact]
        public void AcceptVisitor_Should_Invoke_VisitMethodOfVisitor() {
            // Arrange
            var packageAction = new PackageAction { Dependencies = new List<string> { "Dependency1", "Dependency2" } };
            var visitor = new MockActionVisitor();

            // Act
            packageAction.AcceptVisitor(visitor);

            // Assert
            Assert.True(visitor.VisitedPackageAction);
        }

        [Fact]
        public void RunDependencyInstallation_Should_WriteToConsole() {
            // Arrange
            var dependencies = new List<string> { "Dependency1", "Dependency2" };
            var packageAction = new PackageAction { Dependencies = dependencies };
            var expectedOutput = $"{string.Join(",", dependencies)}: Installing dependencies";

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            packageAction.RunDependencyInstallation();

            // Assert
            Assert.Contains(expectedOutput, sw.ToString());
        }

        [Fact]
        public void Execute_Should_Run_Dependency_Installation() {
            //Arrange
            var deployAction = new PackageAction();
            var mockPackageAction = new Mock<PackageAction> { CallBase = true };
            mockPackageAction.Setup(m => m.RunDependencyInstallation()).Returns(true);

            //Act
            mockPackageAction.Object.Execute();

            //Assert
            mockPackageAction.Verify(m => m.RunDependencyInstallation(), Times.Once);
        }
    }
}
