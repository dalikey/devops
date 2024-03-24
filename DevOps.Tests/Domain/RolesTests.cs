using DevOps.Adapters;
using DevOps.Domain.Roles;
using DevOps.Strategies;
using Moq;

namespace DevOps.Tests.Domain.Roles {
    public class RolesTests {
        [Fact]
        public void Developer_Work_Should_PerformRoleAndSendNotification() {
            // Arrange
            var mockStrategy = new Mock<IRoleStrategy>();
            var developer = new Developer { roleStrategy = mockStrategy.Object };
            var mockAdapter = new Mock<IMediaAdapter>();
            developer.SetMediaAdapter(mockAdapter.Object);

            // Act
            developer.Work();

            // Assert
            mockStrategy.Verify(s => s.PerformRole(), Times.Once);
            mockAdapter.Verify(a => a.SendNotification("Developer is working..."), Times.Once);
        }

        [Fact]
        public void LeadDeveloper_Work_Should_PerformRole() {
            // Arrange
            var mockStrategy = new Mock<IRoleStrategy>();
            var leadDeveloper = new LeadDeveloper { roleStrategy = mockStrategy.Object };

            // Act
            leadDeveloper.Work();

            // Assert
            mockStrategy.Verify(s => s.PerformRole(), Times.Once);
        }

        [Fact]
        public void ProductOwner_Work_Should_PerformRole() {
            // Arrange
            var mockStrategy = new Mock<IRoleStrategy>();
            var productOwner = new ProductOwner { roleStrategy = mockStrategy.Object };

            // Act
            productOwner.Work();

            // Assert
            mockStrategy.Verify(s => s.PerformRole(), Times.Once);
        }

        [Fact]
        public void ScrumMaster_Work_Should_PerformRole() {
            // Arrange
            var mockStrategy = new Mock<IRoleStrategy>();
            var scrumMaster = new ScrumMaster { roleStrategy = mockStrategy.Object };

            // Act
            scrumMaster.Work();

            // Assert
            mockStrategy.Verify(s => s.PerformRole(), Times.Once);
        }

        [Fact]
        public void Tester_Work_Should_PerformRole() {
            // Arrange
            var mockStrategy = new Mock<IRoleStrategy>();
            var tester = new Tester { roleStrategy = mockStrategy.Object };

            // Act
            tester.Work();

            // Assert
            mockStrategy.Verify(s => s.PerformRole(), Times.Once);
        }

        [Fact]
        public void Use_Should_WriteToConsole() {
            // Arrange
            var user = new User();

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            user.Use();

            // Assert
            Assert.Equal("Using...\r\n", sw.ToString());
        }

        [Fact]
        public void SendNotification_Should_InvokeSendNotificationOnMediaAdapter() {
            // Arrange
            var user = new User();
            var mockAdapter = new Mock<IMediaAdapter>();
            user.SetMediaAdapter(mockAdapter.Object);
            string message = "Test message";

            // Act
            user.SendNotification(message);

            // Assert
            mockAdapter.Verify(a => a.SendNotification(message), Times.Once);
        }
    }
}
