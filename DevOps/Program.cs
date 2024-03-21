using DevOps.Adapters;
using DevOps.Decorators;
using DevOps.Domain;
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
            // Define the sequence of actions in the pipeline
            List<string> actionTypes = new List<string> { "Sources", "Package", "Build", "Test", "Analyze", "Deploy", "Utility" };

            // Create a pipeline with the defined actions
            Pipeline pipeline = new Pipeline(actionTypes);

            // Execute the pipeline
            pipeline.Execute();

            Console.WriteLine("\n-----------------------");
            // Create basic report
            IReport basicReport = new BasicReport();

            // Add header and footer with additional information
            var companyName = "Your Company";
            var projectName = "Your Project";
            var version = "1.0";
            var date = DateTime.Now;

            IReport reportWithHeaderAndFooter = new FooterDecorator(
                                                    new HeaderDecorator(basicReport, companyName, projectName, version, date),
                                                    companyName, projectName, version, date);

            // Generate the report with header and footer
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
        }
    }
}
