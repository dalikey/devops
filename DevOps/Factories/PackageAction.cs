namespace DevOps.Factories {
    public class PackageAction : IActionComponent {
        public List<String> Dependencies { get; set; } = new List<String>();

        public bool VisitPackage(PackageAction packageAction) => false;
            
        public bool AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

        virtual public bool RunDeploymentTarget() {
            Console.WriteLine($"{Dependencies}: Installing dependencies");
            return true;
        }
    }
}
