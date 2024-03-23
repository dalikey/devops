using DevOps.Domain.Roles;
using DevOps.Observers;
using DevOps.States.BacklogState;
using System.Xml.Linq;

namespace DevOps.Domain {
    public class BacklogItem {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Sprint Sprint { get; set; }
        public List<DiscussionThread> DiscussionThreads { get; set; }
        public List<Activity> Activities { get; set; }
        public IBacklogState BacklogState { get; set; }
        public NotificationService NotificationService { get; set; }
        public BacklogItem(NotificationService notificationService) {
            Id = 0; Title = "";
            Description = "";
            Sprint = null;
            DiscussionThreads = new List<DiscussionThread>();
            Activities = new List<Activity>();
            BacklogState = new TodoState(this);
            NotificationService = notificationService;
        }

        public void StartTask() => BacklogState.StartTask();
        public void StopTask() => BacklogState.StopTask();
        public void InvalidateTask() => BacklogState.InvalidateTask();
        public void StartTesting() => BacklogState.StartTesting();
        public void StopTesting() => BacklogState.StopTesting();
        public void SendTestReport(bool passed) => BacklogState.SendTestReport(passed);
        public void ReviewTestReport(bool passed) => BacklogState.ReviewTestReport(passed);
        public void UpdateState(IBacklogState newBacklogState) => BacklogState = newBacklogState;


        private void NotifyRole(string message, Person person) {
            NotificationService.NotifyObservers($"[{person.Name}]: {message}");
        }

        public void NotifyScrumMaster() {
            NotifyRole("Item has been rejected. Item has been put back in ToDo", new ScrumMaster());
        }

        public void NotifyTesters() {
            NotifyRole("Item has been rejected. Item has been put back in ToDo", new Tester());
        }

        public void AttachObserver(INotificationObserver observer) {
            NotificationService.Attach(observer);
        }

        public void DetachObserver(INotificationObserver observer) {
            NotificationService.Detach(observer);
        }
    }
}
