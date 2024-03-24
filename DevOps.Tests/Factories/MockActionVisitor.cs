using DevOps.Factories;
using DevOps.Visitors;

namespace DevOps.Tests.Factories {
    // Mock class for IActionVisitor to verify method invocation
    public class MockActionVisitor : IActionVisitor {
        public bool VisitedAnalyseAction { get; private set; }
        public bool VisitedBuildAction { get; private set; }
        public bool VisitedDeployAction { get; private set; }
        public bool VisitedDeploymentPipeline { get; private set; }
        public bool VisitedPackageAction { get; private set; }
        public bool VisitedSourcesAction { get; private set; }
        public bool VisitedTestAction { get; private set; }
        public bool VisitedUtilityAction { get; private set; }

        public bool Visit(AnalyseAction analyseAction) {
            VisitedAnalyseAction = true;
            return true; // Simulate success
        }

        public bool Visit(BuildAction buildAction) {
            VisitedBuildAction = true;
            return true;
        }

        public bool Visit(DeployAction deployAction) {
            VisitedDeployAction = true;
            return true;
        }

        public bool Visit(DeploymentPipeline deploymentPipeline) {
            VisitedDeploymentPipeline = true;
            return true;
        }

        public bool Visit(PackageAction packageAction) {
            VisitedPackageAction = true;
            return true;
        }

        public bool Visit(SourcesAction sourcesAction) {
            VisitedSourcesAction = true;
            return true;
        }

        public bool Visit(TestAction testAction) {
            VisitedTestAction = true;
            return true;
        }

        public bool Visit(UtilityAction utilityAction) {
            VisitedUtilityAction = true;
            return true;
        }
    }
}
