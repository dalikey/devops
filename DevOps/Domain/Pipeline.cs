using DevOps.Factories;

namespace DevOps.Domain {
    public class Pipeline {
         private List<IActionComponent> actions;

        public Pipeline(List<string> actionTypes) {
            actions = new List<IActionComponent>();
            var actionFactory = new ActionFactory();
            foreach (var type in actionTypes) {
                actions.Add(actionFactory.CreateAction(type));
            }
        }
    }
}
