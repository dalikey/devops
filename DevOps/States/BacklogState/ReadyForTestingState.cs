using DevOps.Domain;

namespace DevOps.States.BacklogState {
    public class ReadyForTestingState : IBacklogState {
        private readonly BacklogItem _backlogItem;

        public ReadyForTestingState(BacklogItem backlogItem) {
            _backlogItem = backlogItem;
        }

        public int FinishTask() => 0;

        public void InvalidateTask() {
            Console.WriteLine("Cannot invalidate task because it hasn't started yet.");
        }

        public void ReviewTestReport(bool passed) {
            Console.WriteLine("Cannot review test report because the task hasn't started yet.");
        }
        public int SendTestReport(bool passed) => 0;

        public void StartTask() {
           Console.WriteLine("Cannot start the task again as it's already ready for testing.");
        }

        public void StartTesting() {
            _backlogItem.UpdateState(new TestingState(_backlogItem));
        }

        public void StopTask() {
            Console.WriteLine("Cannot stop the task as it hasn't started yet.");
        }

        public void StopTesting() {
            Console.WriteLine("Cannot stop testing because the task hasn't started yet.");
        }
    }
}
