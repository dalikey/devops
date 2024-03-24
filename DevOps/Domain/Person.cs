using DevOps.Adapters;

namespace DevOps.Domain {
    public abstract class Person {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        protected IMediaAdapter mediaAdapter;

        public void SetMediaAdapter(IMediaAdapter adapter) {
            mediaAdapter = adapter;
        }

        public abstract void SendNotification(string message);
    }
}
