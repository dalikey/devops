using DevOps.Domain;

namespace DevOps.Factories {
        public interface SprintFactory {
            Sprint CreateSprint(int id, string name, DateTime startDate, DateTime endDate);
        }

    }
