using DevOps.Strategies;
using DevOps.Strategies.Behaviours;

namespace DevOps.Domain.Roles {
    public class LeadDeveloper : Person {

        public IRoleStrategy roleStrategy;

        public LeadDeveloper() {
            roleStrategy = new Managing();
        }

        public void Work() {
            roleStrategy.PerformRole();
        }

    }
}
