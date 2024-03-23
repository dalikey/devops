using DevOps.Visitors;

namespace DevOps.Factories {
    public interface IActionFactory {
        IActionComponent CreateAction(string actionType);
        void Execute();
    }
}
