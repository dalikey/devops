using DevOps.Visitors;

namespace DevOps.Factories {
    public class UtilityAction : IActionComponent, IActionFactory {
        public List<String> Actions { get; set; } = new List<String>();

        public void AcceptVisitor(IActionVisitor visitor) {
            visitor.Visit(this);
        }

        public IActionComponent CreateAction(string actionType) {
            if (actionType == "UtilityAction") {
                return new UtilityAction();
            } else {
                throw new ArgumentException("Invalid action type");
            }
        }

        public void Execute() {
            RunUtilityActions();
        }

        virtual public bool RunUtilityActions() {
            foreach (var action in Actions) {
                Console.WriteLine($"{action}: Action is running");
            }

            return true;
        }
    }
}
