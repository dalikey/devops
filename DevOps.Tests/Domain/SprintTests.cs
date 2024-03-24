using DevOps.Domain;
using DevOps.Domain.Roles;
using DevOps.States.SprintState;
using Moq;

namespace DevOps.Tests.Domain {
    public class SprintTests {
        [Fact]
        public void SetState_Should_Set_CurrentState() {
            // Arrange
            var sprint = new Sprint();
            var newState = new SprintReviewingState();

            // Act
            sprint.SetState(newState);

            // Assert
            Assert.Equal(newState, sprint._currentState);
        }

        [Fact]
        public void Review_Should_Call_Review_Method_In_CurrentState() {
            // Arrange
            var sprint = new Sprint();
            var mockState = new Mock<ISprintState>();
            sprint.SetState(mockState.Object);

            // Act
            sprint.Review();

            // Assert
            mockState.Verify(state => state.Review(sprint), Times.Once);
        }

        [Fact]
        public void Release_Should_Call_Release_Method_In_CurrentState() {
            // Arrange
            var sprint = new Sprint();
            var mockState = new Mock<ISprintState>();
            sprint.SetState(mockState.Object);

            // Act
            sprint.Release();

            // Assert
            mockState.Verify(state => state.Release(sprint), Times.Once);
        }

        [Fact]
        public void CancelRelease_Should_Call_CancelRelease_Method_In_CurrentState() {
            // Arrange
            var sprint = new Sprint();
            var mockState = new Mock<ISprintState>();
            sprint.SetState(mockState.Object);

            // Act
            sprint.CancelRelease();

            // Assert
            mockState.Verify(state => state.CancelRelease(sprint), Times.Once);
        }

        [Fact]
        public void AddBacklogItem_Should_Add_Item_To_BacklogItems_List() {
            // Arrange
            var sprint = new Sprint();
            var backlogItem = new BacklogItem();

            // Act
            sprint.AddBacklogItem(backlogItem);

            // Assert
            Assert.Contains(backlogItem, sprint.BacklogItems);
        }

        [Fact]
        public void AssignDeveloperToBacklogItem_Should_Assign_Developer_To_BacklogItem() {
            // Arrange
            var sprint = new Sprint();
            var backlogItem = new BacklogItem { Id = 1 };
            sprint.AddBacklogItem(backlogItem);
            var developer = new Developer();

            // Act
            sprint.AssignDeveloperToBacklogItem(1, developer);

            // Assert
            Assert.Equal(developer, backlogItem.Developer);
        }

        [Fact]
        public void AssignDeveloperToBacklogItem_Should_Throw_Exception_If_BacklogItem_Not_Found() {
            // Arrange
            var sprint = new Sprint();
            var developer = new Developer();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => sprint.AssignDeveloperToBacklogItem(1, developer));
        }
    }
}
