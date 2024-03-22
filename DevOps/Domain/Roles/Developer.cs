using DevOps.Strategies;
using DevOps.Strategies.Behaviours;

namespace DevOps.Domain.Roles {
    public class Developer : Person { 

        public IRoleStrategy roleStrategy { get; set; }

        public Developer() {
            roleStrategy = new Coding();
        }

        public void Work() {
            roleStrategy.PerformRole();
        }
    }
}
