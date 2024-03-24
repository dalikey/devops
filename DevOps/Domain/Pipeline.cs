using DevOps.Factories;
using DevOps.Visitors;

namespace DevOps.Domain {
    public class Pipeline {
        public List<IActionComponent> Actions;

        public Pipeline(List<string> actionTypes) {
            Actions = new List<IActionComponent>();
            var actionFactory = new ActionFactory();
            foreach (var type in actionTypes) {
                Actions.Add(actionFactory.CreateAction(type));
            }
        }
    }
}
