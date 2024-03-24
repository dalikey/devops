using DevOps.Domain;
using DevOps.States.BacklogState;

namespace DevOps.Tests.BacklogState {
    public class DoingStateTests {
        [Fact]
        public void StartTask_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var doingState = new DoingState(backlogItem);

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            doingState.StartTask();

            // Assert
            Assert.Contains("Task is already in progress.", sw.ToString());
        }

        [Fact]
        public void StopTask_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var doingState = new DoingState(backlogItem);

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            doingState.StopTask();

            // Assert
            Assert.Contains("Task has been stopped.", sw.ToString());
        }

        [Fact]
        public void InvalidateTask_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var doingState = new DoingState(backlogItem);

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            doingState.InvalidateTask();

            // Assert
            Assert.Contains("Task cannot be invalidated while it's in progress.", sw.ToString());
        }

        [Fact]
        public void StartTesting_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var doingState = new DoingState(backlogItem);

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            doingState.StartTesting();

            // Assert
            Assert.Contains("Testing cannot be started until the task is completed.", sw.ToString());
        }

        [Fact]
        public void StopTesting_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var doingState = new DoingState(backlogItem);

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            doingState.StopTesting();

            // Assert
            Assert.Contains("Testing cannot be stopped until the task is completed.", sw.ToString());
        }

        [Fact]
        public void ReviewTestReport_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var doingState = new DoingState(backlogItem);

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            doingState.ReviewTestReport(true);

            // Assert
            Assert.Contains("Cannot review test report until the task is completed.", sw.ToString());
        }

        [Fact]
        public void SendTestReport_Should_ReturnZero() {
            // Arrange
            var backlogItem = new BacklogItem();
            var doingState = new DoingState(backlogItem);

            // Act
            var result = doingState.SendTestReport(true);

            // Assert
            Assert.Equal(0, result);
        }
    }
}
