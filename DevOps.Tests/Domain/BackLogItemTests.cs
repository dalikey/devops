using DevOps.Domain;
using DevOps.Domain.Roles;
using DevOps.States.BacklogState;
using Moq;

namespace DevOps.Tests.Domain {
    public class BackLogItemTests {
        [Fact]
        public void AddActivity_Should_Add_Activity_To_Activities_List() {
            //Arrange
            var backlogItem = new BacklogItem();
            var activity = new Activity("Test Activity");

            //Act
            backlogItem.AddActivity(activity);

            //Assert
            Assert.Contains(activity, backlogItem.Activities);
        }

        [Fact]
        public void RemoveActivity_Should_Remove_Activity_From_Activities_List() {
            //Arrange
            var backlogItem = new BacklogItem();
            var activity = new Activity("Test Activity");
            backlogItem.AddActivity(activity);

            //Act
            backlogItem.RemoveActivity(activity);

            //Assert
            Assert.DoesNotContain(activity, backlogItem.Activities);
        }

        [Fact]
        public void NotifyScrumMaster_Should_Invoke_NotificationCallBack_ForScrumMaster() {
            //Arrange
            var backLogItem = new BacklogItem();
            var mockCallBack = new Mock<Func<string, Type, int>>();
            backLogItem.NotificationCallBack = mockCallBack.Object;

            //Act
            backLogItem.NotifyScrumMaster();

            //Assert
            mockCallBack.Verify(x => x.Invoke("Item has been rejected. Item has been put back in ToDo", typeof(ScrumMaster)), Times.Once);
        }

        [Fact]
        public void NotifyTesters_Should_Invoke_NotificationCallBack_ForTesters() {
            //Arrange
            var backLogItem = new BacklogItem();
            var mockCallBack = new Mock<Func<string, Type, int>>();
            backLogItem.NotificationCallBack = mockCallBack.Object;

            //Act
            backLogItem.NotifyTesters();

            //Assert
            mockCallBack.Verify(x => x.Invoke("Item has been rejected. Item has been put back in ToDo", typeof(Tester)), Times.Once);
        }

        [Fact]
        public void MarkAsDone_Should_Set_BacklogState_AsDone_When_AllTasksFinished() {
            // Arrange
            var backlogItem = new BacklogItem();
            backlogItem.AddActivity(new Activity("Task 1"));
            backlogItem.AddActivity(new Activity("Task 2"));
            backlogItem.AddActivity(new Activity("Task 3"));
            backlogItem.AddActivity(new Activity("Task 4"));

            // Act
            backlogItem.Activities.ForEach(activity => activity.FinishTask());
            backlogItem.MarkAsDone();

            // Assert
            Assert.IsType<DoneState>(backlogItem.BacklogState);
        }

        [Fact]
        public void MarkAsDone_Should_ThrowException_When_NotAllTasksFinished() {
            // Arrange
            var backlogItem = new BacklogItem();
            backlogItem.AddActivity(new Activity("Task 1"));
            backlogItem.AddActivity(new Activity("Task 2"));
            backlogItem.AddActivity(new Activity("Task 3"));
            backlogItem.AddActivity(new Activity("Task 4"));

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => backlogItem.MarkAsDone());
        }
    }
}
