using DevOps.Strategies;
using DevOps.Strategies.Behaviours;

namespace DevOps.Domain.Roles {
    public class Developer : Person { 

        public IRoleStrategy roleStrategy { get; set; }

        public Developer() {
            RoleStrategy = new Coding();
        }

        public void Work() {
            RoleStrategy.PerformRole();
        }
    }
}
