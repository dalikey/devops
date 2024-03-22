using DevOps.Domain;
using DevOps.States.BacklogState;

namespace DevOps.Tests.BacklogState {
    public class ReadyForTestingStateTests {
        [Fact]
        public void StartTask_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var readyForTestingState = new ReadyForTestingState(backlogItem);

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            readyForTestingState.StartTask();

            // Assert
            Assert.Contains("Cannot start the task again as it's already ready for testing.", sw.ToString());
        }

        [Fact]
        public void StopTask_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var readyForTestingState = new ReadyForTestingState(backlogItem);

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            readyForTestingState.StopTask();

            // Assert
            Assert.Contains("Cannot stop the task as it hasn't started yet.", sw.ToString());
        }

        [Fact]
        public void InvalidateTask_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var readyForTestingState = new ReadyForTestingState(backlogItem);

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            readyForTestingState.InvalidateTask();

            // Assert
            Assert.Contains("Cannot invalidate task because it hasn't started yet.", sw.ToString());
        }

        [Fact]
        public void StartTesting_Should_UpdateState() {
            // Arrange
            var backlogItem = new BacklogItem();
            var readyForTestingState = new ReadyForTestingState(backlogItem);

            // Act
            readyForTestingState.StartTesting();

            // Assert
            Assert.IsType<TestingState>(backlogItem.BacklogState);
        }

        [Fact]
        public void StopTesting_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var readyForTestingState = new ReadyForTestingState(backlogItem);

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            readyForTestingState.StopTesting();

            // Assert
            Assert.Contains("Cannot stop testing because the task hasn't started yet.", sw.ToString());
        }

        [Fact]
        public void ReviewTestReport_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var readyForTestingState = new ReadyForTestingState(backlogItem);

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            readyForTestingState.ReviewTestReport(true);

            // Assert
            Assert.Contains("Cannot review test report because the task hasn't started yet.", sw.ToString());
        }

        [Fact]
        public void SendTestReport_Should_ReturnZero() {
            // Arrange
            var backlogItem = new BacklogItem();
            var readyForTestingState = new ReadyForTestingState(backlogItem);

            // Act
            var result = readyForTestingState.SendTestReport(true);

            // Assert
            Assert.Equal(0, result);
        }
    }
}
