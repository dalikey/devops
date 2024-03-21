using DevOps.Domain;

namespace DevOps.States.BacklogState {
    public class TestingState : IBacklogState {
        private readonly BacklogItem _backlogItem;

        public TestingState(BacklogItem backlogItem) {
            _backlogItem = backlogItem;
        }

        public int FinishTask() => 0;

        public void InvalidateTask() {
            Console.WriteLine("Item hasn't started yet..");
        }

        public void ReviewTestReport(bool passed) {
            Console.WriteLine("Item hasn't started yet..");
        }

        public int SendTestReport(bool passed) {
            if (!passed) {
                _backlogItem.UpdateState(new TodoState(_backlogItem));
                return _backlogItem.NotifyScrumMaster();
            } else {
                _backlogItem.UpdateState(new TestedState(_backlogItem));
                return 0;
            }
        }

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
