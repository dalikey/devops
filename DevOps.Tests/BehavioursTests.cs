using DevOps.Strategies;
using DevOps.Strategies.Behaviours;

namespace DevOps.Tests {
    public class BehaviourTests {

        [Fact]
        public void Coding_Behaviour_Should_Write_To_Console() {

            //Arrange
            IRoleStrategy codingBehaviour = new Coding();

            using StringWriter sw = new();
            Console.SetOut(sw);

            //Act
            codingBehaviour.PerformRole();

            //Assert
            Assert.Contains("Programming a new task...", sw.ToString());

        }

        [Fact]
        public void Managing_Behaviour_Should_Write_To_Console() {

            //Arrange
            IRoleStrategy managingBehaviour = new Managing();

            using StringWriter sw = new();
            Console.SetOut(sw);

            //Act
            managingBehaviour.PerformRole();

            //Assert
            Assert.Contains("Managing a team or task...", sw.ToString());

        }

        [Fact]
        public void Planning_Behaviour_Should_Write_To_Console() {

            //Arrange
            IRoleStrategy planningBehaviour = new Planning();

            using StringWriter sw = new();
            Console.SetOut(sw);

            //Act
            planningBehaviour.PerformRole();

            //Assert
            Assert.Contains("Planning a task...", sw.ToString());

        }


        [Fact]
        public void Testing_Behaviour_Should_Write_To_Console() {

            //Arrange
            IRoleStrategy testingBehaviour = new Testing();

            using StringWriter sw = new();
            Console.SetOut(sw);

            //Act
            testingBehaviour.PerformRole();

            //Assert
            Assert.Contains("Testing a task...", sw.ToString());

        }
    }
}
