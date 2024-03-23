using DevOps.Domain;

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
    }
}
