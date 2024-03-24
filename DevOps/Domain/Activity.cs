using DevOps.Domain.Roles;

namespace DevOps.Domain {
    public class Activity {
        public string Task { get; set; }
        public Developer AssignedDeveloper { get; set; }
        public bool IsFinished { get; set; } = false;

        public Activity(string task) {
            Task = task;
        }

        public Activity(string task, Developer assignedDeveloper) {
            Task = task;
            AssignedDeveloper = assignedDeveloper;
            IsFinished = false;
        }

        public void FinishTask() {
            IsFinished = true;
        }
    }
}
