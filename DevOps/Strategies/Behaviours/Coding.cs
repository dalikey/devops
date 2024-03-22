using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOps.Strategies.Behaviours {
    public class Coding : IRoleStrategy {
        public void PerformRole() {
            Console.WriteLine("Programming a new task...");
        }
    }
}
