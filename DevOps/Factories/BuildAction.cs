namespace DevOps.Factories {
    public class BuildAction : IAction {
        public void Execute() {
            Console.WriteLine("Building software...");
        }
    }
}
