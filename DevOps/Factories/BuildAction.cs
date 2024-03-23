namespace DevOps.Factories {
    public class BuildAction : IActionComponent {
        public string BuildType { get; set; }

        public bool AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

        virtual public bool RunBuild() {
            Console.WriteLine($"{BuildType}: Executing");
            return true;
        }
    }
}
