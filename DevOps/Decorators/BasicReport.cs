using DevOps.Domain;

namespace DevOps.Decorators {
    public class BasicReport : IReport {
        private readonly List<(string, TeamComposition, BurndownChart, List<DeveloperEffortPoints>)> _sprints;

        public BasicReport(List<(string, TeamComposition, BurndownChart, List<DeveloperEffortPoints>)> sprints) {
            _sprints = sprints;
        }

        public void GenerateReport() {
            Console.WriteLine("Generating basic report...");

            // Generate sprint information
            foreach (var sprint in _sprints) {
                Console.WriteLine($"Sprint: {sprint.Item1}");
                Console.WriteLine($"Sprint Team: {sprint.Item2.TeamName}");
                Console.WriteLine("Team Composition:");
                foreach (var developer in sprint.Item2.Developers) {
                    Console.WriteLine($"- {developer}");
                }
                Console.WriteLine("Burndown Chart:");
                Console.WriteLine($"Sprint Start Date: {sprint.Item3.SprintStartDate}");
                Console.WriteLine($"Sprint End Date: {sprint.Item3.SprintEndDate}");
                Console.WriteLine("Remaining Effort:");
                foreach (var remainingEffort in sprint.Item3.RemainingEffort) {
                    Console.WriteLine($"- {remainingEffort}");
                }
                Console.WriteLine("Effort Points per Developer:");
                foreach (var effortPoints in sprint.Item4) {
                    Console.WriteLine($"- {effortPoints.DeveloperName}: {effortPoints.EffortPoints}");
                }
            }
        }
    }
}
