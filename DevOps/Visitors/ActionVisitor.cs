using DevOps.Factories;

namespace DevOps.Visitors {
    public class ActionVisitor : IActionVisitor {
        public bool Visit(AnalyseAction analyseAction) {
            Console.WriteLine($"{analyseAction.AnalyseTool}: Executing code analysis");
            return true;
        }

        public bool Visit(DeployAction deployAction) {
            Console.WriteLine($"{deployAction.DeploymentTarget}: Executing deployment tool");
            return true;
        }

        public bool Visit(PackageAction packageAction) {
            Console.WriteLine($"{string.Join(",", packageAction.Dependencies)}: Installing dependencies");
            return true;
        }

        public bool Visit(BuildAction buildAction) {
            Console.WriteLine($"{buildAction.BuildType}: Executing build");
            return true;
        }

        public bool Visit(SourcesAction sourcesAction) {
            Console.WriteLine($"{sourcesAction.GitURL}: Cloning repository");
            return true;
        }

        public bool Visit(TestAction testAction) {
            Console.WriteLine($"{testAction.TestFramework}: Running test framework");
            return true;
        }

        public bool Visit(UtilityAction utilityAction) {
            foreach (var action in utilityAction.Actions) {
                Console.WriteLine($"{action}: Running utility action");
            }
            return true;
        }

        public bool Visit(DeploymentPipeline deploymentPipeline) {
            Console.WriteLine("Executing deployment pipeline");
            return true;
        }
    }
}