using DevOps.Domain;
using DevOps.Domain.Roles;
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
        public void NotifyScrumMaster_Should_Invoke_NotificationCallBack() {
            //Arrange
            var backLogItem = new BacklogItem();
            var mockCallBack = new Mock<Func<string, Type, int>>();
            backLogItem.NotificationCallBack = mockCallBack.Object;

            //Act
            backLogItem.NotifyScrumMaster();

            //Assert
            mockCallBack.Verify(x => x.Invoke("Item has been rejected. Item has been put back in ToDo", typeof(ScrumMaster)));
        }

        [Fact]
        public void NotifyTesters_Should_Invoke_NotificationCallBack() {
            //Arrange
            var backLogItem = new BacklogItem();
            var mockCallBack = new Mock<Func<string, Type, int>>();
            backLogItem.NotificationCallBack = mockCallBack.Object;

            //Act
            backLogItem.NotifyScrumMaster();

            //Assert
            mockCallBack.Verify(x => x.Invoke("Item has been rejected. Item has been put back in ToDo", typeof(Tester)));
        }

    }
}
