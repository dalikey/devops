namespace DevOps.Observers {
    public class NotificationService : IPublisher {
        private List<INotificationObserver> observers = new List<INotificationObserver>();

        public void Attach(INotificationObserver observer) {
            observers.Add(observer);
        }

        public void Detach(INotificationObserver observer) {
            observers.Remove(observer);
        }

        public void NotifyObservers(string message) {
            foreach (var observer in observers) {
                observer.Update(message);
            }
        }
    }
}
