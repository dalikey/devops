using DevOps.Domain;

namespace DevOps.States.SprintState {
    public class SprintExecutionState : ISprintState {
        public void NextPhase() {
            Console.WriteLine("Moving to next phase.");
        }

        public void StartSprint() {
            Console.WriteLine("Cannot start sprint. Sprint already started.");
        }

        public void FinishSprint() {
            Console.WriteLine("Finishing sprint.");
        }

        public void Review(Sprint sprint) {
            Console.WriteLine("Cannot review. Sprint execution still in progress.");
        }

        public void Release(Sprint sprint) {
            Console.WriteLine("Cannot release. Sprint execution still in progress.");
        }

        public void CancelRelease(Sprint sprint) {
            Console.WriteLine("Cannot cancel release. Sprint execution still in progress.");
        }
    }
}
