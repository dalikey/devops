using DevOps.Domain;
using System;

namespace DevOps.States.Backlog {
    public class DoingState : IBacklogState {
        private readonly BacklogItem _backlogItem;

        public DoingState(BacklogItem backlogItem) {
            _backlogItem = backlogItem;
        }

        public int FinishTask() {
            // Implement activities here.
            return 0;
        }

        public void InvalidateTask() {
            Console.WriteLine("Item hasn't started yet..");
        }

        public void ReviewTestReport(bool passed) {
            Console.WriteLine("Item hasn't started yet..");
        }

        public int SendTestReport(bool passed) {
            return 0;
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