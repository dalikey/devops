using DevOps.Strategies;
using DevOps.Strategies.Behaviours;

namespace DevOps.Domain.Roles {
    public class ProductOwner : Person {
        public IRoleStrategy roleStrategy;

        public ProductOwner() {
            roleStrategy = new Managing();
        }

        public void Work() {
            roleStrategy.PerformRole();
        }

        public override void SendNotification(string message) {
            mediaAdapter.SendNotification(message);
        }
    }
}

