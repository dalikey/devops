using DevOps.Domain;

namespace DevOps.States.SprintState {
    public class SprintTestingState : ISprintState {
        public void NextPhase() {
            Console.WriteLine("Moving to next phase.");
        }

        public void StartSprint() {
            Console.WriteLine("Cannot start sprint. Sprint testing already in progress.");
        }

        public void FinishSprint() {
            Console.WriteLine("Cannot finish sprint. Sprint testing still in progress.");
        }

        public void Review(Sprint sprint) {
            Console.WriteLine("Cannot review. Sprint testing still in progress.");
        }

        public void Release(Sprint sprint) {
            Console.WriteLine("Releasing sprint.");
        }

        public void CancelRelease(Sprint sprint) {
            Console.WriteLine("Cannot cancel release. Sprint testing still in progress.");
        }
    }
}
