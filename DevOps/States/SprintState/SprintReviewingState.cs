using DevOps.Domain;

namespace DevOps.States.SprintState {
    public class SprintReviewingState : ISprintState {
        public void Review(Sprint sprint) {
            Console.WriteLine("Sprint already under review.");
        }

        public void Release(Sprint sprint) {
            Console.WriteLine("Releasing sprint.");
            sprint.SetState(new SprintReleasedState());
        }

        public void CancelRelease(Sprint sprint) {
            Console.WriteLine("Cancelling sprint release.");
            sprint.SetState(new SprintCreatedState());
        }
    }
}
