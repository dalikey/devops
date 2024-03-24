using DevOps.States.SprintState;

namespace DevOps.Tests.States.SprintState {
    public class SprintExecutionStateTests {
        [Fact]
        public void NextPhase_Should_Write_To_Console() {
            // Arrange
            var sprintState = new SprintExecutionState();

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            sprintState.NextPhase();

            // Assert
            Assert.Contains("Moving to next phase.", sw.ToString());
        }

        [Fact]
        public void StartSprint_Should_Write_Error_To_Console() {
            // Arrange
            var sprintState = new SprintExecutionState();

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            sprintState.StartSprint();

            // Assert
            Assert.Contains("Cannot start sprint. Sprint already started.", sw.ToString());
        }

        [Fact]
        public void FinishSprint_Should_Write_To_Console() {
            // Arrange
            var sprintState = new SprintExecutionState();

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            sprintState.FinishSprint();

            // Assert
            Assert.Contains("Finishing sprint.", sw.ToString());
        }

        [Fact]
        public void Review_Should_Write_Error_To_Console() {
            // Arrange
            var sprintState = new SprintExecutionState();

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            sprintState.Review(null);

            // Assert
            Assert.Contains("Cannot review. Sprint execution still in progress.", sw.ToString());
        }

        [Fact]
        public void Release_Should_Write_Error_To_Console() {
            // Arrange
            var sprintState = new SprintExecutionState();

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            sprintState.Release(null);

            // Assert
            Assert.Contains("Cannot release. Sprint execution still in progress.", sw.ToString());
        }

        [Fact]
        public void CancelRelease_Should_Write_Error_To_Console() {
            // Arrange
            var sprintState = new SprintExecutionState();

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            sprintState.CancelRelease(null);

            // Assert
            Assert.Contains("Cannot cancel release. Sprint execution still in progress.", sw.ToString());
        }
    }
}
