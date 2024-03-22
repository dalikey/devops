using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOps.Strategies.Behaviours {
    public class Planning : IRoleStrategy {
        public void PerformRole() {
            Console.WriteLine("Planning a task...");
        }
    }
}
