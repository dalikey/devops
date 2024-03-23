using DevOps.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOps.Tests.Factories {
    public class DeploymentPipelineTests {
        [Fact]
        public void AcceptVisitor_Should_Invoke_VisitMethodOfVisitor() {
            // Arrange
            var deploymentPipeline = new DeploymentPipeline();
            var visitor = new MockActionVisitor();

            // Act
            deploymentPipeline.AcceptVisitor(visitor);

            // Assert
            Assert.True(visitor.VisitedDeploymentPipeline);
        }

        [Fact]
        public void RunDeploymentPipe_Should_WriteToConsole() {
            // Arrange
            var deploymentPipeline = new DeploymentPipeline();
            var expectedOutput = $"Executing deployment pipeline";

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            deploymentPipeline.RunDeploymentPipe();

            // Assert
            Assert.Contains(expectedOutput, sw.ToString());
        }
    }
}
