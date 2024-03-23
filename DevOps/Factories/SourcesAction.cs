﻿using DevOps.Visitors;

namespace DevOps.Factories {
    public class SourcesAction : IActionComponent {
        public string GitURL { get; set; }

        public bool AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

        virtual public bool CloningRepository() {
            Console.WriteLine($"{GitURL}: Cloning Repository");
            return true;
        }
    }
}
