﻿using DevOps.Decorators;
using DevOps.Domain;

namespace DevOps.Tests {
    public class DecoratorTests {
        [Fact]
        public void BasicReport_GenerateReport_Should_WriteToConsole() {
            // Arrange
            var sprints = new List<(string, TeamComposition, BurndownChart, List<DeveloperEffortPoints>)>();
            var basicReport = new BasicReport(sprints);

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            basicReport.GenerateReport();

            // Assert
            Assert.Contains("Generating basic report...", sw.ToString());
        }

        [Fact]
        public void HeaderDecorator_GenerateReport_Should_WriteToConsole() {
            // Arrange
            var innerReport = new BasicReport(new List<(string, TeamComposition, BurndownChart, List<DeveloperEffortPoints>)>());
            var headerDecorator = new HeaderDecorator(innerReport, "Company", "Project", "1.0", DateTime.Now);

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            headerDecorator.GenerateReport();

            // Assert
            Assert.Contains("Company: Company", sw.ToString());
            Assert.Contains("Project: Project", sw.ToString());
            Assert.Contains("Version: 1.0", sw.ToString());
            Assert.Contains($"Date: {DateTime.Now}", sw.ToString());
        }

        [Fact]
        public void FooterDecorator_GenerateReport_Should_WriteToConsole() {
            // Arrange
            var innerReport = new BasicReport(new List<(string, TeamComposition, BurndownChart, List<DeveloperEffortPoints>)>());
            var footerDecorator = new FooterDecorator(innerReport, "Company", "Project", "1.0", DateTime.Now);

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            footerDecorator.GenerateReport();

            // Assert
            Assert.Contains($"Report generated by Company for Project (Version 1.0) on {DateTime.Now}", sw.ToString());
        }

        [Fact]
        public void FormatDecorator_GenerateReport_Should_WriteToConsole() {
            // Arrange
            var innerReport = new BasicReport(new List<(string, TeamComposition, BurndownChart, List<DeveloperEffortPoints>)>());
            var formatDecorator = new FormatDecorator(innerReport, "PDF");

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            formatDecorator.GenerateReport();

            // Assert
            Assert.Contains("Changing output format to: PDF", sw.ToString());
        }

        [Fact]
        public void SprintDecorator_GenerateReport_Should_WriteToConsole() {
            // Arrange
            var developers = new List<string> { "Developer 1", "Developer 2", "Developer 3" };
            var teamComposition = new TeamComposition { TeamName = "Team A", Developers = developers };
            var remainingEffort = new List<int> { 10, 8, 6, 4, 2 };
            var burndownChart = new BurndownChart { SprintStartDate = DateTime.Now, SprintEndDate = DateTime.Now.AddDays(14), RemainingEffort = remainingEffort };
            var effortPointsPerDeveloper = new List<DeveloperEffortPoints> { new DeveloperEffortPoints { DeveloperName = "Developer 1", EffortPoints = 20 }, new DeveloperEffortPoints { DeveloperName = "Developer 2", EffortPoints = 15 } };
            var innerReport = new BasicReport(new List<(string, TeamComposition, BurndownChart, List<DeveloperEffortPoints>)>());
            var sprintDecorator = new SprintDecorator(innerReport, "Sprint 1", teamComposition, burndownChart, effortPointsPerDeveloper);

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            sprintDecorator.GenerateReport();

            // Assert
            Assert.Contains("Sprint: Sprint 1", sw.ToString());
            Assert.Contains("Sprint Team: Team A", sw.ToString());
            Assert.Contains("Burndown Chart:", sw.ToString());
            Assert.Contains($"Sprint Start Date: {DateTime.Now}", sw.ToString());
            Assert.Contains($"Sprint End Date: {DateTime.Now.AddDays(14)}", sw.ToString());
            Assert.Contains("Remaining Effort:", sw.ToString());
            foreach (var remainingEffortItem in remainingEffort) {
                Assert.Contains($"- {remainingEffortItem}", sw.ToString());
            }
            Assert.Contains("Effort Points per Developer:", sw.ToString());
            foreach (var effortPoints in effortPointsPerDeveloper) {
                Assert.Contains($"- {effortPoints.DeveloperName}: {effortPoints.EffortPoints}", sw.ToString());
            }
        }
    }
}
