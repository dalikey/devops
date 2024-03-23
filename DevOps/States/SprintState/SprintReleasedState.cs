using DevOps.Domain;

namespace DevOps.States.SprintState {
    public class SprintReleasedState : ISprintState {
        public void NextPhase() {
            Console.WriteLine("Cannot proceed to next phase. Sprint already released.");
        }

        public void StartSprint() {
            Console.WriteLine("Cannot start sprint. Sprint already released.");
        }

        public void FinishSprint() {
            Console.WriteLine("Cannot finish sprint. Sprint already released.");
        }

        public void Review(Sprint sprint) {
            Console.WriteLine("Cannot review. Sprint already released.");
        }

        public void Release(Sprint sprint) {
            Console.WriteLine("Cannot release. Sprint already released.");
        }

        public void CancelRelease(Sprint sprint) {
            Console.WriteLine("No release to cancel.");
        }
    }
}
