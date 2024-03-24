using DevOps.Visitors;

namespace DevOps.Factories {
    public class AnalyseAction : IActionComponent, IActionFactory {

        public string AnalyseTool { get; set; }

        public void AcceptVisitor(IActionVisitor visitor) {
            visitor.Visit(this);
        }

        public IActionComponent CreateAction(string actionType) {
            if (actionType == "Analyze") {
                return new AnalyseAction { AnalyseTool = "DefaultAnalyser" };
            } else {
                throw new ArgumentException("Invalid action type");
            }
        }

        public void Execute() {
            RunAnalysis();
        }

        virtual public bool RunAnalysis() {
            Console.WriteLine($"{AnalyseTool}: Executing code analysis");
            return true;
        }
    }
}
