using DevOps.Domain;

namespace DevOps.States.BacklogState {
    public class TodoState : IBacklogState {
        private readonly BacklogItem _backlogItem;

        public TodoState(BacklogItem backlogItem) {
            _backlogItem = backlogItem;
        }

        public void StartTask() {
            _backlogItem.UpdateState(new DoingState(_backlogItem));
        }

        public int FinishTask() => 0;

        public void InvalidateTask() {
            Console.WriteLine("Item hasn't started yet..");
        }

        public void ReviewTestReport(bool passed) {
            Console.WriteLine("Item hasn't started yet..");
        }

        public int SendTestReport(bool passed) => 0;

        public void StartTesting() {
            Console.WriteLine("Item hasn't started yet..");
        }

        public void StopTask() {
            Console.WriteLine("Item hasn't started yet..");
        }

        public void StopTesting() {
            Console.WriteLine("Item hasn't started yet..");
        }
    }
}
