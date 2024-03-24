using DevOps.Factories;
using Moq;

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
        public void CloneRepository_Should_WriteToConsole() {
            // Arrange
            var gitUrl = "https://github.com/example/repo.git";
            var sourcesAction = new SourcesAction { GitURL = gitUrl };
            var expectedOutput = $"{gitUrl}: Cloning Repository";

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            sourcesAction.CloneRepository();

            // Assert
            Assert.Contains(expectedOutput, sw.ToString());
        }

        [Fact]
        public void CreateAction_SourcesAction_ReturnsSourcesActionInstance() {
            // Arrange
            var actionType = "SourcesAction";
            var sourcesAction = new SourcesAction();

            // Act
            var result = sourcesAction.CreateAction(actionType);

            // Assert
            Assert.IsType<SourcesAction>(result);
        }

        [Fact]
        public void CreateAction_InvalidActionType_ThrowsArgumentException() {
            // Arrange
            var actionType = "InvalidActionType";
            var sourcesAction = new SourcesAction();

            // Act and Assert
            Assert.Throws<ArgumentException>(() => sourcesAction.CreateAction(actionType));
        }

        [Fact]
        public void Execute_Should_Run_Clone_Repository() {
            //Arrange
            var sourcesAction = new SourcesAction();
            var mockSourcesAction = new Mock<SourcesAction> { CallBase = true };
            mockSourcesAction.Setup(m => m.CloneRepository()).Returns(true);

            //Act
            mockSourcesAction.Object.Execute();

            //Assert
            mockSourcesAction.Verify(m => m.CloneRepository(), Times.Once);
        }
    }
}
