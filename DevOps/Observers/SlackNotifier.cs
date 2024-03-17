using DevOps.Observers;
public class SlackNotifier : INotificationObserver {
    public void Update(string message) {
        Console.WriteLine("Slack Notification: " + message);
    }
}