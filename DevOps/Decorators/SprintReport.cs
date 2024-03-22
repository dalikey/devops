using DevOps.Domain;

namespace DevOps.Decorators {
    public class SprintDecorator : IReport {
        private readonly IReport _report;
        private readonly string _sprintName;
        private readonly TeamComposition _teamComposition;
        private readonly BurndownChart _burndownChart;
        private readonly List<DeveloperEffortPoints> _effortPointsPerDeveloper;

        public SprintDecorator(IReport report, string sprintName, TeamComposition teamComposition, BurndownChart burndownChart, List<DeveloperEffortPoints> effortPointsPerDeveloper) {
            _report = report;
            _sprintName = sprintName;
            _teamComposition = teamComposition;
            _burndownChart = burndownChart;
            _effortPointsPerDeveloper = effortPointsPerDeveloper;
        }

        public void GenerateReport() {
            Console.WriteLine($"Sprint: {_sprintName}");
            Console.WriteLine($"Sprint Team: {_teamComposition.TeamName}");
            Console.WriteLine("Team Composition:");
            foreach (var developer in _teamComposition.Developers) {
                Console.WriteLine($"- {developer}");
            }
            Console.WriteLine("Burndown Chart:");
            Console.WriteLine($"Sprint Start Date: {_burndownChart.SprintStartDate}");
            Console.WriteLine($"Sprint End Date: {_burndownChart.SprintEndDate}");
            Console.WriteLine("Remaining Effort:");
            foreach (var remainingEffort in _burndownChart.RemainingEffort) {
                Console.WriteLine($"- {remainingEffort}");
            }
            Console.WriteLine("Effort Points per Developer:");
            foreach (var effortPoints in _effortPointsPerDeveloper) {
                Console.WriteLine($"- {effortPoints.DeveloperName}: {effortPoints.EffortPoints}");
            }
            _report.GenerateReport();
        }
    }
}
