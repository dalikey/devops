using DevOps.Factories;

namespace DevOps.Tests.Factories {
    public class DeployActionTests {
        [Fact]
        public void AcceptVisitor_Should_Invoke_VisitMethodOfVisitor() {
            // Arrange
            var deployAction = new DeployAction { DeploymentTarget = "Production" };
            var visitor = new MockActionVisitor();

            // Act
            deployAction.AcceptVisitor(visitor);

            // Assert
            Assert.True(visitor.VisitedDeployAction);
        }

        [Fact]
        public void RunDeploymentTarget_Should_WriteToConsole() {
            // Arrange
            var deployAction = new DeployAction { DeploymentTarget = "Production" };
            var expectedOutput = $"{deployAction.DeploymentTarget}: Executing deployment tool";

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            deployAction.RunDeploymentTarget();

            // Assert
            Assert.Contains(expectedOutput, sw.ToString());
        }
    }
}
