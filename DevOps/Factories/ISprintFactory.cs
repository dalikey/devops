using DevOps.Domain;

namespace DevOps.Factories {
    public interface ISprintFactory {

        Sprint CreateSprint(int id, string name, DateTime startDate, DateTime endDate);
        void NextPhase();
        void StartSprint();
        void FinishSprint();


    }
}
