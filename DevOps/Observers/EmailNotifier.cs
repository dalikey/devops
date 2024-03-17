using DevOps.Observers;
public class EmailNotifier : INotificationObserver {
    public void Update(string message) {
        Console.WriteLine("Email Notification: " + message);
    }
}