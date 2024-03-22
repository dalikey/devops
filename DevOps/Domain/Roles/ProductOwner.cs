using DevOps.Strategies;

namespace DevOps.Domain.Roles {
    public class ProductOwner : IRoleStrategy {
        public void PerformRole() {
            Console.WriteLine("Perform productowner action");
        }
    }
}
