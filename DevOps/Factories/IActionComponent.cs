namespace DevOps.Factories {
    public interface IActionComponent {
        public bool AcceptVisitor(IActionVisitor visitor);
    }
}
