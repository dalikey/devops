﻿namespace DevOps.Domain {
    public class Message {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public Person Author { get; set; }
    }
}
