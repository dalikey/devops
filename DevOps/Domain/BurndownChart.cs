namespace DevOps.Domain {
    public class BurndownChart {
        public List<int> RemainingEffort { get; set; }
        public DateTime SprintStartDate { get; set; }
        public DateTime SprintEndDate { get; set; }
    }
}
