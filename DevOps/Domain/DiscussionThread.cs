namespace DevOps.Domain {
    public class DiscussionThread {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public BacklogItem RelatedBacklogItem { get; set; }
        public List<Message> Messages { get; set; }
    }
}
