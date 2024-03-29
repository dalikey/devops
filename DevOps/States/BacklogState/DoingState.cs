using DevOps.Domain;
using System;

namespace DevOps.States.BacklogState {
    public class DoingState : IBacklogState {
        private readonly BacklogItem _backlogItem;

        public DoingState(BacklogItem backlogItem) {
            _backlogItem = backlogItem;
        }

        public int FinishTask() {
            if (_backlogItem.Activities.All(a => a.IsFinished)) {
                _backlogItem.UpdateState(new ReadyForTestingState(_backlogItem));
                return _backlogItem.NotifyTesters();
            }

            Console.WriteLine("All activities are not finished!");
            return 0;
        }

        public void InvalidateTask() {
            Console.WriteLine("Task cannot be invalidated while it's in progress.");
        }

        public void MarkAsDone() {
            Console.WriteLine("Cannot mark as done while the task is in progress.");
        }

        public void ReviewTestReport(bool passed) {
            Console.WriteLine("Cannot review test report until the task is completed.");
        }

        public int SendTestReport(bool passed) {
            return 0;
        }

        public void StartTask() {
            Console.WriteLine("Task is already in progress.");
        }

        public void StartTesting() {
            Console.WriteLine("Testing cannot be started until the task is completed.");
        }

        public void StopTask() {
            Console.WriteLine("Task has been stopped.");
        }

        public void StopTesting() {
            Console.WriteLine("Testing cannot be stopped until the task is completed.");
        }
    }
}