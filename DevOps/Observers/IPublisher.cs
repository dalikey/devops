namespace DevOps.Observers {
    public interface IPublisher {
        void Attach(INotificationObserver observer);
        void Detach(INotificationObserver observer);
        void NotifyObservers(string message);
    }
}