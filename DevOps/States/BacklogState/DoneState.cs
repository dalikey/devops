using DevOps.Domain;

namespace DevOps.States.BacklogState {
    public class DoneState : IBacklogState {
        private readonly BacklogItem _backlogItem;

        public DoneState(BacklogItem backlogItem) {
            _backlogItem = backlogItem;
        }

        public int FinishTask() => 0;

        public void InvalidateTask() {
            Console.WriteLine("Task is already completed and cannot be invalidated.");
            _backlogItem.UpdateState(new TodoState(_backlogItem));
        }

        public void ReviewTestReport(bool passed) {
            Console.WriteLine("Cannot review test report because the task is already completed.");
        }

        public int SendTestReport(bool passed) => 0;

        public void StartTask() {
            Console.WriteLine("Task is already completed.");
        }

        public void StartTesting() {
            Console.WriteLine("Cannot start testing because the task is already completed.");
        }

        public void StopTask() {
            Console.WriteLine("Task is already completed.");
        }

        public void StopTesting() {
            Console.WriteLine("Testing cannot be stopped because the task is already completed.");
        }
    }
}
