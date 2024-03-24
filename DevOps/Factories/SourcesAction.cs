using DevOps.Visitors;

namespace DevOps.Factories {
    public class SourcesAction : IActionComponent, IActionFactory {
        public string GitURL { get; set; }

        public void AcceptVisitor(IActionVisitor visitor) {
            visitor.Visit(this);
        }

        public IActionComponent CreateAction(string actionType) {
            if (actionType == "SourcesAction") {
                return new SourcesAction();
            } else {
                throw new ArgumentException("Invalid action type");
            }
        }

        public void Execute() {
            CloneRepository();
        }

        virtual public bool CloneRepository() {
            Console.WriteLine($"{GitURL}: Cloning Repository");
            return true;
        }
    }
}
