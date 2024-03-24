using DevOps.States.SprintState;

namespace DevOps.Tests.States.SprintState {
    public class SprintCreationStateTests {
        [Fact]
        public void NextPhase_Should_Write_To_Console() {
            // Arrange
            var sprintState = new SprintCreationState();

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            sprintState.NextPhase();

            // Assert
            Assert.Contains("Moving to planning phase.", sw.ToString());
        }

        [Fact]
        public void StartSprint_Should_Write_To_Console() {
            // Arrange
            var sprintState = new SprintCreationState();

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            sprintState.StartSprint();

            // Assert
            Assert.Contains("Starting sprint.", sw.ToString());
        }

        [Fact]
        public void FinishSprint_Should_Write_Error_To_Console() {
            // Arrange
            var sprintState = new SprintCreationState();

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            sprintState.FinishSprint();

            // Assert
            Assert.Contains("Cannot finish sprint. Sprint not started yet.", sw.ToString());
        }

        [Fact]
        public void Review_Should_Write_Error_To_Console() {
            // Arrange
            var sprintState = new SprintCreationState();

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            sprintState.Review(null);

            // Assert
            Assert.Contains("Cannot review. Sprint not started yet.", sw.ToString());
        }

        [Fact]
        public void Release_Should_Write_Error_To_Console() {
            // Arrange
            var sprintState = new SprintCreationState();

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            sprintState.Release(null);

            // Assert
            Assert.Contains("Cannot release. Sprint not started yet.", sw.ToString());
        }

        [Fact]
        public void CancelRelease_Should_Write_Error_To_Console() {
            // Arrange
            var sprintState = new SprintCreationState();

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            sprintState.CancelRelease(null);

            // Assert
            Assert.Contains("Cannot cancel release. No release to cancel.", sw.ToString());
        }
    }
}
