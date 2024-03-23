using DevOps.Factories;

namespace DevOps.Visitors {
    public interface IActionVisitor {
        bool Visit(AnalyseAction analyseAction);
        bool Visit(DeployAction deployAction);
        bool Visit(PackageAction packageAction);
        bool Visit(BuildAction buildAction);
        bool Visit(SourcesAction sourcesAction);
        bool Visit(TestAction testAction);
        bool Visit(UtilityAction utilityAction);
        bool Visit(DeploymentPipeline deploymentPipeline);
    }
}
