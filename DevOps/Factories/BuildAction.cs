using DevOps.Visitors;

namespace DevOps.Factories {
    public class BuildAction : IActionComponent {
        public string BuildType { get; set; }

        public void AcceptVisitor(IActionVisitor visitor) {
            visitor.Visit(this);
        }

        virtual public bool RunBuild() {
            Console.WriteLine($"{BuildType}: Executing");
            return true;
        }
    }
}
