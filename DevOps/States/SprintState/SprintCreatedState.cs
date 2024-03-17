using DevOps.Domain;

namespace DevOps.States.SprintState {
    public class SprintCreatedState : ISprintState {
        public void Review(Sprint sprint) {
            Console.WriteLine("Starting sprint review.");
            sprint.SetState(new SprintReviewingState());
        }

        public void Release(Sprint sprint) {
            Console.WriteLine("Cannot release. Sprint review not completed.");
        }

        public void CancelRelease(Sprint sprint) {
            Console.WriteLine("No release to cancel.");
        }
    }
}
