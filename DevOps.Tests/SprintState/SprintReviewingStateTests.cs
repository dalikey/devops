using DevOps.Domain;
using DevOps.States.SprintState;
using Moq;

namespace DevOps.Tests.States.SprintState {
    public class SprintReviewingStateTests {
        [Fact]
        public void NextPhase_Should_Write_Error_To_Console() {
            // Arrange
            var sprintState = new SprintReviewingState();

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            sprintState.NextPhase();

            // Assert
            Assert.Contains("Cannot proceed to next phase. Sprint is still under review.", sw.ToString());
        }

        [Fact]
        public void StartSprint_Should_Write_Error_To_Console() {
            // Arrange
            var sprintState = new SprintReviewingState();

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            sprintState.StartSprint();

            // Assert
            Assert.Contains("Cannot start sprint. Sprint is still under review.", sw.ToString());
        }

        [Fact]
        public void FinishSprint_Should_Write_Error_To_Console() {
            // Arrange
            var sprintState = new SprintReviewingState();

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            sprintState.FinishSprint();

            // Assert
            Assert.Contains("Cannot finish sprint. Sprint is still under review.", sw.ToString());
        }

        [Fact]
        public void Review_Should_Write_To_Console() {
            // Arrange
            var sprintState = new SprintReviewingState();

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            sprintState.Review(null);

            // Assert
            Assert.Contains("Sprint already under review.", sw.ToString());
        }

        [Fact]
        public void Release_Should_Set_State_To_SprintReleasedState() {
            // Arrange
            var sprintState = new SprintReviewingState();
            var sprint = new Sprint();
            var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            sprintState.Release(sprint);
            sw.Dispose();

            // Assert
            Assert.IsType<SprintReleasedState>(sprint._currentState);
        }

        [Fact]
        public void CancelRelease_Should_Set_State_To_SprintCreationState() {
            // Arrange
            var sprintState = new SprintReviewingState();
            var sprint = new Sprint();

            // Act
            sprintState.CancelRelease(sprint);

            // Assert
            Assert.IsType<SprintCreationState>(sprint._currentState);
        }
    }
}
