using DevOps.Visitors;

namespace DevOps.Factories {
    public class BuildAction : IActionComponent, IActionFactory {
        public string BuildType { get; set; }

        public void AcceptVisitor(IActionVisitor visitor) {
            visitor.Visit(this);
        }

        public IActionComponent CreateAction(string actionType) {
            if (actionType == "Build") {
                return new BuildAction { BuildType = "DefaultBuild" };
            } else {
                throw new ArgumentException("Invalid action type");
            }
        }

        public void Execute() {
            RunBuild();
        }

        virtual public bool RunBuild() {
            Console.WriteLine($"{BuildType}: Executing");
            return true;
        }
    }
}
