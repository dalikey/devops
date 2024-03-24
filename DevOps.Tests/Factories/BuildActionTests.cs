using DevOps.Factories;

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
    }
}
