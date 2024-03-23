using DevOps.Strategies;
using DevOps.Strategies.Behaviours;

namespace DevOps.Domain.Roles {
    public class Tester : Person {
        public IRoleStrategy roleStrategy;

        public Tester() {
            roleStrategy = new Testing();
        }

        public void Work() {
            roleStrategy.PerformRole();
        }
    }
}
