using DevOps.Adapters;
using DevOps.Decorators;
using DevOps.Domain;
using DevOps.Factories;
using System.Diagnostics.CodeAnalysis;

namespace DevOps {
    [ExcludeFromCodeCoverage]
    public static class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hi");
            Sprint sprint = new Sprint();

            sprint.Review(); // Sprint moves to reviewing state
            sprint.Release(); // Sprint moves to released state
            sprint.Release(); // Sprint already released, no action taken
            sprint.CancelRelease(); // Cancel the release, sprint moves back to created state
            sprint.Release(); // Sprint moves to released state again

            Console.WriteLine("\n-----------------------");
            // Mock data for header and footer
            var companyName = "Your Company";
            var projectName = "Your Project";
            var version = "1.0";
            var date = DateTime.Now;

            // Mock data for sprint information
            var sprints = new List<(string, TeamComposition, BurndownChart, List<DeveloperEffortPoints>)>();

            var sprint1 = (
                "Sprint 1",
                new TeamComposition { TeamName = "Team Alpha", Developers = new List<string> { "Developer A", "Developer B", "Developer C" } },
                new BurndownChart { RemainingEffort = new List<int> { 10, 8, 6, 4, 2 }, SprintStartDate = DateTime.Now.AddDays(-7), SprintEndDate = DateTime.Now.AddDays(7) },
                new List<DeveloperEffortPoints> {
                new DeveloperEffortPoints { DeveloperName = "Developer A", EffortPoints = 20 },
                new DeveloperEffortPoints { DeveloperName = "Developer B", EffortPoints = 18 },
                new DeveloperEffortPoints { DeveloperName = "Developer C", EffortPoints = 15 }
                }
            );

            var sprint2 = (
                "Sprint 2",
                new TeamComposition { TeamName = "Team Beta", Developers = new List<string> { "Developer X", "Developer Y", "Developer Z" } },
                new BurndownChart { RemainingEffort = new List<int> { 8, 6, 4, 2, 1 }, SprintStartDate = DateTime.Now.AddDays(-14), SprintEndDate = DateTime.Now.AddDays(-7) },
                new List<DeveloperEffortPoints> {
                new DeveloperEffortPoints { DeveloperName = "Developer X", EffortPoints = 25 },
                new DeveloperEffortPoints { DeveloperName = "Developer Y", EffortPoints = 22 },
                new DeveloperEffortPoints { DeveloperName = "Developer Z", EffortPoints = 18 }
                }
            );

            sprints.Add(sprint1);
            sprints.Add(sprint2);

            // Create a basic report with header and footer
            IReport basicReport = new BasicReport(sprints);
            IReport reportWithHeaderAndFooter = new FooterDecorator(
                                                    new HeaderDecorator(basicReport, companyName, projectName, version, date),
                                                    companyName, projectName, version, date);

            // Generate the report
            reportWithHeaderAndFooter.GenerateReport();

            Console.WriteLine("\n-----------------------");
            // Create instances of adapters
            IMediaAdapter emailAdapter = new EmailAdapter();
            IMediaAdapter slackAdapter = new SlackAdapter();
            IMediaAdapter smsAdapter = new SmsAdapter();

            // Send notifications using each adapter
            emailAdapter.SendNotification("Hello from email adapter");
            slackAdapter.SendNotification("Hello from Slack adapter");
            smsAdapter.SendNotification("Hello from SMS adapter");

            Console.WriteLine("\n-----------------------");
            // Create instances of different action components
            var actions = new List<IActionComponent> {
                new AnalyseAction { AnalyseTool = "CodeAnalyzer" },
                new DeployAction { DeploymentTarget = "Production" },
                new PackageAction { Dependencies = new List<string> { "Dependency1", "Dependency2" } },
                new BuildAction { BuildType = "Release" },
                new SourcesAction { GitURL = "https://github.com/yourrepository.git" },
                new TestAction { TestFramework = "NUnit" },
                new UtilityAction { Actions = new List<string> { "Action1", "Action2" } },
                new DeploymentPipeline()
            };

            // Create an instance of ActionVisitor
            var visitor = new ActionVisitor();

            // Iterate through each action component and accept the visitor
            foreach (var action in actions) {
                action.AcceptVisitor(visitor);
            }
        }
    }
}
