using DevOps.Domain;

namespace DevOps.States.BacklogState {
    public class ReadyForTestingState : IBacklogState {
        private readonly BacklogItem _backlogItem;

        public ReadyForTestingState(BacklogItem backlogItem) {
            _backlogItem = backlogItem;
        }

        public int FinishTask() => 0;

        public void InvalidateTask() {
            Console.WriteLine("Item hasn't started yet..");
        }

        public void ReviewTestReport(bool passed) {
            Console.WriteLine("Item hasn't started yet..");
        }

        public int SendTestReport(bool passed) => 0;

        public void StartTask() {
            Console.WriteLine("Item hasn't started yet..");
        }

        public void StartTesting() {
            _backlogItem.UpdateState(new TestingState(_backlogItem));
        }

        public void StopTask() {
            Console.WriteLine("Item hasn't started yet..");
        }

        public void StopTesting() {
            Console.WriteLine("Item hasn't started yet..");
        }
    }
}
