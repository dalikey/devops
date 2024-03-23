using DevOps.Factories;
using DevOps.Visitors;

namespace DevOps.Tests.Factories {
    public class ActionVisitorTests {
        [Fact]
        public void Visit_AnalyseAction_Should_WriteToConsole() {
            // Arrange
            var visitor = new ActionVisitor();
            var analyseAction = new AnalyseAction { AnalyseTool = "CodeAnalyzer" };
            var expectedOutput = $"{analyseAction.AnalyseTool}: Executing code analysis";

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            visitor.Visit(analyseAction);

            // Assert
            Assert.Contains(expectedOutput, sw.ToString());
        }

        [Fact]
        public void Visit_DeployAction_Should_WriteToConsole() {
            // Arrange
            var visitor = new ActionVisitor();
            var deployAction = new DeployAction { DeploymentTarget = "Production" };
            var expectedOutput = $"{deployAction.DeploymentTarget}: Executing deployment tool";

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            visitor.Visit(deployAction);

            // Assert
            Assert.Contains(expectedOutput, sw.ToString());
        }

        [Fact]
        public void Visit_PackageAction_Should_WriteToConsole() {
            // Arrange
            var visitor = new ActionVisitor();
            var packageAction = new PackageAction { Dependencies = new List<string> { "Dependency1", "Dependency2" } };
            var expectedOutput = $"{string.Join(",", packageAction.Dependencies)}: Installing dependencies";

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            visitor.Visit(packageAction);

            // Assert
            Assert.Contains(expectedOutput, sw.ToString());
        }

    }
}
