using DevOps.Visitors;

namespace DevOps.Factories {
    public class AnalyseAction : IActionComponent {

        public string AnalyseTool { get; set; }

        public void AcceptVisitor(IActionVisitor visitor) {
            visitor.Visit(this);
        }

        virtual public bool RunAnalysis() {
            Console.WriteLine($"{AnalyseTool}: Executing code analysis");
            return true;
        }
    }
}
