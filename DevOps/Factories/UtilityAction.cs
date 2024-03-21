namespace DevOps.Factories {
    public class UtilityAction : IActionComponent, IActionVisitor {
        public List<String> Actions { get; set; } = new List<String>();

        public bool VisitUtility(UtilityAction action) => false;

        public bool AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

        public bool Visit(IActionComponent actionComponent) {
            if (actionComponent is UtilityAction utilityAction) {
                return VisitUtility(utilityAction);
            }

            return false;
        }

        virtual public bool RunUtilityActions() {
            foreach (var action in Actions) {
                Console.WriteLine($"{action}: Action is running");
            }

            return true;
        }
    }
}
