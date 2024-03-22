namespace DevOps.Adapters {
    public class SmsAdapter : IMediaAdapter {
        public void SendNotification(string message) {
            Console.WriteLine($"Sending SMS notification: {message}");
        }
    }
}
