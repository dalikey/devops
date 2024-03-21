namespace DevOps.Adapters {
    public class EmailAdapter : IMediaAdapter {
        public void SendNotification(string message) {
            Console.WriteLine($"Sending email notification: {message}");
        }
    }
}
