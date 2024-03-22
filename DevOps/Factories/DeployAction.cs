namespace DevOps.Factories {
    public class DeployAction : IActionComponent, IActionVisitor {
        public string DeploymentTarget { get; set; }

        public bool VisitDeploy(DeployAction deployAction) => false;

        //Accepts visitor
        public bool AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

        public bool Visit(IActionComponent actionComponent) {
            if (actionComponent is DeployAction deployAction) {
                return VisitDeploy(deployAction);
            }

            return false;
        }

        //Run Action
        virtual public bool RunDeploymentTarget() {
            Console.WriteLine($"{DeploymentTarget}: Executing deployment tool");
            return true;
        }
    }
}
