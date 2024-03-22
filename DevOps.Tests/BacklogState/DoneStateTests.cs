using DevOps.Domain;
using DevOps.States.BacklogState;

namespace DevOps.Tests.BacklogState {
    public class DoneStateTests {
        [Fact]
        public void StartTask_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var doneState = new DoneState(backlogItem);

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            doneState.StartTask();

            // Assert
            Assert.Contains("Task is already completed.", sw.ToString());
        }

        [Fact]
        public void StopTask_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var doneState = new DoneState(backlogItem);

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            doneState.StopTask();

            // Assert
            Assert.Contains("Task is already completed.", sw.ToString());
        }

        [Fact]
        public void InvalidateTask_Should_WriteToConsole_And_UpdateState() {
            // Arrange
            var backlogItem = new BacklogItem();
            var doneState = new DoneState(backlogItem);

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            doneState.InvalidateTask();

            // Assert
            Assert.Contains("Task is already completed and cannot be invalidated.", sw.ToString());
            Assert.IsType<TodoState>(backlogItem.BacklogState);
        }

        [Fact]
        public void StartTesting_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var doneState = new DoneState(backlogItem);

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            doneState.StartTesting();

            // Assert
            Assert.Contains("Cannot start testing because the task is already completed.", sw.ToString());
        }

        [Fact]
        public void StopTesting_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var doneState = new DoneState(backlogItem);

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            doneState.StopTesting();

            // Assert
            Assert.Contains("Testing cannot be stopped because the task is already completed.", sw.ToString());
        }

        [Fact]
        public void ReviewTestReport_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var doneState = new DoneState(backlogItem);

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            doneState.ReviewTestReport(true);

            // Assert
            Assert.Contains("Cannot review test report because the task is already completed.", sw.ToString());
        }

        [Fact]
        public void SendTestReport_Should_ReturnZero() {
            // Arrange
            var backlogItem = new BacklogItem();
            var doneState = new DoneState(backlogItem);

            // Act
            var result = doneState.SendTestReport(true);

            // Assert
            Assert.Equal(0, result);
        }
    }
}
