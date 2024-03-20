namespace DevOps.Decorators {
    public class FooterDecorator : ReportDecorator {
        private string footer;

        public FooterDecorator(IReport report, string footer) : base(report) {
            this.footer = footer;
        }

        public override void GenerateReport() {
            base.GenerateReport();
            Console.WriteLine("Adding footer: " + footer);
        }
    }
}
