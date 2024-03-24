using DevOps.Domain;

namespace DevOps.States.SprintState {
    public class SprintReviewingState : ISprintState {
        public void NextPhase() {
            Console.WriteLine("Cannot proceed to next phase. Sprint is still under review.");
        }

        public void StartSprint() {
            Console.WriteLine("Cannot start sprint. Sprint is still under review.");
        }

        public void FinishSprint() {
            Console.WriteLine("Cannot finish sprint. Sprint is still under review.");
        }

        public void Review(Sprint sprint) {
            Console.WriteLine("Sprint already under review.");
        }

        public void Release(Sprint sprint) {
            Console.WriteLine("Releasing sprint.");
            sprint.SetState(new SprintReleasedState());
        }

        public void CancelRelease(Sprint sprint) {
            Console.WriteLine("Cancelling sprint release.");
            sprint.SetState(new SprintCreationState());
        }
    }
}
