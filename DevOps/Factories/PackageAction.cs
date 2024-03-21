namespace DevOps.Factories {
    public class PackageAction : IActionVisitor, IActionComponent {
        public List<String> Dependencies { get; set; } = new List<String>();

        //Accepts visitor
        public bool VisitPackage(PackageAction packageAction) => false;
            
        public bool AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

        public bool Visit(IActionComponent actionComponent) {
            if (actionComponent is PackageAction packageAction) {
                return VisitPackage(packageAction);
            }

            return false;
        }

        //Run Action
        virtual public bool RunDeploymentTarget() {
            Console.WriteLine($"{Dependencies}: Installing dependencies");
            return true;
        }


    }
}
