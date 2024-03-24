using DevOps.Visitors;

namespace DevOps.Factories {
    public class DeployAction : IActionComponent {
        public string DeploymentTarget { get; set; }

        public void AcceptVisitor(IActionVisitor visitor) {
            visitor.Visit(this);
        }

        virtual public bool RunDeploymentTarget() {
            Console.WriteLine($"{DeploymentTarget}: Executing deployment tool");
            return true;
        }
    }
}
