using DevOps.Domain.Roles;
using DevOps.States.SprintState;

namespace DevOps.Domain {
    public class Sprint { 
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<BacklogItem> BacklogItems { get; set; }
        public ISprintState _currentState { get; set; }

        public Sprint() {
            BacklogItems = new List<BacklogItem>();
            _currentState = new SprintCreationState();
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

        public void AddBacklogItem(BacklogItem backlogItem) {
            BacklogItems.Add(backlogItem);
        }

        public void AssignDeveloperToBacklogItem(int backlogItemId, Developer developer) {
            var backlogItem = BacklogItems.Find(item => item.Id == backlogItemId);
            if (backlogItem != null) {
                backlogItem.Developer = developer;
            } else {
                throw new InvalidOperationException("Backlog item not found.");
            }
        }
    }
}
