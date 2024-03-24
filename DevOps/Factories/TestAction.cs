using DevOps.Visitors;

namespace DevOps.Factories {
    public class TestAction : IActionComponent, IActionFactory {
        public string TestFramework { get; set; }
        public bool FinishedTests = false;

        public void AcceptVisitor(IActionVisitor visitor) {
            visitor.Visit(this);
        }


        public IActionComponent CreateAction(string actionType) {
            if (actionType == "TestAction") {
                return new TestAction();
            } else {
                throw new ArgumentException("Invalid action type");
            }
        }

        public void Execute() {
            RunTests();
            PublishTestResults();
        }

        virtual public bool RunTests() {
            Console.WriteLine($"{TestFramework}: Running Test Framework");
            FinishedTests = true;
            return true;
        }

        virtual public bool PublishTestResults() {
            if (!FinishedTests) {
                Console.WriteLine($"Results cannot be published");
                return false;
            } else {
                Console.WriteLine($"{TestFramework}: Publishing Test Results");
                return true;
            }
        }
    }
}
