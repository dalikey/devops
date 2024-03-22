namespace DevOps.Factories {
    public interface IActionVisitor {
        bool Visit(IActionComponent actionComponent);
    }
}
