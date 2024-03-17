using DevOps.Domain;

namespace DevOps.States {
    public interface ISprintState {
        void Handle(Sprint sprint);
    }
}
