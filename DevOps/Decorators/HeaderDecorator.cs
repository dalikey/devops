namespace DevOps.Decorators {
    public class HeaderDecorator : ReportDecorator {
        private string header;

        public HeaderDecorator(IReport report, string header) : base(report) {
            this.header = header;
        }

        public override void GenerateReport() {
            Console.WriteLine("Adding header: " + header);
            base.GenerateReport();
        }
    }
}
