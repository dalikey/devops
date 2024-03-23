using DevOps.Domain;

namespace DevOps.States.BacklogState {
    public class TodoState : IBacklogState {
        private readonly BacklogItem _backlogItem;

        public TodoState(BacklogItem backlogItem) {
            _backlogItem = backlogItem;
        }

        public void StartTask() {
            Console.WriteLine("Starting task...");
            _backlogItem.UpdateState(new DoingState(_backlogItem));
        }

        public int FinishTask() => 0;

        public void InvalidateTask() {
            Console.WriteLine("Task cannot be invalidated as it's still in the to-do state.");
        }
        public void MarkAsDone() {
            _backlogItem.UpdateState(new DoneState(_backlogItem));
            Console.WriteLine("Backlog item marked as done.");
        }

        public void ReviewTestReport(bool passed) {
            Console.WriteLine("Cannot review test report as the task hasn't been started yet.");
        }

        public int SendTestReport(bool passed) {
            Console.WriteLine("Cannot send test report as the task hasn't been started yet.");
            return 0;
        }

        public void StartTesting() {
            Console.WriteLine("Cannot start testing as the task hasn't been started yet.");
        }

        public void StopTask() {
            Console.WriteLine("Cannot stop the task as it hasn't been started yet.");
        }

        public void StopTesting() {
            Console.WriteLine("Cannot stop testing as the task hasn't been started yet.");
        }
    }
}
