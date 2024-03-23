using DevOps.Domain;
using DevOps.States.SprintState;
using Moq;

namespace DevOps.Tests.Domain {
    public class SprintTests {

        [Fact]
        public void SetState_Should_Change_State() {

            //Arrange
            var sprint = new Sprint();
            var newState = new Mock<ISprintState>().Object;

            //Act
            sprint.SetState(newState);

            //Assert
            Assert.Equal(newState, sprint._currentState);
        }

        [Fact]
        public void Review_Should_Invoke_Review_Method_Of_Current_State() {

            //Arrange
            var sprint = new Sprint();
            var currentState = new Mock<ISprintState>();

            sprint.SetState(currentState.Object);

            //Act
            sprint.Review();

            //Assert
            currentState.Verify(x => x.Review(sprint), Times.Once);
        }

        [Fact]
        public void Release_Should_Invoke_Release_Method_Of_Current_State() {

            //Arrange
            var sprint = new Sprint();
            var currentState = new Mock<ISprintState>();

            sprint.SetState(currentState.Object);

            //Act
            sprint.Release();

            //Assert
            currentState.Verify(x => x.Release(sprint), Times.Once);
        }

        [Fact]
        public void CancelRelease_Should_Invoke_CancelRelease_Method_Of_Current_State() {

            //Arrange
            var sprint = new Sprint();
            var currentState = new Mock<ISprintState>();

            sprint.SetState(currentState.Object);

            //Act
            sprint.CancelRelease();

            //Assert
            currentState.Verify(x => x.CancelRelease(sprint), Times.Once);
        }
    }
}
