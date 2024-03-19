using DevOps.Factories;

namespace DevOps.Domain {
    public class Pipeline {
        private List<IAction> actions;

        public Pipeline(List<string> actionTypes) {
            actions = new List<IAction>();
            foreach (var type in actionTypes) {
                actions.Add(ActionFactory.CreateAction(type));
            }
        }

        public void Execute() {
            foreach (var action in actions) {
                action.Execute();
            }
            Console.WriteLine("Pipeline execution completed.");
        }
    }
}
