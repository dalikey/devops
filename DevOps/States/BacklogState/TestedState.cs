using DevOps.Domain;

namespace DevOps.States.BacklogState {
    public class TestedState : IBacklogState {
        private readonly BacklogItem _backlogItem;

        public TestedState(BacklogItem backlogItem) {
            _backlogItem = backlogItem;
        }

        public int FinishTask() => 0;

        public void InvalidateTask() {
            Console.WriteLine("Item hasn't started yet..");
        }

        public void ReviewTestReport(bool passed) {
            if (!passed) {
                _backlogItem.UpdateState(new ReadyForTestingState(_backlogItem));
            } else {
                _backlogItem.UpdateState(new DoneState(_backlogItem));
            }
        }

        public int SendTestReport(bool passed) => 0;

        public void StartTask() {
            Console.WriteLine("Item hasn't started yet..");
        }

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
