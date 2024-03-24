using DevOps.Domain.Roles;
using DevOps.States.BacklogState;

namespace DevOps.Domain {
    public class DiscussionThread {
        public string Title { get; set; } 
        public BacklogItem RelatedBacklogItem { get; set; }

        public IBacklogState BacklogState { get; set; }
        public List<Message> Messages { get; set; }

        public List<DiscussionComment> Comments;
        public Func<string, Type, int> NotificationCallBack { get; set; }

        public DiscussionThread(string title, BacklogItem relatedBackLogItem, List<Message> messages, IBacklogState backlogState) {
            Title = title;
            RelatedBacklogItem = relatedBackLogItem;
            Messages = messages;
            Comments = new List<DiscussionComment>();
            RelatedBacklogItem.DiscussionThreads = new List<DiscussionThread>();
        }

        public List<Message> getMessages() {
            return this.Messages;
        }

        public int NotifyAll(DiscussionComment comment) {
            if (NotificationCallBack != null) {
                foreach (Type role in new Type[] { typeof(ScrumMaster), typeof(LeadDeveloper), typeof(Developer), typeof(ProductOwner), typeof(Tester) }) {
                    NotificationCallBack("A Comment has been sent for a backlog item.", role);
                }
                return 1;
            } else {
                return 0;
            }
        }

        public void AddComment(DiscussionComment comment) {
            if (RelatedBacklogItem.BacklogState.GetType().Equals(typeof(DoneState))) {
                throw new InvalidOperationException("Cannot add a comment to a completed backlog item.");
            }

            Comments.Add(comment);
            NotifyAll(comment);
        }

        public bool SprintStateIsFinished() {
            return (RelatedBacklogItem.BacklogState.GetType().Equals(typeof(DoneState)));
        }

        public void InitializeThread() {
            if (!SprintStateIsFinished()) {
                throw new InvalidOperationException("Not able to create a thread for the backlog item. Sprint has been finished already");
            }
            RelatedBacklogItem.DiscussionThreads.Add(this);
        }
    }
}
