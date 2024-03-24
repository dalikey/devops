using DevOps.Domain;
using DevOps.States.BacklogState;

namespace DevOps.Tests.BacklogState {
    public class TestingStateTests {
        [Fact]
        public void StartTask_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var testingState = new TestingState(backlogItem);

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            testingState.StartTask();

            // Assert
            Assert.Contains("Cannot start the task again as it's already being tested.", sw.ToString());
        }

        [Fact]
        public void StopTask_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var testingState = new TestingState(backlogItem);

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            testingState.StopTask();

            // Assert
            Assert.Contains("Cannot stop the task as it's already being tested.", sw.ToString());
        }

        [Fact]
        public void InvalidateTask_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var testingState = new TestingState(backlogItem);

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            testingState.InvalidateTask();

            // Assert
            Assert.Contains("Cannot invalidate task while it's being tested.", sw.ToString());
        }

        [Fact]
        public void StartTesting_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var testingState = new TestingState(backlogItem);

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            testingState.StartTesting();

            // Assert
            Assert.Contains("Cannot start testing again as the task is already being tested.", sw.ToString());
        }

        [Fact]
        public void StopTesting_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var testingState = new TestingState(backlogItem);

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            testingState.StopTesting();

            // Assert
            Assert.Contains("Cannot stop testing as the task is already being tested.", sw.ToString());
        }

        [Fact]
        public void ReviewTestReport_Should_UpdateState_ToTodoState_When_Failed() {
            // Arrange
            var backlogItem = new BacklogItem();
            var testingState = new TestingState(backlogItem);

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            testingState.ReviewTestReport(false);

            // Assert
            Assert.IsType<TodoState>(backlogItem.BacklogState);
        }

        [Fact]
        public void ReviewTestReport_Should_UpdateState_ToTestedState_When_Passed() {
            // Arrange
            var backlogItem = new BacklogItem();
            var testingState = new TestingState(backlogItem);

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            testingState.ReviewTestReport(true);

            // Assert
            Assert.IsType<TestedState>(backlogItem.BacklogState);
        }

        [Fact]
        public void SendTestReport_Should_ReturnZero_When_Passed() {
            // Arrange
            var backlogItem = new BacklogItem();
            var testingState = new TestingState(backlogItem);

            // Act
            var result = testingState.SendTestReport(true);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void SendTestReport_Should_ReturnNotifyScrumMaster_When_Failed() {
            // Arrange
            var backlogItem = new BacklogItem();
            var testingState = new TestingState(backlogItem);

            // Act
            var result = testingState.SendTestReport(false);

            // Assert
            Assert.Equal(0, result);
        }
    }
}
