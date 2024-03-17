using DevOps.Domain;

namespace DevOps.States {
    public interface ISprintState {
        void Review(Sprint sprint);
        void Release(Sprint sprint);
        void CancelRelease(Sprint sprint);
    }
}
