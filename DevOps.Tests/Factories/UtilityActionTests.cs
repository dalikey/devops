﻿using DevOps.Factories;

namespace DevOps.Tests.Factories {
    public class UtilityActionTests {
        [Fact]
        public void AcceptVisitor_Should_Invoke_VisitMethodOfVisitor() {
            // Arrange
            var utilityAction = new UtilityAction { Actions = new List<string> { "Action1", "Action2" } };
            var visitor = new MockActionVisitor();

            // Act
            utilityAction.AcceptVisitor(visitor);

            // Assert
            Assert.True(visitor.VisitedUtilityAction);
        }

        [Fact]
        public void RunUtilityActions_Should_WriteToConsole() {
            // Arrange
            var actions = new List<string> { "Action1", "Action2" };
            var utilityAction = new UtilityAction { Actions = actions };
            var expectedOutputs = new List<string> {
                "Action1: Action is running",
                "Action2: Action is running"
            };

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            utilityAction.RunUtilityActions();

            // Assert
            foreach (var expectedOutput in expectedOutputs) {
                Assert.Contains(expectedOutput, sw.ToString());
            }
        }
    }
}