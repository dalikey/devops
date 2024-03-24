using DevOps.Domain.Roles;
using DevOps.States.BacklogState;

namespace DevOps.Domain {
    public class BacklogItem {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<DiscussionThread> DiscussionThreads { get; set; }
        public List<Activity> Activities { get; set; }

        public Developer Developer { get; set; }
        public IBacklogState BacklogState { get; set; }
        public Func<string, Type, int> NotificationCallBack { get; set; }
        public bool IsDone {
            get {
                foreach (var activity in Activities) {
                    if (!activity.IsFinished) {
                        return false;
                    }
                }
                return true;
            }
        }

        public BacklogItem() {
            BacklogState = new TodoState(this);
            Activities = new List<Activity>();
        }

        public void AddActivity(Activity activity) {
            Activities.Add(activity);
        }

        public void RemoveActivity(Activity activity) {
            Activities.Remove(activity);
        }

        public void SplitBacklogItem(string taskDescription, Developer developer) {
            var activity = new Activity(taskDescription, developer);
            Activities.Add(activity);
        }

        public int NotifyScrumMaster() {
            if (NotificationCallBack != null) {
                return NotificationCallBack("Item has been rejected. Item has been put back in ToDo", typeof(ScrumMaster));
            }
            return 0;
        }

        public int NotifyTesters() {
            if (NotificationCallBack != null) {
                return NotificationCallBack("Item has been rejected. Item has been put back in ToDo", typeof(Tester));
            }
            return 0;
        }

        public void MarkAsDone() {
            if (AreAllTasksFinished()) {
                BacklogState.MarkAsDone();
            }
            throw new InvalidOperationException("Cannot mark as 'done'. Not all tasks are finished.");
        }
        private bool AreAllTasksFinished() {
            foreach (var activity in Activities) {
                if (!activity.IsFinished) {
                    return false;
                }
            }
            return true;
        }

        //Coverage fixen
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
