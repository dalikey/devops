using DevOps.Strategies;

namespace DevOps.Domain.Roles {
    public class User : IRoleStrategy {

        public void PerformRole() {
            Console.WriteLine("Perform user action");
        }
    }
}
