using DevOps.Domain;

namespace DevOps.States.BacklogState {
    public class TestedState : IBacklogState {
        private readonly BacklogItem _backlogItem;

        public TestedState(BacklogItem backlogItem) {
            _backlogItem = backlogItem;
        }

        public int FinishTask() => 0;

        public void InvalidateTask() {
            Console.WriteLine("Cannot invalidate task because it's already tested.");
        }

        public void ReviewTestReport(bool passed) {
            if (!passed) {
                Console.WriteLine("Test report indicates failure. Moving back to ready for testing state.");
                _backlogItem.UpdateState(new ReadyForTestingState(_backlogItem));
            } else {
                Console.WriteLine("Test report indicates success. Moving to done state.");
                _backlogItem.UpdateState(new DoneState(_backlogItem));
            }
        }

        public int SendTestReport(bool passed) => 0;

        public void StartTask() {
            Console.WriteLine("Cannot start the task again as it's already tested.");
        }

        public void StartTesting() {
            Console.WriteLine("Cannot start testing again as the task is already tested.");
        }

        public void StopTask() {
            Console.WriteLine("Cannot stop the task as it's already tested.");
        }

        public void StopTesting() {
            Console.WriteLine("Cannot stop testing as the task is already tested.");
        }
    }
}
