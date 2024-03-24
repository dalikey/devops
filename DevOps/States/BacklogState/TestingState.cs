using DevOps.Domain;

namespace DevOps.States.BacklogState {
    public class TestingState : IBacklogState {
        private readonly BacklogItem _backlogItem;

        public TestingState(BacklogItem backlogItem) {
            _backlogItem = backlogItem;
        }

        public int FinishTask() => 0;

        public void InvalidateTask() {
            Console.WriteLine("Cannot invalidate task while it's being tested.");
        }

        public void MarkAsDone() {
            _backlogItem.UpdateState(new DoneState(_backlogItem));
            Console.WriteLine("Backlog item marked as done.");
        }

        public void ReviewTestReport(bool passed) {
            if (passed) {
                _backlogItem.BacklogState = new TestedState(_backlogItem);
            } else {
                Console.WriteLine("Test failed. Cannot update state.");
            }
        }

        public int SendTestReport(bool passed) {
            if (!passed) {
                Console.WriteLine("Test report indicates failure. Moving back to todo state.");
                _backlogItem.UpdateState(new TodoState(_backlogItem));
                return _backlogItem.NotifyScrumMaster();
            } else {
                Console.WriteLine("Test report indicates success. Moving to tested state.");
                _backlogItem.UpdateState(new TestedState(_backlogItem));
                return 0;
            }
        }

        public void StartTask() {
            Console.WriteLine("Cannot start the task again as it's already being tested.");
        }

        public void StartTesting() {
            Console.WriteLine("Cannot start testing again as the task is already being tested.");
        }

        public void StopTask() {
            Console.WriteLine("Cannot stop the task as it's already being tested.");
        }

        public void StopTesting() {
            Console.WriteLine("Cannot stop testing as the task is already being tested.");
        }
    }
}
