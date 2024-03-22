﻿namespace DevOps.Decorators {
    public class FooterDecorator : IReport {
        private readonly IReport _report;
        private readonly string _companyName;
        private readonly string _projectName;
        private readonly string _version;
        private readonly DateTime _date;

        public FooterDecorator(IReport report, string companyName, string projectName, string version, DateTime date) {
            _report = report;
            _companyName = companyName;
            _projectName = projectName;
            _version = version;
            _date = date;
        }

        public void GenerateReport() {
            _report.GenerateReport();
            Console.WriteLine($"Report generated by {_companyName} for {_projectName} (Version {_version}) on {_date}");
        }
    }
}