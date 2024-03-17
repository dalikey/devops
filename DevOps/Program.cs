using DevOps.Domain;
using System.Diagnostics.CodeAnalysis;

namespace DevOps {
    [ExcludeFromCodeCoverage]
    public static class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hi");
            Sprint sprint = new Sprint();

            sprint.Review(); // Sprint moves to reviewing state
            sprint.Release(); // Sprint moves to released state
            sprint.Release(); // Sprint already released, no action taken
            sprint.CancelRelease(); // Cancel the release, sprint moves back to created state
            sprint.Release(); // Sprint moves to released state again
        }
    }
}
