using DevOps.Adapters;

namespace DevOps.Tests {
    public class MediaAdapterTests {
        [Fact]
        public void EmailAdapter_SendNotification_Should_WriteToConsole() {
            // Arrange
            var adapter = new EmailAdapter();
            var message = "Test message";
            var expectedOutput = $"Sending email notification: {message}";

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            adapter.SendNotification(message);

            // Assert
            Assert.Contains(expectedOutput, sw.ToString());
        }

        [Fact]
        public void SlackAdapter_SendNotification_Should_WriteToConsole() {
            // Arrange
            var adapter = new SlackAdapter();
            var message = "Test message";
            var expectedOutput = $"Sending Slack notification: {message}";

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            adapter.SendNotification(message);

            // Assert
            Assert.Contains(expectedOutput, sw.ToString());
        }

        [Fact]
        public void SmsAdapter_SendNotification_Should_WriteToConsole() {
            // Arrange
            var adapter = new SmsAdapter();
            var message = "Test message";
            var expectedOutput = $"Sending SMS notification: {message}";

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            adapter.SendNotification(message);

            // Assert
            Assert.Contains(expectedOutput, sw.ToString());
        }
    }
}
