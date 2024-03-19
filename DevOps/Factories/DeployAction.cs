namespace DevOps.Factories {
    public class DeployAction : IAction {
        public void Execute() {
            Console.WriteLine("Deploying...");
        }
    }
}
