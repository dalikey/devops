using DevOps.Domain;

namespace DevOps.Tests.Domain {
    public class PipelineTests {
        [Fact]
        public void Pipeline_CanBeCreated_WithActionTypes() {
            // Arrange
            var actionTypes = new List<string> { "Analyze", "Deploy", "Package" };

            // Act
            var pipeline = new Pipeline(actionTypes);

            // Assert
            Assert.NotNull(pipeline);
            Assert.Equal(actionTypes.Count, pipeline.Actions.Count);
        }

        [Fact]
        public void Pipeline_CreatesCorrectActions() {
            // Arrange
            var actionTypes = new List<string> { "Analyze", "Deploy", "Package" };

            // Act
            var pipeline = new Pipeline(actionTypes);

            // Assert
            Assert.NotNull(pipeline);
            Assert.Equal(actionTypes.Count, pipeline.Actions.Count);

            foreach (var action in pipeline.Actions) {
                Assert.NotNull(action);
            }
        }
    }
}
