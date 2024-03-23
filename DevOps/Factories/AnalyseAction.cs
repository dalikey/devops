namespace DevOps.Factories {
    public class AnalyseAction : IActionComponent {

        public string AnalyseTool { get; set; }

        public bool AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

        virtual public bool RunAnalysis() {
            Console.WriteLine($"{AnalyseTool}: Executing code analysis");
            return true;
        }
    }
}
