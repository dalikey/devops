namespace DevOps.Decorators {
    public class HeaderDecorator : IReport {
        private readonly IReport _report;
        private readonly string _companyName;
        private readonly string _projectName;
        private readonly string _version;
        private readonly DateTime _date;

        public HeaderDecorator(IReport report, string companyName, string projectName, string version, DateTime date) {
            _report = report;
            _companyName = companyName;
            _projectName = projectName;
            _version = version;
            _date = date;
        }

        public void GenerateReport() {
            Console.WriteLine($"Company: {_companyName}");
            Console.WriteLine($"Project: {_projectName}");
            Console.WriteLine($"Version: {_version}");
            Console.WriteLine($"Date: {_date}");
            _report.GenerateReport();
        }
    }

}
