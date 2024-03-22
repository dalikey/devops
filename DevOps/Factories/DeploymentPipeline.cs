
namespace DevOps.Factories {
    public class DeploymentPipeline : IActionComponent {

        public bool VisitDeployementPipeline(DeploymentPipeline pipeline) => false;

        public bool AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

        virtual public bool RunDeploymentPipe() {
            Console.WriteLine($"Executing deployment pipeline");
            return true;
        }
    }
}
