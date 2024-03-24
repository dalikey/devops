using DevOps.Domain;
using DevOps.Domain.Roles;

namespace DevOps.Tests.Domain {
    public class ActivityTests {

        [Fact]
        public void ActivityTask_Is_Finished() {
            //Arrange
            Activity activity = new Activity("Sample Task");

            //Act
            activity.FinishTask();

            //Assert
            Assert.True(activity.IsFinished);
        }

        [Fact]
        public void Constructor_With_AssignedDeveloper_Should_Set_AssignedDeveloper() {
            // Arrange
            var developer = new Developer();
            var task = "Sample Task";

            // Act
            var activity = new Activity(task, developer);

            // Assert
            Assert.Equal(task, activity.Task);
            Assert.Equal(developer, activity.AssignedDeveloper);
        }
    }
}
