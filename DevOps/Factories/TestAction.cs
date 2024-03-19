namespace DevOps.Factories {
    public class TestAction : IAction {
        public void Execute() {
            Console.WriteLine("Running tests...");
        }
    }
}
