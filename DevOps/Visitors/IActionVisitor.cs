using DevOps.Factories;

namespace DevOps.Visitors {
    public interface IActionVisitor {
        void Visit(AnalyseAction analyseAction);
        void Visit(DeployAction deployAction);
        void Visit(PackageAction packageAction);
        void Visit(BuildAction buildAction);
        void Visit(SourcesAction sourcesAction);
        void Visit(TestAction testAction);
        void Visit(UtilityAction utilityAction);
        void Visit(DeploymentPipeline deploymentPipeline);
    }
}
