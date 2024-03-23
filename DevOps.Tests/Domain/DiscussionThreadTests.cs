using DevOps.Domain;
using DevOps.Domain.Roles;
using DevOps.States.BacklogState;
using Moq;

namespace DevOps.Tests.Domain {
    public class DiscussionThreadTests {

        [Fact]
        public void Comment_Should_Be_Added_To_List() {
            // Arrange
            var backlogStateMock = new Mock<IBacklogState>();
            backlogStateMock.SetupGet(state => state.GetType()).Returns(typeof(TodoState));

            var backlogItem = new BacklogItem { BacklogState = backlogStateMock.Object };
            var discussionThread = new DiscussionThread("Test Title", backlogItem, new List<Message>());
            var comment = new DiscussionComment("Test Comment", "Test Author");

            // Act
            discussionThread.AddComment(comment);

            // Assert
            Assert.Contains(comment, discussionThread.Comments);
        }

        [Fact]
        public void AddComment_Should_Throw_Exception_When_BackLogItem_Is_Completed() {
            // Arrange
            var backlogStateMock = new Mock<IBacklogState>();
            backlogStateMock.SetupGet(state => state.GetType()).Returns(typeof(DoneState));

            var backlogItem = new BacklogItem { BacklogState = backlogStateMock.Object };
            var discussionThread = new DiscussionThread("Test Title", backlogItem, new List<Message>());
            var comment = new DiscussionComment("Test Comment", "Test Author");

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => discussionThread.AddComment(comment));
            Assert.Equal("Cannot add a comment to a completed backlog item.", exception.Message);
        }

        [Fact]
        public void InitializeThread_Should_Add_BackLogItem_To_DiscussionThread() {
            // Arrange
            var backlogStateMock = new Mock<IBacklogState>();
            backlogStateMock.SetupGet(state => state.GetType()).Returns(typeof(TodoState));
            var backlogItem = new BacklogItem { BacklogState = backlogStateMock.Object };

            var discussionThread = new DiscussionThread("Test Title", backlogItem, new List<Message>());

            // Act
            discussionThread.InitializeThread();

            // Assert
            Assert.Contains(discussionThread, backlogItem.DiscussionThreads);
        }

        [Fact]
        public void InitializeThread_Should_Throw_Exception_If_Sprint_Is_Finished() {
            // Arrange
            var backlogStateMock = new Mock<IBacklogState>();
            backlogStateMock.SetupGet(state => state.GetType()).Returns(typeof(DoneState));
            var backlogItem = new BacklogItem { BacklogState = backlogStateMock.Object };
            var discussionThread = new DiscussionThread("Test Title", backlogItem, new List<Message>());

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => discussionThread.InitializeThread());
            Assert.Equal("Not able to create a thread for the backlog item. Sprint has been finished already", exception.Message);
        }

        [Fact]
        public void NotifyAll_Should_Invoke_Notifications_For_All_Roles() {

            // Arrange
            var backlogStateMock = new Mock<IBacklogState>();
            var backlogItem = new BacklogItem { BacklogState = backlogStateMock.Object };
            var mockCallBack = new Mock<Func<string, Type, int>>();
            var discussionThread = new DiscussionThread("Test Title", backlogItem, new List<Message>());
            discussionThread.NotificationCallBack = mockCallBack.Object;
            var comment = new DiscussionComment("Test Comment", "Test Author");

            // Act
            var result = discussionThread.NotifyAll(comment);

            // Assert
            mockCallBack.Verify(x => x.Invoke("A Comment has been sent for a backlog item.", typeof(ScrumMaster)), Times.Once);
            mockCallBack.Verify(x => x.Invoke("A Comment has been sent for a backlog item.", typeof(ProductOwner)), Times.Once);
            mockCallBack.Verify(x => x.Invoke("A Comment has been sent for a backlog item.", typeof(Developer)), Times.Once);
            mockCallBack.Verify(x => x.Invoke("A Comment has been sent for a backlog item.", typeof(LeadDeveloper)), Times.Once);
            mockCallBack.Verify(x => x.Invoke("A Comment has been sent for a backlog item.", typeof(Tester)), Times.Once);
            Assert.Equal(1, result);
        }
    }
}
