namespace DevOps.Decorators {
   public class HeaderDecorator : ReportDecorator {
        private readonly string _companyName;
        private readonly string _projectName;
        private readonly string _version;
        private readonly DateTime _date;

        public HeaderDecorator(IReport report, string companyName, string projectName, string version, DateTime date) : base(report) {
            _companyName = companyName;
            _projectName = projectName;
            _version = version;
            _date = date;
        }

        public override void GenerateReport() {
            Console.WriteLine($"Company: {_companyName}");
            Console.WriteLine($"Project: {_projectName}");
            Console.WriteLine($"Version: {_version}");
            Console.WriteLine($"Date: {_date}");
            base.GenerateReport();
        }
    }
}
