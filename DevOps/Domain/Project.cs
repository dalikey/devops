namespace DevOps.Domain {
    public class Project {
        public string Name { get; set; }
        public List<BacklogItem> BacklogItems { get; set; }
        public List<Sprint> Sprints { get; set; }

        public Project(string name) {
            Name = name;
            BacklogItems = new List<BacklogItem>();
            Sprints = new List<Sprint>();
        }

        public void AddBacklogItem(BacklogItem backlogItem) {
            BacklogItems.Add(backlogItem);
            BacklogItems.Sort((x, y) => x.Id.CompareTo(y.Id));
        }

        public void AddSprint(Sprint sprint) {
            Sprints.Add(sprint);
        }
    }
}
