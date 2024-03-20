using DevOps.Strategies;

namespace DevOps.Domain.Roles {
    public class Developer : IRoleStrategy {

        public void PerformRole() {
            Console.WriteLine("Perform developer action");
        }
    }
}
