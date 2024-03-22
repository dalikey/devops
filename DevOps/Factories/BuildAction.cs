namespace DevOps.Factories {
    public class BuildAction : IActionComponent, IActionVisitor {
        public string BuildType { get; set; }

        public bool VisitBuild(BuildAction buildAction) => false;

        //Accepts visitor
        public bool AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

        public bool Visit(IActionComponent actionComponent) {
            if (actionComponent is BuildAction buildAction) {
                return VisitBuild(buildAction);
            }
            return false;
        }

        //Run Action
        virtual public bool RunBuild() {
            Console.WriteLine($"{BuildType}: Executing");
            return true;
        }
    }
}
