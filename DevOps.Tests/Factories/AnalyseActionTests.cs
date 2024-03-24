using DevOps.Factories;
using Moq;

namespace DevOps.Tests.Factories {
    public class AnalyseActionTests {
        [Fact]
        public void AcceptVisitor_Should_Invoke_VisitMethodOfVisitor() {
            // Arrange
            var analyseAction = new AnalyseAction { AnalyseTool = "CodeAnalyzer" };
            var visitor = new MockActionVisitor();

            // Act
            analyseAction.AcceptVisitor(visitor);

            // Assert
            Assert.True(visitor.VisitedAnalyseAction);
        }

        [Fact]
        public void RunAnalysis_Should_WriteToConsole() {
            // Arrange
            var analyseAction = new AnalyseAction { AnalyseTool = "CodeAnalyzer" };
            var expectedOutput = $"{analyseAction.AnalyseTool}: Executing code analysis";

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            analyseAction.RunAnalysis();

            // Assert
            Assert.Contains(expectedOutput, sw.ToString());
        }

        [Fact]
        public void Execute_Should_Run_Analysis() {

            //Arrange
            var analyseAction = new AnalyseAction();
            var mockAnalyseAction = new Mock<AnalyseAction> { CallBase = true };
            mockAnalyseAction.Setup(m => m.RunAnalysis()).Returns(true);

            //Act
            mockAnalyseAction.Object.Execute();

            //Assert
            mockAnalyseAction.Verify(m => m.RunAnalysis(), Times.Once);
        }
    }
}
