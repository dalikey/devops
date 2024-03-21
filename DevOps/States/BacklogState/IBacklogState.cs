namespace DevOps.States.BacklogState {
    public interface IBacklogState {

        public void StartTask();
        public void StopTask();
        public int FinishTask();
        public void InvalidateTask();
        public void StartTesting();
        public void StopTesting();
        public void ReviewTestReport(bool passed);
        public int SendTestReport(bool passed);
    }
}
