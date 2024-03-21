using DevOps.Domain;

namespace DevOps.States.BacklogState {
    public class DoneState : IBacklogState {
        private readonly BacklogItem _backlogItem;

        public DoneState(BacklogItem backlogItem) {
            _backlogItem = backlogItem;
        }

        public int FinishTask() => 0;

        public void InvalidateTask() {
            _backlogItem.UpdateState(new TodoState(_backlogItem));
        }

        public void ReviewTestReport(bool passed) {
            Console.WriteLine("Item hasn't started yet..");
        }

        public int SendTestReport(bool passed) => 0;

        public void StartTask() {
            Console.WriteLine("Item hasn't started yet..");
        }

        public void StartTesting() {
            Console.WriteLine("Item hasn't started yet..");
        }

        public void StopTask() {
            _backlogItem.UpdateState(new DoneState(_backlogItem));
        }

        public void StopTesting() {
            Console.WriteLine("Item hasn't started yet..");
        }
    }
}
