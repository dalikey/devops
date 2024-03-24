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

        [Fact]
        public void Visit_BuildAction_Should_WriteToConsole() {
            // Arrange
            var visitor = new ActionVisitor();
            var buildAction = new BuildAction { BuildType = "Release" };
            var expectedOutput = $"{buildAction.BuildType}: Executing build";

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            visitor.Visit(buildAction);

            // Assert
            Assert.Contains(expectedOutput, sw.ToString());
        }

        [Fact]
        public void Visit_SourcesAction_Should_WriteToConsole() {
            // Arrange
            var visitor = new ActionVisitor();
            var sourcesAction = new SourcesAction { GitURL = "https://github.com/repo" };
            var expectedOutput = $"{sourcesAction.GitURL}: Cloning repository";

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            visitor.Visit(sourcesAction);

            // Assert
            Assert.Contains(expectedOutput, sw.ToString());
        }

        [Fact]
        public void Visit_TestAction_Should_WriteToConsole() {
            // Arrange
            var visitor = new ActionVisitor();
            var testAction = new TestAction { TestFramework = "NUnit" };
            var expectedOutput = $"{testAction.TestFramework}: Running test framework";

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            visitor.Visit(testAction);

            // Assert
            Assert.Contains(expectedOutput, sw.ToString());
        }

        [Fact]
        public void Visit_UtilityAction_Should_WriteToConsole() {
            // Arrange
            var visitor = new ActionVisitor();
            var utilityAction = new UtilityAction { Actions = new List<string> { "Action1", "Action2" } };
            var expectedOutput1 = "Action1: Running utility action";
            var expectedOutput2 = "Action2: Running utility action";

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            visitor.Visit(utilityAction);

            // Assert
            Assert.Contains(expectedOutput1, sw.ToString());
            Assert.Contains(expectedOutput2, sw.ToString());
        }

        [Fact]
        public void Visit_DeploymentPipeline_Should_WriteToConsole() {
            // Arrange
            var visitor = new ActionVisitor();
            var deploymentPipeline = new DeploymentPipeline();
            var expectedOutput = "Executing deployment pipeline";

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            visitor.Visit(deploymentPipeline);

            // Assert
            Assert.Contains(expectedOutput, sw.ToString());
        }
    }
}
