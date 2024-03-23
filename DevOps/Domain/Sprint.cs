using DevOps.Observers;
using DevOps.States.SprintState;

namespace DevOps.Domain {
    public class Sprint {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<BacklogItem> BacklogItems { get; set; }
        public ISprintState _currentState { get; set; }
        private IPublisher NotificationService { get; set; }

        public Sprint() {
            BacklogItems = new List<BacklogItem>();
            _currentState = new SprintCreatedState();
        }

        public void AttachObserver(INotificationObserver observer) {
            NotificationService.Attach(observer);
        }

        public void DetachObserver(INotificationObserver observer) {
            NotificationService.Detach(observer);
        }

        public void SetState(ISprintState state) {
            _currentState = state;
        }

        public void Review() {
            _currentState.Review(this);
        }

        public void Release() {
            _currentState.Release(this);
        }

        public void CancelRelease() {
            _currentState.CancelRelease(this);
        }
    }
}
