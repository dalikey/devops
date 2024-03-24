using DevOps.Visitors;

namespace DevOps.Factories {
    public class TestAction : IActionComponent {
        public string TestFramework { get; set; }
        public bool FinishedTests = false;

        public bool AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
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
