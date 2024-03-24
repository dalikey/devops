using DevOps.Domain;
using DevOps.States.SprintState;

namespace DevOps.Tests {
    public class SprintStateTests {
        [Fact]
        public void SprintCreationState_Review_Should_TransitionToSprintReviewingState() {
            // Arrange
            var sprint = new Sprint();
            var sprintState = new SprintCreationState();

            // Act
            sprintState.Review(sprint);

            // Assert
            Assert.IsType<SprintReviewingState>(sprint._currentState);
        }

        [Fact]
        public void SprintCreationState_Release_Should_NotChangeState() {
            // Arrange
            var sprint = new Sprint();
            var sprintState = new SprintCreationState();

            // Act
            sprintState.Release(sprint);

            // Assert
            Assert.IsType<SprintCreationState>(sprint._currentState);
        }

        [Fact]
        public void SprintCreationState_CancelRelease_Should_NotChangeState() {
            // Arrange
            var sprint = new Sprint();
            var sprintState = new SprintCreationState();

            // Act
            sprintState.CancelRelease(sprint);

            // Assert
            Assert.IsType<SprintCreationState>(sprint._currentState);
        }

        [Fact]
        public void SprintReviewingState_Review_Should_NotChangeState() {
            // Arrange
            var sprint = new Sprint();
            sprint.SetState(new SprintReviewingState());
            var sprintState = new SprintReviewingState();

            // Act
            sprintState.Review(sprint);

            // Assert
            Assert.IsType<SprintReviewingState>(sprint._currentState);
        }

        [Fact]
        public void SprintReviewingState_Release_Should_TransitionToSprintReleasedState() {
            // Arrange
            var sprint = new Sprint();
            sprint.SetState(new SprintReviewingState());
            var sprintState = new SprintReviewingState();

            // Act
            sprintState.Release(sprint);

            // Assert
            Assert.IsType<SprintReleasedState>(sprint._currentState);
        }

        [Fact]
        public void SprintReviewingState_CancelRelease_Should_TransitionToSprintCreationState() {
            // Arrange
            var sprint = new Sprint();
            sprint.SetState(new SprintReviewingState());
            var sprintState = new SprintReviewingState();

            // Act
            sprintState.CancelRelease(sprint);

            // Assert
            Assert.IsType<SprintCreationState>(sprint._currentState);
        }

        [Fact]
        public void SprintReleasedState_Review_Should_NotChangeState() {
            // Arrange
            var sprint = new Sprint();
            sprint.SetState(new SprintReleasedState());
            var sprintState = new SprintReleasedState();

            // Act
            sprintState.Review(sprint);

            // Assert
            Assert.IsType<SprintReleasedState>(sprint._currentState);
        }

        [Fact]
        public void SprintReleasedState_Release_Should_NotChangeState() {
            // Arrange
            var sprint = new Sprint();
            sprint.SetState(new SprintReleasedState());
            var sprintState = new SprintReleasedState();

            // Act
            sprintState.Release(sprint);

            // Assert
            Assert.IsType<SprintReleasedState>(sprint._currentState);
        }

        [Fact]
        public void SprintReleasedState_CancelRelease_Should_NotChangeState() {
            // Arrange
            var sprint = new Sprint();
            sprint.SetState(new SprintReleasedState());
            var sprintState = new SprintReleasedState();

            // Act
            sprintState.CancelRelease(sprint);

            // Assert
            Assert.IsType<SprintReleasedState>(sprint._currentState);
        }
    }
}
