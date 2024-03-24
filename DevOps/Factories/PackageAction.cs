using DevOps.Visitors;

namespace DevOps.Factories {
    public class PackageAction : IActionComponent, IActionFactory {
        public List<String> Dependencies { get; set; } = new List<String>();

        public void AcceptVisitor(IActionVisitor visitor) {
            visitor.Visit(this);
        }

        public IActionComponent CreateAction(string actionType) {
            if (actionType == "PackageAction") {
                return new PackageAction();
            } else {
                throw new ArgumentException("Invalid action type");
            }
        }

        public void Execute() {
            RunDependencyInstallation();
        }

        virtual public bool RunDependencyInstallation() {
            string dependenciesString = string.Join(",", Dependencies);
            Console.WriteLine($"{dependenciesString}: Installing dependencies");
            return true;
        }
    }
}
