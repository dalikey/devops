namespace DevOps.Factories {
    public class TestAction : IActionComponent, IActionVisitor {
        public string TestFramework { get; set; }
        public bool FinishedTests = false;

        public bool VisitTest(TestAction testAction) => false;

        //Accepts visitor
        public bool AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

        public bool Visit(IActionComponent actionComponent) {
            if (actionComponent is TestAction testAction) {
                return VisitTest(testAction);
            }

            return false;
        }

        virtual public bool RunTests() {
            Console.WriteLine($"{TestFramework}: Running Test Framework");
            FinishedTests = true;
            return true;
        }

        virtual public bool PublishTestResults() {
           if(!FinishedTests) {
                Console.WriteLine($"Results cannot be published");
                return false;
            } else {
                Console.WriteLine($"{TestFramework}: Publishing Test Results");
                return true; 
            }

        }
    }
}
