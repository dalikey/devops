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

        public void Visit(AnalyseAction analyseAction) {
            VisitedAnalyseAction = true;
        }

        public void Visit(BuildAction buildAction) {
            VisitedBuildAction = true;
        }

        public void Visit(DeployAction deployAction) {
            VisitedDeployAction = true;
        }

        public void Visit(DeploymentPipeline deploymentPipeline) {
            VisitedDeploymentPipeline = true;
        }

        public void Visit(PackageAction packageAction) {
            VisitedPackageAction = true;
        }

        public void Visit(SourcesAction sourcesAction) {
            VisitedSourcesAction = true;
        }

        public void Visit(TestAction testAction) {
            VisitedTestAction = true;
        }

        public void Visit(UtilityAction utilityAction) {
            VisitedUtilityAction = true;
        }
    }
}
