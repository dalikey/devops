namespace DevOps.Decorators {
    public class FormatDecorator : ReportDecorator {
        private string format;

        public FormatDecorator(IReport report, string format) : base(report) {
            this.format = format;
        }

        public override void GenerateReport() {
            base.GenerateReport();
            Console.WriteLine("Changing output format to: " + format);
        }
    }
}
