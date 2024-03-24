using DevOps.Visitors;

namespace DevOps.Factories {
    public class DeployAction : IActionComponent, IActionFactory {
        public string DeploymentTarget { get; set; }

        public void AcceptVisitor(IActionVisitor visitor) {
            visitor.Visit(this);
        }

        public IActionComponent CreateAction(string actionType) {
            if (actionType == "Deploy") {
                return new DeployAction { DeploymentTarget = "DefaultDeploymentTarget" };
            } else {
                throw new ArgumentException("Invalid action type");
            }
        }

        public void Execute() {
            RunDependencyInstallation();
        }

        virtual public bool RunDependencyInstallation() {
            Console.WriteLine($"{DeploymentTarget}: Executing deployment tool");
            return true;
        }
    }
}
