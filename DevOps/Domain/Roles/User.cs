namespace DevOps.Domain.Roles {
    public class User : Person {
        public void Use() {
            Console.WriteLine("Using...");
        }

        public override void SendNotification(string message) {
            mediaAdapter.SendNotification(message);
        }
    }
}
