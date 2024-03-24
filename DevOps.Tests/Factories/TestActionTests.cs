using DevOps.Factories;
using Moq;

namespace DevOps.Tests.Factories {
    public class TestActionTests {
        [Fact]
        public void AcceptVisitor_Should_Invoke_VisitMethodOfVisitor() {
            // Arrange
            var testAction = new TestAction { TestFramework = "XUnit" };
            var visitor = new MockActionVisitor();

            // Act
            testAction.AcceptVisitor(visitor);

            // Assert
            Assert.True(visitor.VisitedTestAction);
        }

        [Fact]
        public void RunTests_Should_WriteToConsole() {
            // Arrange
            var testFramework = "XUnit";
            var testAction = new TestAction { TestFramework = testFramework };
            var expectedOutput = $"{testFramework}: Running Test Framework";

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            testAction.RunTests();

            // Assert
            Assert.Contains(expectedOutput, sw.ToString());
        }

        [Fact]
        public void PublishTestResults_WhenFinishedTestsTrue_Should_WriteToConsole() {
            // Arrange
            var testFramework = "XUnit";
            var testAction = new TestAction { TestFramework = testFramework, FinishedTests = true };
            var expectedOutput = $"{testFramework}: Publishing Test Results";

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            testAction.PublishTestResults();

            // Assert
            Assert.Contains(expectedOutput, sw.ToString());
        }

        [Fact]
        public void PublishTestResults_WhenFinishedTestsFalse_Should_WriteToConsole() {
            // Arrange
            var testFramework = "XUnit";
            var testAction = new TestAction { TestFramework = testFramework, FinishedTests = false };
            var expectedOutput = $"Results cannot be published";

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            testAction.PublishTestResults();

            // Assert
            Assert.Contains(expectedOutput, sw.ToString());
        }

        [Fact]
        public void Execute_Should_Run_Tests() {
            //Arrange
            var testAction = new TestAction();
            var mockTestAction = new Mock<TestAction> { CallBase = true };
            mockTestAction.Setup(m => m.RunTests()).Returns(true);
            

            //Act
            mockTestAction.Object.Execute();

            //Assert
            mockTestAction.Verify(m => m.RunTests(), Times.Once);
        }

        [Fact]
        public void Execute_Should_Run_Publish_Results() {
            //Arrange
            var testAction = new TestAction();
            var mockTestAction = new Mock<TestAction> { CallBase = true };
            mockTestAction.Setup(m => m.PublishTestResults()).Returns(true);


            //Act
            mockTestAction.Object.Execute();

            //Assert
            mockTestAction.Verify(m => m.PublishTestResults(), Times.Once);
        }
    }
}
