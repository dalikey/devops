using DevOps.Factories;
using DevOps.Visitors;
using Moq;

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
        public void RunDependencyInstallation_Should_WriteToConsole() {
            // Arrange
            var deployAction = new DeployAction { DeploymentTarget = "Production" };
            var expectedOutput = $"{deployAction.DeploymentTarget}: Executing deployment tool";

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            deployAction.RunDependencyInstallation();

            // Assert
            Assert.Contains(expectedOutput, sw.ToString());
        }

        [Fact]
        public void CreateAction_Deploy_ReturnsDeployActionWithDefaultDeploymentTarget() {
            // Arrange
            var actionType = "Deploy";
            var expectedDeploymentTarget = "DefaultDeploymentTarget";
            var deployAction = new DeployAction();

            // Act
            var result = deployAction.CreateAction(actionType);

            // Assert
            Assert.IsType<DeployAction>(result);
            Assert.Equal(expectedDeploymentTarget, ((DeployAction)result).DeploymentTarget);
        }

        [Fact]
        public void CreateAction_InvalidActionType_ThrowsArgumentException() {
            // Arrange
            var actionType = "InvalidActionType";
            var deployAction = new DeployAction();

            // Act and Assert
            Assert.Throws<ArgumentException>(() => deployAction.CreateAction(actionType));
        }

        [Fact]
        public void Execute_Should_Run_Dependency_Installation() {
            //Arrange
            var deployAction = new DeployAction();
            var mockDeployAction = new Mock<DeployAction> { CallBase = true };
            mockDeployAction.Setup(m => m.RunDependencyInstallation()).Returns(true);

            //Act
            mockDeployAction.Object.Execute();

            //Assert
            mockDeployAction.Verify(m => m.RunDependencyInstallation(), Times.Once);
        }
    }
}
