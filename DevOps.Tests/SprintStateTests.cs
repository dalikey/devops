using DevOps.Domain;
using DevOps.States.SprintState;

namespace DevOps.Tests {
    public class SprintStateTests {
        [Fact]
        public void SprintCreatedState_Review_Should_TransitionToSprintReviewingState() {
            // Arrange
            var sprint = new Sprint();
            var sprintState = new SprintCreatedState();

            // Act
            sprintState.Review(sprint);

            // Assert
            Assert.IsType<SprintReviewingState>(sprint._currentState);
        }

        [Fact]
        public void SprintCreatedState_Release_Should_NotChangeState() {
            // Arrange
            var sprint = new Sprint();
            var sprintState = new SprintCreatedState();

            // Act
            sprintState.Release(sprint);

            // Assert
            Assert.IsType<SprintCreatedState>(sprint._currentState);
        }

        [Fact]
        public void SprintCreatedState_CancelRelease_Should_NotChangeState() {
            // Arrange
            var sprint = new Sprint();
            var sprintState = new SprintCreatedState();

            // Act
            sprintState.CancelRelease(sprint);

            // Assert
            Assert.IsType<SprintCreatedState>(sprint._currentState);
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
        public void SprintReviewingState_CancelRelease_Should_TransitionToSprintCreatedState() {
            // Arrange
            var sprint = new Sprint();
            sprint.SetState(new SprintReviewingState());
            var sprintState = new SprintReviewingState();

            // Act
            sprintState.CancelRelease(sprint);

            // Assert
            Assert.IsType<SprintCreatedState>(sprint._currentState);
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
