using DevOps.Domain;
using DevOps.Domain.Roles;
using DevOps.States.BacklogState;
using Moq;

namespace DevOps.Tests.Domain {
    public class DiscussionThreadTests {
        [Fact]
        public void AddComment_Should_Add_Comment_When_BacklogItem_NotDone() {
            // Arrange
            var backlogItem = new BacklogItem();
            var discussionThread = new DiscussionThread("Title", backlogItem, new List<Message>(), new TodoState(backlogItem));
            var comment = new DiscussionComment("Text", "Author");

            // Act
            discussionThread.AddComment(comment);

            // Assert
            Assert.Contains(comment, discussionThread.Comments);
        }

        [Fact]
        public void AddComment_Should_ThrowException_When_BacklogItem_Done() {
            // Arrange
            var backlogItem = new BacklogItem();
            backlogItem.BacklogState = new DoneState(backlogItem);
            var discussionThread = new DiscussionThread("Title", backlogItem, new List<Message>(), new TodoState(backlogItem));
            var comment = new DiscussionComment("Text", "Author");

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => discussionThread.AddComment(comment));
            Assert.Equal("Cannot add a comment to a completed backlog item.", exception.Message);
        }

        [Fact]
        public void NotifyAll_Should_Invoke_NotificationCallBack_For_All_Roles() {
            // Arrange
            var backlogItem = new BacklogItem();
            var discussionThread = new DiscussionThread("Title", backlogItem, new List<Message>(), new TodoState(backlogItem));
            var mockCallBack = new Mock<Func<string, Type, int>>();
            discussionThread.NotificationCallBack = mockCallBack.Object;

            // Act
            var comment = new DiscussionComment("Text", "Author");
            discussionThread.NotifyAll(comment);

            // Assert
            mockCallBack.Verify(x => x.Invoke("A Comment has been sent for a backlog item.", typeof(ScrumMaster)), Times.Once);
            mockCallBack.Verify(x => x.Invoke("A Comment has been sent for a backlog item.", typeof(LeadDeveloper)), Times.Once);
            mockCallBack.Verify(x => x.Invoke("A Comment has been sent for a backlog item.", typeof(Developer)), Times.Once);
            mockCallBack.Verify(x => x.Invoke("A Comment has been sent for a backlog item.", typeof(ProductOwner)), Times.Once);
            mockCallBack.Verify(x => x.Invoke("A Comment has been sent for a backlog item.", typeof(Tester)), Times.Once);
        }

        [Fact]
        public void SprintStateIsFinished_Should_Return_True() {

            //Arrange
            var backLogItem = new BacklogItem();
            var backLogState = new DoneState(backLogItem);
            var discussionThread = new DiscussionThread("Test tile", backLogItem, new List<Message>(), backLogState);

            //Act
            var result = discussionThread.SprintStateIsFinished(); 

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void InitializeThread_Should_Throw_Exception_When_Sprint_Is_Not_Finished() {
            //Arrange
            var backLogItem = new BacklogItem();
            var backLogState = new TodoState(backLogItem);
            var discussionThread = new DiscussionThread("Test tile", backLogItem, new List<Message>(), backLogState);

            //Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => discussionThread.InitializeThread());
            Assert.Equal("Not able to create a thread for the backlog item. Sprint has been finished already", exception.Message);
           

        }


    }
}

       
    

