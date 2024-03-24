using DevOps.Domain;

namespace DevOps.Tests.Domain {
    public class ProjectTests {
        [Fact]
        public void AddBacklogItem_Should_Add_Item_To_BacklogItems_List() {
            // Arrange
            var project = new Project("Test Project");
            var backlogItem = new BacklogItem { Id = 1, Title = "Test Backlog Item" };

            // Act
            project.AddBacklogItem(backlogItem);

            // Assert
            Assert.Contains(backlogItem, project.BacklogItems);
        }

        [Fact]
        public void AddBacklogItem_Should_Sort_BacklogItems_By_Id() {
            // Arrange
            var project = new Project("Test Project");
            var backlogItem1 = new BacklogItem { Id = 2, Title = "Backlog Item 2" };
            var backlogItem2 = new BacklogItem { Id = 1, Title = "Backlog Item 1" };

            // Act
            project.AddBacklogItem(backlogItem1);
            project.AddBacklogItem(backlogItem2);

            // Assert
            Assert.Equal(backlogItem2, project.BacklogItems[0]);
            Assert.Equal(backlogItem1, project.BacklogItems[1]);
        }

        [Fact]
        public void AddSprint_Should_Add_Sprint_To_Sprints_List() {
            // Arrange
            var project = new Project("Test Project");
            var sprint = new Sprint { Name = "Test Sprint" };

            // Act
            project.AddSprint(sprint);

            // Assert
            Assert.Contains(sprint, project.Sprints);
        }
    }
}
