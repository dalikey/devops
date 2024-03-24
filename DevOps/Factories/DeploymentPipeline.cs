using DevOps.Visitors;

namespace DevOps.Factories {
    public class DeploymentPipeline : IActionComponent {
        public bool AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

        virtual public bool RunDeploymentPipe() {
            Console.WriteLine($"Executing deployment pipeline");
            return true;
        }
    }
}
