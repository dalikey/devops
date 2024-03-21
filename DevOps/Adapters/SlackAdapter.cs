namespace DevOps.Adapters {
    public class SlackAdapter : IMediaAdapter {
        public void SendNotification(string message) {
            Console.WriteLine($"Sending Slack notification: {message}");
        }
    }
}
