using DevOps.Visitors;

namespace DevOps.Factories {
    public class DeploymentPipeline : IActionComponent {
        public void AcceptVisitor(IActionVisitor visitor) {
            visitor.Visit(this);
        }

        virtual public bool RunDeploymentPipe() {
            Console.WriteLine($"Executing deployment pipeline");
            return true;
        }
    }
}
