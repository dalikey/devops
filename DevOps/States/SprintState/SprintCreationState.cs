using DevOps.Domain;

namespace DevOps.States.SprintState {
    public class SprintCreationState : ISprintState {
        public void NextPhase() {
            Console.WriteLine("Moving to planning phase.");
        }

        public void StartSprint() {
            Console.WriteLine("Starting sprint.");
        }

        public void FinishSprint() {
            Console.WriteLine("Cannot finish sprint. Sprint not started yet.");
        }

        public void Review(Sprint sprint) {
            Console.WriteLine("Cannot review. Sprint not started yet.");
        }

        public void Release(Sprint sprint) {
            Console.WriteLine("Cannot release. Sprint not started yet.");
        }

        public void CancelRelease(Sprint sprint) {
            Console.WriteLine("Cannot cancel release. No release to cancel.");
        }
    }
}
