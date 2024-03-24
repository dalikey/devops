using DevOps.Visitors;

namespace DevOps.Factories {
    public class PackageAction : IActionComponent {
        public List<String> Dependencies { get; set; } = new List<String>();

        public bool AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

        virtual public bool RunDeploymentTarget() {
            string dependenciesString = string.Join(",", Dependencies);
            Console.WriteLine($"{dependenciesString}: Installing dependencies");
            return true;
        }
    }
}
