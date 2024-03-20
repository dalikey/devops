using DevOps.Strategies;

namespace DevOps.Domain.Roles {
    public class Tester : IRoleStrategy {
        public void PerformRole() {
            Console.WriteLine("Perform tester action");
        }
    }
}
