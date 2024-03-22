namespace DevOps.Tests {
    public class NotificationObserverTests {
        [Fact]
        public void SlackNotifier_Update_Should_WriteToConsole() {
            // Arrange
            var notifier = new SlackNotifier();
            var message = "Test message";
            var expectedOutput = "Slack Notification: " + message;

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            notifier.Update(message);

            // Assert
            Assert.Contains(expectedOutput, sw.ToString());
        }

        [Fact]
        public void EmailNotifier_Update_Should_WriteToConsole() {
            // Arrange
            var notifier = new EmailNotifier();
            var message = "Test message";
            var expectedOutput = "Email Notification: " + message;

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            notifier.Update(message);

            // Assert
            Assert.Contains(expectedOutput, sw.ToString());
        }
    }
}