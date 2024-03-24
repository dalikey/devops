using DevOps.Factories;

namespace DevOps.Tests.Factories
{
    public class ActionFactoryTests
    {
        [Fact]
        public void CreateAction_Should_Return_Correct_Action()
        {
            // Arrange
            var factory = new ActionFactory();

            // Act
            var sourcesAction = factory.CreateAction("Sources");
            var packageAction = factory.CreateAction("Package");
            var buildAction = factory.CreateAction("Build");
            var testAction = factory.CreateAction("Test");
            var analyseAction = factory.CreateAction("Analyze");
            var deployAction = factory.CreateAction("Deploy");
            var utilityAction = factory.CreateAction("Utility");

            // Assert
            Assert.IsType<SourcesAction>(sourcesAction);
            Assert.IsType<PackageAction>(packageAction);
            Assert.IsType<BuildAction>(buildAction);
            Assert.IsType<TestAction>(testAction);
            Assert.IsType<AnalyseAction>(analyseAction);
            Assert.IsType<DeployAction>(deployAction);
            Assert.IsType<UtilityAction>(utilityAction);
        }

        [Fact]
        public void Execute_Should_Write_To_Console()
        {
            // Arrange
            var factory = new ActionFactory();

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            factory.Execute();

            // Assert
            Assert.Contains("Executed", sw.ToString());
        }

        [Fact]
        public void RunAnalysis_Should_Write_To_Console()
        {
            // Arrange
            var analyseAction = new AnalyseAction { AnalyseTool = "StyleCop" };

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            var result = analyseAction.RunAnalysis();

            // Assert
            Assert.True(result);
            Assert.Contains("StyleCop: Executing code analysis", sw.ToString());
        }


        [Fact]
        public void RunBuild_Should_Write_To_Console()
        {
            // Arrange
            var buildAction = new BuildAction { BuildType = "MSBuild" };

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            var result = buildAction.RunBuild();

            // Assert
            Assert.True(result);
            Assert.Contains("MSBuild: Executing", sw.ToString());
        }


        [Fact]
        public void RunDeploymentTarget_Should_Write_To_Console()
        {
            // Arrange
            var deployAction = new DeployAction { DeploymentTarget = "Azure" };

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            var result = deployAction.RunDeploymentTarget();

            // Assert
            Assert.True(result);
            Assert.Contains("Azure: Executing deployment tool", sw.ToString());
        }


        [Fact]
        public void CloningRepository_Should_Write_To_Console()
        {
            // Arrange
            var sourcesAction = new SourcesAction { GitURL = "https://github.com/repository" };

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            var result = sourcesAction.CloningRepository();

            // Assert
            Assert.True(result);
            Assert.Contains("https://github.com/repository: Cloning Repository", sw.ToString());

        }

        [Fact]
        public void RunTests_Should_Write_To_Console()
        {
            // Arrange
            var testAction = new TestAction { TestFramework = "NUnit" };

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            var result = testAction.RunTests();

            // Assert
            Assert.True(result);
            Assert.Contains("NUnit: Running Test Framework", sw.ToString());
        }

        [Fact]
        public void PublishTestResults_Should_Write_To_Console()
        {
            // Arrange
            var testAction = new TestAction { FinishedTests = true, TestFramework = "NUnit" };

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            var result = testAction.PublishTestResults();

            // Assert
            Assert.True(result);
            Assert.Contains("NUnit: Publishing Test Results", sw.ToString());
        }

        [Fact]
        public void RunUtilityActions_Should_Write_To_Console()
        {
            // Arrange
            var utilityAction = new UtilityAction { Actions = new List<string> { "Clean", "Prepare" } };

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            var result = utilityAction.RunUtilityActions();

            // Assert
            Assert.True(result);
            Assert.Contains("Clean: Action is running", sw.ToString());
            Assert.Contains("Prepare: Action is running", sw.ToString());
        }
    }
}
