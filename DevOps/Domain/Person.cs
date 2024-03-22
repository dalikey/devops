using DevOps.Strategies;

namespace DevOps.Domain {
    public abstract class Person {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public IRoleStrategy RoleStrategy { get; set; }

        public void PerformRole() {
            if (RoleStrategy != null) {
                RoleStrategy.PerformRole();
            }
        }


       
    }
}

