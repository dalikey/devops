using DevOps.Domain.Roles;
using DevOps.States.BacklogState;

namespace DevOps.Domain {
    public class BacklogItem {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Sprint Sprint { get; set; }
        public List<DiscussionThread> DiscussionThreads { get; set; }
        public List<Activity> Activities { get; set; }
        public IBacklogState BacklogState { get; set; }
        public Func<string, Type, int> NotificationCallBack { get; set; }

        public BacklogItem() {
            BacklogState = new TodoState(this);
            Activities = new();
        }

        public int NotifyScrumMaster() {
            if (NotificationCallBack != null) {
                return NotificationCallBack("Item has been rejected. Item has been put back in ToDo", typeof(ScrumMaster));
            } else {
                return 0;
            }
        }

        public int NotifyTesters() {
            if (NotificationCallBack != null) {
                return NotificationCallBack("Item has been rejected. Item has been put back in ToDo", typeof(Tester));
            } else {
                return 0;
            }
        }

        public void StartTask() => BacklogState.StartTask();
        public void StopTask() => BacklogState.StopTask();
        public void InvalidateTask() => BacklogState.InvalidateTask();
        public void StartTesting() => BacklogState.StartTesting();
        public void StopTesting() => BacklogState.StopTesting();
        public void SendTestReport(bool passed) => BacklogState.SendTestReport(passed);
        public void ReviewTestReport(bool passed) => BacklogState.ReviewTestReport(passed);
        public void UpdateState(IBacklogState newBacklogState) => BacklogState = newBacklogState;
    }
}
