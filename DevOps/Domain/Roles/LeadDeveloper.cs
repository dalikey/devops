using DevOps.Strategies;

namespace DevOps.Domain.Roles {
    public class LeadDeveloper : IRoleStrategy {

        public void PerformRole() {
            Console.WriteLine("Perform lead developer action");
        }
    }
}
