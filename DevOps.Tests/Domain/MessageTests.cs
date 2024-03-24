using DevOps.Domain;
using DevOps.Domain.Roles;

namespace DevOps.Tests.Domain {
    public class MessageTests {
        [Fact]
        public void Message_CanBeCreated() {
            // Arrange
            string content = "Test message";
            Person author = new Developer();

            // Act
            var message = new Message {
                Content = content,
                Author = author,
                Timestamp = DateTime.UtcNow
            };

            // Assert
            Assert.NotNull(message);
            Assert.Equal(content, message.Content);
            Assert.Equal(author, message.Author);
        }
    }
}
