using DevOps.Domain;
using DevOps.States.BacklogState;

namespace DevOps.Tests.BacklogState {
    public class TodoStateTests {
        [Fact]
        public void StartTask_Should_WriteToConsole_And_UpdateState() {
            // Arrange
            var backlogItem = new BacklogItem();
            var todoState = new TodoState(backlogItem);

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            todoState.StartTask();

            // Assert
            Assert.Contains("Starting task...", sw.ToString());
            Assert.IsType<DoingState>(backlogItem.BacklogState);
        }

        [Fact]
        public void StopTask_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var todoState = new TodoState(backlogItem);

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            todoState.StopTask();

            // Assert
            Assert.Contains("Cannot stop the task as it hasn't been started yet.", sw.ToString());
        }

        [Fact]
        public void InvalidateTask_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var todoState = new TodoState(backlogItem);

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            todoState.InvalidateTask();

            // Assert
            Assert.Contains("Task cannot be invalidated as it's still in the to-do state.", sw.ToString());
        }

        [Fact]
        public void StartTesting_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var todoState = new TodoState(backlogItem);

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            todoState.StartTesting();

            // Assert
            Assert.Contains("Cannot start testing as the task hasn't been started yet.", sw.ToString());
        }

        [Fact]
        public void StopTesting_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var todoState = new TodoState(backlogItem);

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            todoState.StopTesting();

            // Assert
            Assert.Contains("Cannot stop testing as the task hasn't been started yet.", sw.ToString());
        }

        [Fact]
        public void ReviewTestReport_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var todoState = new TodoState(backlogItem);

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            todoState.ReviewTestReport(true);

            // Assert
            Assert.Contains("Cannot review test report as the task hasn't been started yet.", sw.ToString());
        }

        [Fact]
        public void SendTestReport_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var todoState = new TodoState(backlogItem);

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            var result = todoState.SendTestReport(true);

            // Assert
            Assert.Contains("Cannot send test report as the task hasn't been started yet.", sw.ToString());
            Assert.Equal(0, result);
        }
    }
}
