using DevOps.States;

namespace DevOps.Domain {
    public class Sprint {
        public ISprintState State { get; set; }

        public Sprint(ISprintState state) {
            State = state;
        }

        public void Handle() {
            State.Handle(this);
        }
    }
}
