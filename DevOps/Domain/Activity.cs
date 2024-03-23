namespace DevOps.Domain {
    public class Activity {
        public string Task { get; set; }
        public bool IsFinished { get; set; } = false;

        public Activity(string task) {
            Task = task;
        }

        public void FinishTask() {
            IsFinished = true;
        }
    }
}
