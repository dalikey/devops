using DevOps.Factories;
using Moq;

namespace DevOps.Tests.Factories {
    public class BuildActionTests {
        [Fact]
        public void AcceptVisitor_Should_Invoke_VisitMethodOfVisitor() {
            // Arrange
            var buildAction = new BuildAction { BuildType = "Release" };
            var visitor = new MockActionVisitor();

            // Act
            buildAction.AcceptVisitor(visitor);

            // Assert
            Assert.True(visitor.VisitedBuildAction);
        }

        [Fact]
        public void RunBuild_Should_WriteToConsole() {
            // Arrange
            var buildAction = new BuildAction { BuildType = "Release" };
            var expectedOutput = $"{buildAction.BuildType}: Executing";

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            buildAction.RunBuild();

            // Assert
            Assert.Contains(expectedOutput, sw.ToString());
        }

        [Fact]
        public void CreateAction_Build_ReturnsBuildActionWithDefaultBuildType() {
            // Arrange
            var actionType = "Build";
            var expectedBuildType = "DefaultBuild";
            var buildAction = new BuildAction();

            // Act
            var result = buildAction.CreateAction(actionType);

            // Assert
            Assert.IsType<BuildAction>(result);
            Assert.Equal(expectedBuildType, ((BuildAction)result).BuildType);
        }

        [Fact]
        public void CreateAction_InvalidActionType_ThrowsArgumentException() {
            // Arrange
            var actionType = "InvalidActionType";
            var buildAction = new BuildAction();

            // Act and Assert
            Assert.Throws<ArgumentException>(() => buildAction.CreateAction(actionType));
        }

        [Fact]
        public void Execute_Should_Run_Build() {

            //Arrange
            var buildAction = new BuildAction();
            var mockBuildAction = new Mock<BuildAction> { CallBase = true };
            mockBuildAction.Setup(m => m.RunBuild()).Returns(true);

            //Act
            mockBuildAction.Object.Execute();

            //Assert
            mockBuildAction.Verify(m => m.RunBuild(), Times.Once);
        }
    }
}
