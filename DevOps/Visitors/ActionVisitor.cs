using DevOps.Factories;

namespace DevOps.Visitors {
    public class ActionVisitor : IActionVisitor {
        public void Visit(AnalyseAction analyseAction) {
            Console.WriteLine($"{analyseAction.AnalyseTool}: Executing code analysis");
        }

        public void Visit(DeployAction deployAction) {
            Console.WriteLine($"{deployAction.DeploymentTarget}: Executing deployment tool");
        }

        public void Visit(PackageAction packageAction) {
            Console.WriteLine($"{string.Join(",", packageAction.Dependencies)}: Installing dependencies");
        }

        public void Visit(BuildAction buildAction) {
            Console.WriteLine($"{buildAction.BuildType}: Executing build");
        }

        public void Visit(SourcesAction sourcesAction) {
            Console.WriteLine($"{sourcesAction.GitURL}: Cloning repository");
        }

        public void Visit(TestAction testAction) {
            Console.WriteLine($"{testAction.TestFramework}: Running test framework");
        }

        public void Visit(UtilityAction utilityAction) {
            foreach (var action in utilityAction.Actions) {
                Console.WriteLine($"{action}: Running utility action");
            }
        }
    }
}