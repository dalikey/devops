using DevOps.Domain;
using DevOps.States.BacklogState;

namespace DevOps.Tests.BacklogState {
    public class TestedStateTests {
        [Fact]
        public void StartTask_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var testedState = new TestedState(backlogItem);

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            testedState.StartTask();

            // Assert
            Assert.Contains("Cannot start the task again as it's already tested.", sw.ToString());
        }

        [Fact]
        public void StopTask_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var testedState = new TestedState(backlogItem);

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            testedState.StopTask();

            // Assert
            Assert.Contains("Cannot stop the task as it's already tested.", sw.ToString());
        }

        [Fact]
        public void InvalidateTask_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var testedState = new TestedState(backlogItem);

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            testedState.InvalidateTask();

            // Assert
            Assert.Contains("Cannot invalidate task because it's already tested.", sw.ToString());
        }

        [Fact]
        public void StartTesting_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var testedState = new TestedState(backlogItem);

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            testedState.StartTesting();

            // Assert
            Assert.Contains("Cannot start testing again as the task is already tested.", sw.ToString());
        }

        [Fact]
        public void StopTesting_Should_WriteToConsole() {
            // Arrange
            var backlogItem = new BacklogItem();
            var testedState = new TestedState(backlogItem);

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            testedState.StopTesting();

            // Assert
            Assert.Contains("Cannot stop testing as the task is already tested.", sw.ToString());
        }

        [Fact]
        public void ReviewTestReport_Should_UpdateState_ToReadyForTestingState_When_Failed() {
            // Arrange
            var backlogItem = new BacklogItem();
            var testedState = new TestedState(backlogItem);

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            testedState.ReviewTestReport(false); // Failed test

            // Assert
            Assert.IsType<ReadyForTestingState>(backlogItem.BacklogState);
        }

        [Fact]
        public void ReviewTestReport_Should_UpdateState_ToDoneState_When_Passed() {
            // Arrange
            var backlogItem = new BacklogItem();
            var testedState = new TestedState(backlogItem);

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            testedState.ReviewTestReport(true);

            // Assert
            Assert.IsType<DoneState>(backlogItem.BacklogState);
        }

        [Fact]
        public void SendTestReport_Should_ReturnZero() {
            // Arrange
            var backlogItem = new BacklogItem();
            var testedState = new TestedState(backlogItem);

            // Act
            var result = testedState.SendTestReport(true);

            // Assert
            Assert.Equal(0, result);
        }
    }
}
