using DevOps.Adapters;
using DevOps.Domain;
using Moq;
using Xunit;

namespace DevOps.Tests.Domain {
    public class TestPerson : Person {
        public IMediaAdapter GetMediaAdapter() {
            return mediaAdapter;
        }

        public override void SendNotification(string message) {
            // No need to implement for testing purposes
        }
    }

    public class PersonTests {
        [Fact]
        public void SetMediaAdapter_Should_SetMediaAdapter() {
            // Arrange
            var person = new TestPerson();
            var mockAdapter = new Mock<IMediaAdapter>().Object;

            // Act
            person.SetMediaAdapter(mockAdapter);

            // Assert
            Assert.Same(mockAdapter, person.GetMediaAdapter());
        }

        [Fact]
        public void SendNotification_Should_InvokeSendNotificationOnMediaAdapter() {
            // Arrange
            var person = new TestPerson();
            var mockAdapter = new Mock<IMediaAdapter>();
            person.SetMediaAdapter(mockAdapter.Object);
            string message = "Test message";

            // Act
            person.SendNotification(message);

            // Assert
            mockAdapter.Verify(a => a.SendNotification(message), Times.Once);
        }
    }
}
