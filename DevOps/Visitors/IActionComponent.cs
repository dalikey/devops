namespace DevOps.Visitors {
    public interface IActionComponent {
        public bool AcceptVisitor(IActionVisitor visitor);
    }
}
