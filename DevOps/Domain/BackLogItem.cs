﻿namespace DevOps.Domain {
    public class BacklogItem {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Sprint Sprint { get; set; }
        public List<DiscussionThread> DiscussionThreads { get; set; }
    }
}
