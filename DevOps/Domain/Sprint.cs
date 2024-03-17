using DevOps.States;
using DevOps.States.SprintState;

namespace DevOps.Domain {
    public class Sprint {
        public ISprintState _currentState { get; set; }

        public Sprint() {
            _currentState = new SprintCreatedState();
        }

        public void SetState(ISprintState state) {
            _currentState = state;
        }

        public void Review() {
            _currentState.Review(this);
        }

        public void Release() {
            _currentState.Release(this);
        }

        public void CancelRelease() {
            _currentState.CancelRelease(this);
        }
    }
}
