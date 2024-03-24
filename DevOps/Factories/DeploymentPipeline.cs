using DevOps.Visitors;

namespace DevOps.Factories {
    public class DeploymentPipeline : IActionComponent, IActionFactory {
        public void AcceptVisitor(IActionVisitor visitor) {
            visitor.Visit(this);
        }

        public IActionComponent CreateAction(string actionType) {
            if (actionType == "DeploymentPipeline") {
                return new DeploymentPipeline();
            } else {
                throw new ArgumentException("Invalid action type");
            }
        }

        public void Execute() {
            RunDeploymentPipe();
        }

        virtual public bool RunDeploymentPipe() {
            Console.WriteLine($"Executing deployment pipeline");
            return true;
        }
    }
}
