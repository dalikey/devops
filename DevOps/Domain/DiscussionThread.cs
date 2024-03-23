using DevOps.Observers;
using DevOps.States.BacklogState;

namespace DevOps.Domain {
    public class DiscussionThread {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public BacklogItem RelatedBacklogItem { get; set; }
        public List<Message> Messages { get; set; }
        public Person Person { get; set; }
        public List<DiscussionComment> Comments;
        public NotificationService NotificationService { get; set; }

        public DiscussionThread(int id, string title, string description, BacklogItem relatedBackLogItem, List<Message> messages, Person person, List<DiscussionComment> comments, NotificationService notificationService) {
            Id = id;
            Title = title;
            Description = description;
            RelatedBacklogItem = relatedBackLogItem;
            Messages = messages;
            Person = person;
            Comments = comments;
            NotificationService = notificationService;
        }

        public List<Message> getMessages() {
            return this.Messages;
        }

        public void AddComment(DiscussionComment comment) {
            if (RelatedBacklogItem.BacklogState.GetType().Equals(typeof(DoneState))) {
                throw new InvalidOperationException("Cannot add a comment to a completed backlog item.");
            }

            Comments.Add(comment);
            NotifyAll(comment);
        }

        private void NotifyAll(DiscussionComment comment) {
            NotificationService.NotifyObservers($"A comment has been added for backlog item {RelatedBacklogItem.Id}: {comment.Text}");
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
