using Xunit;
using DevOps.Domain;
using DevOps.States.BacklogState;
using System.IO;

namespace DevOps.Tests.BacklogState {
    public class BacklogItemTests {
        [Fact]
        public void StartTask_WhenInDoingState_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var doingState = new DoingState(backlogItem);
            backlogItem.UpdateState(doingState);

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            backlogItem.StartTask();

            // Assert
            Assert.Contains("Task is already in progress.", sw.ToString());
        }

        [Fact]
        public void StopTask_WhenInDoingState_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var doingState = new DoingState(backlogItem);
            backlogItem.UpdateState(doingState);

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            backlogItem.StopTask();

            // Assert
            Assert.Contains("Task has been stopped.", sw.ToString());
        }

        [Fact]
        public void InvalidateTask_WhenInDoingState_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var doingState = new DoingState(backlogItem);
            backlogItem.UpdateState(doingState);

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            backlogItem.InvalidateTask();

            // Assert
            Assert.Contains("Task cannot be invalidated while it's in progress.", sw.ToString());
        }

        [Fact]
        public void StartTesting_WhenInDoingState_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var doingState = new DoingState(backlogItem);
            backlogItem.UpdateState(doingState);

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            backlogItem.StartTesting();

            // Assert
            Assert.Contains("Testing cannot be started until the task is completed.", sw.ToString());
        }

        [Fact]
        public void StopTesting_WhenInDoingState_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var doingState = new DoingState(backlogItem);
            backlogItem.UpdateState(doingState);

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            backlogItem.StopTesting();

            // Assert
            Assert.Contains("Testing cannot be stopped until the task is completed.", sw.ToString());
        }

        [Fact]
        public void ReviewTestReport_WhenInDoingState_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var doingState = new DoingState(backlogItem);
            backlogItem.UpdateState(doingState);

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            backlogItem.ReviewTestReport(true);

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
