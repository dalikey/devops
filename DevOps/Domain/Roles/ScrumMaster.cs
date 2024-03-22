using DevOps.Strategies;
using DevOps.Strategies.Behaviours;

namespace DevOps.Domain.Roles {
    public class ScrumMaster : Person { 

        public IRoleStrategy roleStrategy;
        public ScrumMaster() {
            roleStrategy = new Managing();
        }

        public void Work() {
            roleStrategy.PerformRole();
        }

    }
}
