namespace DevOps.Factories {
    public class SourcesAction : IAction {
        public void Execute() {
            Console.WriteLine("Fetching source code...");
        }
    }
}
