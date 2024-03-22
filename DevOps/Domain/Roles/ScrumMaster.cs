using DevOps.Strategies;

namespace DevOps.Domain.Roles {
    public class ScrumMaster : IRoleStrategy {
        public void PerformRole() {
            Console.WriteLine("Perform scrummaster action");
        }
    }
}
