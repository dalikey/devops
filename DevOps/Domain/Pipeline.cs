using DevOps.Factories;

namespace DevOps.Domain {
    public class Pipeline {
         private List<IActionVisitor> actions;

        public Pipeline(List<string> actionTypes) {
            actions = new List<IActionVisitor>();
            var actionFactory = new ActionFactory();
            foreach (var type in actionTypes) {
                actions.Add(actionFactory.CreateAction(type));
            }
        }
    }
}
