﻿namespace DevOps.Factories {
    public class DeployAction : IActionComponent {
        public string DeploymentTarget { get; set; }

        public bool AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

        virtual public bool RunDeploymentTarget() {
            Console.WriteLine($"{DeploymentTarget}: Executing deployment tool");
            return true;
        }
    }
}
