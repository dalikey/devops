namespace DevOps.Domain {
    public class DiscussionComment { 
        public string Text { get; }
        public DateTime CreatedAt { get; }
        public string Author { get; }

        public DiscussionComment(string text, string author) {
            Text = text;
            CreatedAt = DateTime.UtcNow;
            Author = author;
        }
    }
}
