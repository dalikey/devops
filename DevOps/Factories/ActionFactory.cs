﻿namespace DevOps.Factories {
    public class ActionFactory {
        public static IAction CreateAction(string actionType) {
            switch (actionType) {
                case "Sources":
                    return new SourcesAction();
                case "Package":
                    return new PackageAction();
                case "Build":
                    return new BuildAction();
                case "Test":
                    return new TestAction();
                case "Analyze":
                    return new AnalyzeAction();
                case "Deploy":
                    return new DeployAction();
                case "Utility":
                    return new UtilityAction();
                default:
                    throw new ArgumentException("Invalid action type");
            }
        }
    }
}