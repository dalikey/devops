namespace DevOps.Factories {
    public interface IActionFactory {
        IActionVisitor CreateAction(string actionType);
        void Execute();
    }
}
