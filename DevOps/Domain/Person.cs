using DevOps.Adapters;

namespace DevOps.Domain {
    public abstract class Person {
        protected IMediaAdapter mediaAdapter;

        public void SetMediaAdapter(IMediaAdapter adapter) {
            mediaAdapter = adapter;
        }

        public abstract void SendNotification(string message);
    }
}
