using DevOps.Domain;

namespace DevOps.States.BacklogState {
    public class TestingState : IBacklogState {
        private readonly BacklogItem _backlogItem;

        public TestingState(BacklogItem backlogItem) {
            _backlogItem = backlogItem;
        }

        public void FinishTask() {
            Console.WriteLine("Cannot finish the task while it's being tested.");
        }

        public void InvalidateTask() {
            Console.WriteLine("Cannot invalidate task while it's being tested.");
        }

        public void ReviewTestReport(bool passed) {
            Console.WriteLine("Cannot review test report while the task is being tested.");
        }

        public void SendTestReport(bool passed) {
            if (!passed) {
                Console.WriteLine("Test report indicates failure. Moving back to todo state.");
                _backlogItem.UpdateState(new TodoState(_backlogItem));
                _backlogItem.NotifyScrumMaster();
            } else {
                Console.WriteLine("Test report indicates success. Moving to tested state.");
                _backlogItem.UpdateState(new TestedState(_backlogItem));
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
