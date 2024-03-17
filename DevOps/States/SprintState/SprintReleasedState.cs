using DevOps.Domain;

namespace DevOps.States.SprintState {
    public class SprintReleasedState : ISprintState {
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
