namespace DevOps.Visitors {
    public interface IActionComponent {
        public void AcceptVisitor(IActionVisitor visitor);
    }
}
