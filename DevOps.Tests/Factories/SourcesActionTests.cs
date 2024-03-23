using DevOps.Factories;

namespace DevOps.Tests.Factories {
    public class SourcesActionTests {
        [Fact]
        public void AcceptVisitor_Should_Invoke_VisitMethodOfVisitor() {
            // Arrange
            var sourcesAction = new SourcesAction { GitURL = "https://github.com/example/repo.git" };
            var visitor = new MockActionVisitor();

            // Act
            sourcesAction.AcceptVisitor(visitor);

            // Assert
            Assert.True(visitor.VisitedSourcesAction);
        }

        [Fact]
        public void CloningRepository_Should_WriteToConsole() {
            // Arrange
            var gitUrl = "https://github.com/example/repo.git";
            var sourcesAction = new SourcesAction { GitURL = gitUrl };
            var expectedOutput = $"{gitUrl}: Cloning Repository";

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            sourcesAction.CloningRepository();

            // Assert
            Assert.Contains(expectedOutput, sw.ToString());
        }
    }
}
