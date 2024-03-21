namespace DevOps.Factories {
    public class SourcesAction : IActionComponent, IActionVisitor {
        public string GitURL { get; private set; }

        public bool VisitSources(SourcesAction sourcesAction) => false;

        //Accepts visitor
        public bool AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

        public bool Visit(IActionComponent actionComponent) {
            if (actionComponent is SourcesAction sourcesAction) {
                return VisitSources(sourcesAction);
            }
            return false;
        }


        //Run Action
        virtual public bool CloningRepository() {
            Console.WriteLine($"{GitURL}: Cloning Repository");
            return true;
        }
    }
}
