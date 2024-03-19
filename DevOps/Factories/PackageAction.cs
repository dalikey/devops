namespace DevOps.Factories {
    public class PackageAction : IAction {
        public void Execute() {
            Console.WriteLine("Installing packages...");
        }
    }
}
