using DevOps.Visitors;

namespace DevOps.Factories {
    public class UtilityAction : IActionComponent {
        public List<String> Actions { get; set; } = new List<String>();

        public void AcceptVisitor(IActionVisitor visitor) {
            visitor.Visit(this);
        }

        virtual public bool RunUtilityActions() {
            foreach (var action in Actions) {
                Console.WriteLine($"{action}: Action is running");
            }

            return true;
        }
    }
}
