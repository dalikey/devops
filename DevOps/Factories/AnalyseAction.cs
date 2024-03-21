namespace DevOps.Factories {
    public class AnalyseAction : IActionVisitor, IActionComponent {

        public string AnalyseTool { get; set; }

        public bool VisitAnalyse(AnalyseAction analyseAction) => false;

        //Accepts visitor
        public bool AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

        public bool Visit(IActionComponent actionComponent) {
            if (actionComponent is AnalyseAction packageAction) {
                return VisitAnalyse(packageAction);
            }
            return false;
        }

        //Run Action
        virtual public bool RunAnalysis() {
            Console.WriteLine($"{AnalyseTool}: Executing code analysis");
            return true;
        }
    }
}
